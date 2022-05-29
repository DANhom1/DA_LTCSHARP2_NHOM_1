USE master
IF EXISTS(SELECT * FROM sys.databases WHERE name='QL_ShopQuanAo')
BEGIN
        DROP DATABASE QL_ShopQuanAo
END
CREATE DATABASE QL_ShopQuanAo
GO
USE QL_ShopQuanAo
GO

CREATE TABLE QUYEN 
(
    MAQUYEN INT IDENTITY NOT NULL,
    TENQUYEN NVARCHAR(50), -- TÊN CÁC NHÓM QUYỀN(ADIMIN,NHÂN VIÊN)
    CONSTRAINT PK_QUYEN PRIMARY KEY (MAQUYEN) --KHÓA CHÍNH
)
CREATE TABLE TAIKHOAN 
(
    MATK CHAR(10) NOT NULL, 
    TENTK VARCHAR(50),
	MATKHAU CHAR(50),
    MAQUYEN INT ,
	--KHÓA CHÍNH
	CONSTRAINT PK_TAIKHOAN PRIMARY KEY (MATK),
	--KHÓA NGOẠI
	CONSTRAINT FK_TK_QUYEN FOREIGN KEY(MAQUYEN) REFERENCES QUYEN(MAQUYEN)
)
CREATE TABLE THONGTINTAIKHOAN 
(
	MATK CHAR(10) NOT NULL, 
    HOTEN NVARCHAR(50), -- HỌ TÊN
    NGSINH DATE, -- NGÀY SINH
    GTINH NVARCHAR(3),
    NGTAO DATETIME, -- NGÀY TẠO
    EMAIL VARCHAR(50), -- ĐỊA CHỈ EMAIL
    SDT VARCHAR(11), -- SDT
    DCHI NVARCHAR(50), -- ĐỊA CHỈ NHÀ
	TINHTRANG NVARCHAR(50),---ĐANG LÀM ,NGHỈ VIỆC
	--KHÓA CHÍNH
    CONSTRAINT PK_TTTK PRIMARY KEY (MATK),
	--KHÓA NGOẠI
	CONSTRAINT FK_TTTK_TAIKHOAN FOREIGN KEY(MATK) REFERENCES TAIKHOAN(MATK)
)
CREATE TABLE KHACHHANG 
(
    MAKH VARCHAR(11) NOT NULL, -- sdt 
    DIEMTICHLUY INT,
    CONSTRAINT PK_KH PRIMARY KEY (MAKH)
)
CREATE TABLE NHANVIEN 
(
    MANV VARCHAR(10) NOT NULL,
    MATK CHAR(10) NOT NULL, 
    CONSTRAINT PK_NV PRIMARY KEY (MANV),
    CONSTRAINT FK_NV_TK FOREIGN KEY (MATK) REFERENCES TAIKHOAN(MATK)
)
CREATE TABLE LOAISP 
(
    MALSP VARCHAR(6) NOT NULL,
    TENLOAI NVARCHAR(50),
    CONSTRAINT PK_LSP PRIMARY KEY (MALSP)
)
CREATE TABLE DANHMUC 
(
    MADM INT IDENTITY NOT NULL,
    TENDANHMUC NVARCHAR(50),
    CONSTRAINT PK_DMUC PRIMARY KEY (MADM)
)
CREATE TABLE CHITIETDANHMUC 
(
	MADM INT NOT NULL REFERENCES DANHMUC(MADM),
	MALSP VARCHAR(6) NOT NULL REFERENCES LOAISP(MALSP),
	CONSTRAINT PK_CTDM PRIMARY KEY (MADM, MALSP)
)
CREATE TABLE SANPHAM 
(
    MASP INT IDENTITY NOT NULL, -- CREATE AUTO
    TENSP NVARCHAR(MAX), -- TÊN SẢN PHẨM
    SOLUONG INT, -- SỐ LƯỢNG TỒN KHO
	SIZE NVARCHAR(10),--Size Đồ
    DONGIA FLOAT, -- ĐƠN GIÁ
	HINHANH NVARCHAR(MAX),--HÌNH ẢNH SẢN PHẨM
    NSX NVARCHAR(30), -- NHÀ SẢN XUẤT
    MALSP VARCHAR(6) REFERENCES LOAISP(MALSP),
    CONSTRAINT PK_SP PRIMARY KEY (MASP)
)
CREATE TABLE HOADON 
(
    MAHD INT IDENTITY NOT NULL, -- CREATE AUTO
    NGTAO DATETIME, -- NGÀY TẠO HÓA ĐƠN
    THANHTOAN FLOAT, -- TỔNG (SỐ LƯỢNG * ĐƠN GIÁ)
    TINHTRANG NVARCHAR(50), -- CHƯA THANHTOAN,DATT
    MAKH VARCHAR(11) REFERENCES KHACHHANG(MAKH),
    MANV VARCHAR(10) REFERENCES NHANVIEN(MANV),
    CONSTRAINT PK_HD PRIMARY KEY (MAHD)
)
CREATE TABLE CHITIETHD 
(
    MAHD INT REFERENCES HOADON(MAHD),
    MASP INT REFERENCES SANPHAM(MASP),
    SOLUONG INT, -- SỐ LƯỢNG > 0, số lượng bán
    CONSTRAINT PK_CTHD PRIMARY KEY (MAHD,MASP) 
)
CREATE TABLE THONGKE 
(
    THANG int NOT NULL,
	NAM int NOT NULL,
	DOANHTHU int,
	--KHÓA CHÍNH
    CONSTRAINT PK_THONGKE PRIMARY KEY (THANG,NAM) 
)
----------------------------------------------------------------------------
--RÀNG BUỘC TOÀN VẸN
----------------------------------------------------------------------------
SET DATEFORMAT DMY

--TABLE TAIKHOAN
ALTER TABLE TAIKHOAN ADD CONSTRAINT uni_TenLoaiTK UNIQUE(TENTK)
GO

--TABLE THONGTINTAIKHOAN
ALTER TABLE THONGTINTAIKHOAN ADD CONSTRAINT chk_GioiTinh CHECK(GTINH IN (N'Nam', N'Nữ'))
ALTER TABLE THONGTINTAIKHOAN ADD CONSTRAINT chk_NgayVaoLam CHECK(NGTAO<=GETDATE())
ALTER TABLE THONGTINTAIKHOAN ADD CONSTRAINT DEF_DC DEFAULT N'TP.HCM' FOR DCHI
ALTER TABLE THONGTINTAIKHOAN ADD CONSTRAINT chk_SDT_NV CHECK(LEN(SDT)=10)
ALTER TABLE THONGTINTAIKHOAN ADD CONSTRAINT UNI_SDT UNIQUE(SDT)
ALTER TABLE THONGTINTAIKHOAN ADD CONSTRAINT UNI_EMAIL UNIQUE(EMAIL)
GO

--TABLE KHACHHANG
ALTER TABLE KHACHHANG ADD CONSTRAINT chk_SDT_KH CHECK(LEN(MAKH)=10)
ALTER TABLE KHACHHANG ADD CONSTRAINT chk_PhanTramGiam CHECK(DIEMTICHLUY>=0 AND DIEMTICHLUY<=50)
GO

--TABLE HOADON
ALTER TABLE CHITIETHD ADD CONSTRAINT chk_SoLuong_CTHD CHECK(SOLUONG>0)
ALTER TABLE HOADON ADD CONSTRAINT chk_ThanhTien_HD CHECK(THANHTOAN>0)
GO

--TABLE DANH MUC
ALTER TABLE DANHMUC ADD CONSTRAINT uni_TenDanhMuc UNIQUE(TENDANHMUC)
GO

--TABLE SANPHAM

ALTER TABLE SANPHAM ADD CONSTRAINT chk_GiaBan CHECK(DONGIA>0)
GO

--Ràng buộc trigger

--Cập nhật thanh toán trên hóa đơn
CREATE TRIGGER CAPNHATTHANHTOAN
ON CHITIETHD
FOR INSERT,UPDATE,DELETE
AS
	BEGIN
	DECLARE @GiamGia MONEY
	
	-- cập nhật số lượng tồn của sản phẩm khi thêm vào 1 CHITIETHD
		UPDATE SANPHAM
		SET SOLUONG = SOLUONG - (SELECT SOLUONG FROM inserted)
				WHERE MASP = (SELECT MASP FROM inserted)
	--cập nhật TỔNG TIỀN sau khi trừ đi ĐIỂM TÍCH LŨY cho KHACHHANG (1 điểm được 2000)
	IF((SELECT DIEMTICHLUY FROM KHACHHANG,HOADON WHERE HOADON.MAKH=KHACHHANG.MAKH AND MAHD =(SELECT MAHD FROM inserted))>0)
	BEGIN
		SET @GiamGia = (SELECT DIEMTICHLUY FROM KHACHHANG,HOADON WHERE HOADON.MAKH=KHACHHANG.MAKH AND MAHD =(SELECT MAHD FROM inserted))*2000
	-- cập nhật TỔNG TIỀN thu được của mỗi CHITIETHD
		UPDATE HOADON
		SET THANHTOAN = (SELECT SUM(CHITIETHD.SOLUONG*SANPHAM.DONGIA)
						FROM CHITIETHD,SANPHAM
						WHERE CHITIETHD.MASP = SANPHAM.MASP AND CHITIETHD.MAHD =(SELECT MAHD FROM inserted) GROUP BY CHITIETHD.MAHD) - @GiamGia
		WHERE MAHD =(SELECT MAHD FROM inserted)
	END
		ELSE
		-- cập nhật TỔNG TIỀN thu được của mỗi CHITIETHD
		UPDATE HOADON
		SET THANHTOAN = (SELECT SUM(CHITIETHD.SOLUONG*SANPHAM.DONGIA)
						FROM CHITIETHD,SANPHAM
						WHERE CHITIETHD.MASP = SANPHAM.MASP AND CHITIETHD.MAHD =(SELECT MAHD FROM inserted) GROUP BY CHITIETHD.MAHD)
		WHERE MAHD =(SELECT MAHD FROM inserted)
	END		
GO
--cập nhật điểm tích lũy khi khách hàng mua sản phẩm trên 500k

CREATE TRIGGER sp_UpdateDiemTL
ON HOADON
AFTER UPDATE
AS
	IF((SELECT THANHTOAN FROM HOADON WHERE MAHD =(SELECT MAHD FROM inserted)) > 500000 
		AND (SELECT TINHTRANG FROM HOADON WHERE MAHD =(SELECT MAHD FROM inserted)) = N'Đã thanh toán')
	BEGIN
		UPDATE KHACHHANG 
		SET DIEMTICHLUY = DIEMTICHLUY + 1
		WHERE MAKH =(SELECT MAKH FROM inserted)
	END
GO


----------------------------------------------------------------------------
--NHẬP DỮ LIỆU
----------------------------------------------------------------------------


--BẢNG QUYỀN
INSERT QUYEN VALUES(N'ADMIN')
INSERT QUYEN VALUES(N'NHÂN VIÊN')

--BẢNG TÀI KHOẢN
CREATE PROC sp_AddTK(
	@MATK CHAR(10) , 
	@TENTK VARCHAR(50),
	@MATKHAU CHAR(50),
    @MAQUYEN INT)

AS 
--KIỂM TRA TRÙNG KHÓA CHÍNH
	IF EXISTS(SELECT * FROM TAIKHOAN WHERE MATK=@MATK)
		RETURN 0
	--THÊM MỚI DỮ LIỆU
	INSERT INTO TAIKHOAN(MATK,TENTK,MATKHAU,MAQUYEN)
	VALUES(@MATK,@TENTK, @MATKHAU, @MAQUYEN)
GO
--mã hash=123
EXEC sp_AddTK '1','ADMIN1','123','1'
EXEC sp_AddTK '2','ADMIN2','123','1'
EXEC sp_AddTK '3','NHANVIEN1','123','2'
EXEC sp_AddTK '4','NHANVIEN2','123','2'
EXEC sp_AddTK '5','NHANVIEN3','123','2'
EXEC sp_AddTK '6','NHANVIEN4','123','2'

--BẢNG THÔNG TIN TÀI KHOẢN
CREATE PROC sp_AddTTTK(
	@MATK CHAR(10) , 
    @HOTEN NVARCHAR(50), -- HỌ TÊN
    @NGSINH DATE, -- NGÀY SINH
    @GTINH NVARCHAR(3),
    @NGTAO DATETIME, -- NGÀY TẠO
    @EMAIL VARCHAR(50), -- ĐỊA CHỈ EMAIL
    @SDT VARCHAR(11), -- SDT
    @DCHI NVARCHAR(50),
	@TINHTRANG NVARCHAR(50))

AS 
--KIỂM TRA TRÙNG KHÓA CHÍNH
	IF EXISTS(SELECT * FROM THONGTINTAIKHOAN WHERE MATK=@MATK)
		RETURN 0
	--THÊM MỚI DỮ LIỆU
	INSERT INTO THONGTINTAIKHOAN(MATK,HOTEN,NGSINH,GTINH,NGTAO,EMAIL,SDT,DCHI,TINHTRANG)
	VALUES(@MATK,@HOTEN,@NGSINH,@GTINH,@NGTAO,@EMAIL,@SDT,@DCHI,@TINHTRANG)
GO
SET DATEFORMAT DMY
EXEC sp_AddTTTK '1',N'LÊ THÙY NA','17/05/2001',N'Nữ','1/1/2021 07:08:09','nalethuy@gmail.com','0362417182',N'Phú Yên',N'Đang Làm'
EXEC sp_AddTTTK '2',N'TRẦN TRỌNG BÌNH PHƯƠNG','01/01/2001',N'NAM','1/1/2021 07:08:09','phuong@gmail.com','0123456789',N'Đồng Tháp',N'Đang Làm'
EXEC sp_AddTTTK '3',N'TRẦN ĐỨC THẮNG','09/07/2001',N'Nam','1/1/2021 07:08:09','bnguyenva@gmail.com','0345674123',N'Bình Dương',N'Đang Làm'
EXEC sp_AddTTTK '4',N'HUỲNH THU PHƯƠNG','08/07/1999',N'Nữ','1/1/2021 07:08:09','tunu@gmail.com','0312345678',N'Bình Dương',N'Đang Làm'
EXEC sp_AddTTTK '5',N'TẠ MINH TRỰC','05/07/2001',N'Nam','1/1/2021 07:08:09','minhtruc12@gmail.com','0383039079',N'Bình Dương',N'Đang Làm'
EXEC sp_AddTTTK '6',N'VÕ KIỀU MINH HẢI','01/07/1999',N'Nữ','1/1/2021 07:08:09','minhhai2@gmail.com','0961314900',N'Bình Dương',N'Đang Làm'

--BẢNG KHÁCH HÀNG
INSERT KHACHHANG VALUES('0934214565',0)
INSERT KHACHHANG VALUES('0948571923',1)
INSERT KHACHHANG VALUES('0968492918',2)
INSERT KHACHHANG VALUES('0989090761',3)

--BẢNG NHÂN VIÊN
INSERT NHANVIEN VALUES('NV01','3')
INSERT NHANVIEN VALUES('NV02','4')
INSERT NHANVIEN VALUES('NV03','5')
INSERT NHANVIEN VALUES('NV04','6')

-- BẢNG DANH MỤC
INSERT DANHMUC VALUES(N'Áo')
INSERT DANHMUC VALUES(N'Quần' )
INSERT DANHMUC VALUES(N'Váy' )
INSERT DANHMUC VALUES(N'Đầm' )
INSERT DANHMUC VALUES(N'Phụ kiện' )

--BẢNG THỐNG KÊ
INSERT INTO THONGKE VALUES
(1,2021,900000),
(1,2022,800000),
(2,2021,900000),
(2,2022,600000),
(3,2021,700000),
(3,2022,500000),
(4,2021,900000),
(4,2022,100000),
(5,2021,800000),
(5,2022,600000),
(6,2021,800000),
(6,2022,500000),
(7,2021,900000),
(7,2022,800000),
(8,2021,900000),
(8,2022,200000),
(9,2021,300000),
(9,2022,900000),
(10,2021,900000),
(10,2022,700000),
(11,2021,600000),
(11,2022,900000),
(12,2021,200000),
(12,2022,400000);

-- BẢNG LOẠI SP
-- áo
INSERT LOAISP VALUES('LSP01',N'Trễ vai')
INSERT LOAISP VALUES('LSP02',N'Croptop')
INSERT LOAISP VALUES('LSP03',N'Sơ mi')
INSERT LOAISP VALUES('LSP04',N'Hai dây')

-- quần
INSERT LOAISP VALUES('LSP05',N'Quần short')
INSERT LOAISP VALUES('LSP06',N'Quần ống loe')
INSERT LOAISP VALUES('LSP07',N'Quần skinny')
INSERT LOAISP VALUES('LSP08',N'Quần giả váy')

-- váy
INSERT LOAISP VALUES('LSP09',N'Váy tennis')
INSERT LOAISP VALUES('LSP10',N'Váy chữ A')
INSERT LOAISP VALUES('LSP11',N'Váy jeans')
INSERT LOAISP VALUES('LSP12',N'Váy xòe')

-- đầm
INSERT LOAISP VALUES('LSP13',N'Đầm body')
INSERT LOAISP VALUES('LSP14',N'Đầm babydoll')
INSERT LOAISP VALUES('LSP15',N'Đầm trễ vai')
INSERT LOAISP VALUES('LSP16',N'Set')

--Phụ kiện
INSERT LOAISP VALUES('LSP17',N'Mũ')
INSERT LOAISP VALUES('LSP18',N'Túi')
INSERT LOAISP VALUES('LSP19',N'Đồng hồ')
INSERT LOAISP VALUES('LSP20',N'Giày')

CREATE PROC sp_AddSP(
	@TENSP NVARCHAR(MAX), -- TÊN SẢN PHẨM
    @SOLUONG INT, -- SỐ LƯỢNG TỒN KHO
	@SIZE NVARCHAR(10),
    @DONGIA FLOAT, -- ĐƠN GIÁ
	@HINHANH NVARCHAR(MAX),
    @NSX NVARCHAR(30), -- NHÀ SẢN XUẤT
    @MALSP VARCHAR(6))

AS 
--KIỂM TRA TRÙNG KHÓA CHÍNH
	IF EXISTS(SELECT * FROM SANPHAM WHERE TENSP=@TENSP)
		RETURN 0
	--THÊM MỚI DỮ LIỆU
	INSERT INTO SANPHAM(TENSP,SOLUONG,SIZE,DONGIA,HINHANH,NSX,MALSP)
	VALUES(@TENSP,@SOLUONG,@SIZE, @DONGIA,@HINHANH, @NSX,@MALSP)
GO
--BẢNG SP
--ÁO
--trễ vai
EXEC sp_AddSP N'Floral Off-The-Shoulder Top',40,'L',650000,'1.jpg',N'Việt Nam','LSP01'
EXEC sp_AddSP N'Tie Dye Long Sleeve Cover Up Top',40,'M',280000,'2.jpg',N'Trung Quốc','LSP01'
EXEC sp_AddSP N'Floral Mesh Bell Sleeve Crop Top',40,'S',460000,'3.jpg',N'Hàn Quốc','LSP01'
EXEC sp_AddSP N'Off-Shoulder Ruffle Shirt',40,'XL',550000,'4.jpg',N'Thái Lan','LSP01'
EXEC sp_AddSP N'Solid Twist Front Crop Top',40,'M',280000,'5.jpg',N'Việt Nam','LSP01'

--áo croptop

EXEC sp_AddSP N'Boho Tie Front Embroidered Top',40,'L',650000,'6.jpg',N'Việt Nam','LSP02'
EXEC sp_AddSP N'Short Sleeve Denim Crop Shirt',40,'M',740000,'7.jpg',N'Mỹ','LSP02'
EXEC sp_AddSP N'V-Neck Baby Tee',40,'M',320000,'8.jpg',N'Nhật','LSP02'
EXEC sp_AddSP N'Letter Print Crop Polo',40,'XL',450000,'9.jpg',N'Hàn Quốc','LSP02'
EXEC sp_AddSP N'Demin Button Up Crop Top',40,'S',650000,'10.jpg',N'Thái Lan','LSP02'
--áo sơ mi

EXEC sp_AddSP N'Glitter Tie Front',40,'XL',400000,'11.jpg',N'Việt Nam','LSP03'
EXEC sp_AddSP N'Stripe Button Up Blouse',40,'L',550000,'12.jpg',N'Trung Quốc','LSP03'
EXEC sp_AddSP N'Solid Long Sleeve Crop Blouse',40,'S',290000,'13.jpg',N'Hàn Quốc','LSP03'
EXEC sp_AddSP N'Solid Waist Tied Button Up Blous',40,'M',620000,'14.jpg',N'Nhật Bản','LSP03'
EXEC sp_AddSP N'Denim Button Up Crop Shirt',40,'L',500000,'15.jpg',N'Việt Nam','LSP03'
--hai dây
EXEC sp_AddSP N'Colorful Stripe Bow Shirred Tank Top',40,'L',440000,'16.jpg',N'Hàn Quốc','LSP04'
EXEC sp_AddSP N'Glitter Tie Front Tank Top',40,'XL',590000,'17.jpg',N'Việt Nam','LSP04'
EXEC sp_AddSP N'Demin Button Up',40,'M',780000,'18.jpg',N'Mỹ','LSP04'
EXEC sp_AddSP N'Solid Ruffle Hem V-Neck Cami Top',40,'XL',430000,'19.jpg',N'Việt Nam','LSP04'
EXEC sp_AddSP N'Solid Cross Rib',40,'S',390000,'20.jpg',N'Anh','LSP04'

--QUẦN
--quần short
EXEC sp_AddSP N'Colorblock Mid Rise Shorts',40,'XL',560000,'21.jpg',N'Nhật','LSP05'
EXEC sp_AddSP N'Wave Stripe Detail Shorts',40,'XL',650000,'22.jpng',N'Việt Nam','LSP05'
EXEC sp_AddSP N'Solid Denim Ripped Shorts',40,'S',340000,'23.jpg',N'Thái Lan','LSP05'
EXEC sp_AddSP N'Embroidered Floral Denim Mini Shorts',40,'L',660000,'24.jpg',N'Việt Nam','LSP05'
EXEC sp_AddSP N'Solid Bowknot Mini Shorts',40,'S',230000,'25.jpg',N'Hàn Quốc','LSP05'
--quần ống loe
EXEC sp_AddSP N'Retro All Over Print Knit Pants',40,'XL',550000,'26.jpg',N'Trung Quốc','LSP06'
EXEC sp_AddSP N'Blue Cable Knit Trousers',40,'M',720000,'27.jpg',N'Hàn Quốc','LSP06'
EXEC sp_AddSP N'Bow Slit High Waist Knit Flares',40,'M',190000,'28.jpg',N'Anh','LSP06'
EXEC sp_AddSP N'Houndstooth Wide Leg Knit Trousers',40,'S',450000,'29.jpg',N'Việt Nam','LSP06'
EXEC sp_AddSP N'Contrast Color Knit Trousers',40,'XL',490000,'30.jpg',N'Mỹ','LSP06'
--quần skinny
EXEC sp_AddSP N'Decipher Me Knitted Trousers',40,'L',170000,'31.jpg',N'Nhật','LSP07'
EXEC sp_AddSP N'Embroidery Flare Leg Jeans',40,'L',340000,'32.jpg',N'Hàn Quốc','LSP07'
EXEC sp_AddSP N'Solid Pocket Cargo Pants',40,'S',640000,'33.jpg',N'Việt Nam','LSP07'
EXEC sp_AddSP N'First Bloom Wide Leg Trousers',40,'XL',760000,'34.jpg',N'Thái Lan','LSP07'
EXEC sp_AddSP N'Strawberry Fields Wide Leg Trousers',40,'S',380000,'35.jpg',N'Mỹ','LSP07'
--quẩn giả váy
EXEC sp_AddSP N'Solid Mini Pleated Skirt With Belt','L',40,240000,'36.jpg',N'Hàn Quốc','LSP08'
EXEC sp_AddSP N'Retro Floral Mini Shorts','L',40,430000,'37.jpg',N'Nhật','LSP08'
EXEC sp_AddSP N'Knit Mini Pleated Skirt','M',40,360000,'38.jpg',N'Thái Lan','LSP08'
EXEC sp_AddSP N'Solid Mini Pleated Shorts','XL',40,530000,'39.jpg',N'Việt Nam','LSP08'
EXEC sp_AddSP N'Solid Bow Shorts','S',40,250000,'40.jpg',N'Hàn Quốc','LSP08'

--VÁY
--váy bút tennis
EXEC sp_AddSP N'Floral Print Mini Ruffle Skirt',40,'S',530000,'41.jpg',N'Việt Nam','LSP09'
EXEC sp_AddSP N'Hazelnut Latte Micro Mini Skirt',40,'XL',240000,'42.jpg',N'Việt Nam','LSP09'
EXEC sp_AddSP N'Little Bit Angelic White Mini Skirt',40,'S',260000,'43.jpg',N'Nhật','LSP09'
EXEC sp_AddSP N'Solid Ruffle Skort',40,'M',240000,'44.jpg',N'Mỹ','LSP09'
EXEC sp_AddSP N'Hot Summer Y2K Mini Skirt',40,'L',320000,'45.jpg',N'Thái Lan','LSP09'
--váy chữ A
EXEC sp_AddSP N'Double Button Mini Skort',40,'L',360000,'46.jpg',N'Việt Nam','LSP10'
EXEC sp_AddSP N'Solid Side Pocket Mini Skirt',40,'M',420000,'47.jpg',N'Hàn Quốc','LSP10'
EXEC sp_AddSP N'Toile de Jouy Mini Skirt',40,'S',330000,'48.jpg',N'Việt Nam','LSP10'
EXEC sp_AddSP N'Curve & Plus Paisley Pattern Slit Lo',40,'XL',660000,'49.jpg',N'Hàn Quốc','LSP10'
EXEC sp_AddSP N'Solid Mini Skirt With Belt',40,'M',200000,'50.jpg',N'Thái Lan','LSP10'
--váy jeans
EXEC sp_AddSP N'Denim Pocket Mini Skirt',40,'L',240000,'51.jpg',N'Việt Nam','LSP11'
EXEC sp_AddSP N'Butterfly Print Mini Denim Skirt',40,'L',440000,'52.jpg',N'Việt Nam','LSP11'
EXEC sp_AddSP N'Solid Pleated Mini Skirt',40,'XL',540000,'53.jpg',N'Thái Lan','LSP11'
EXEC sp_AddSP N'Solid Texture Mini Skort',40,'S',250000,'54.jpg',N'Nhật','LSP11'
EXEC sp_AddSP N'Butterfly Print Mini Denim Skirt',40,'XL',540000,'55.jpg',N'Việt Nam','LSP11'
--váy xòe
EXEC sp_AddSP N'Solid Pleated Mini Skirt',40,'L',430000,'56.jpg',N'Mỹ','LSP12'
EXEC sp_AddSP N'Vertical Stripe Pleated Mini Skirt',40,'M',370000,'57.jpg',N'Thái Lan','LSP12'
EXEC sp_AddSP N'Solid Flap Pocket Cargo Skirt',40,'XL',360000,'58.jpg',N'Hàn Quốc','LSP12'
EXEC sp_AddSP N'Denim Mini Low Rise Pleated Skort',40,'S',370000,'59.jpg',N'Việt Nam','LSP12'
EXEC sp_AddSP N'Solid Ruffle Hem Mini Skirt',40,'XL',270000,'60.jpg',N'Việt Nam','LSP12'

--ĐẦM
--BODY
EXEC sp_AddSP N'Solid Ruched Mini Dress',40,'L',760000,'61.jpg',N'Mỹ','LSP13'
EXEC sp_AddSP N'Contrasting Edge Pearl Knit Dress',40,'S',650000,'62.jpg',N'Hàn Quốc','LSP13'
EXEC sp_AddSP N'Solid Satin Slit Midi Dress',40,'M',750000,'63.jpg',N'Nhật','LSP13'
EXEC sp_AddSP N'Asymmetric Neck Mini Halter Dress',40,'M',750000,'64.jpg',N'Nhật','LSP13'
EXEC sp_AddSP N'Ruched Maxi Dress',40,'S',460000,'65.jpg',N'Việt Nam','LSP13'

--baby doll
EXEC sp_AddSP N'Geometric Pattern Zipped Mini Dress',40,'XL',750000,'66.jpg',N'Thái Lan','LSP14'
EXEC sp_AddSP N'Floral Slit Knotted Midi Dress',40,'M',360000,'67.jpg',N'Mỹ','LSP14'
EXEC sp_AddSP N'Floral Slit Cami Midi Dress',40,'L',360000,'68.jpg',N'Hàn Quốc','LSP14'
EXEC sp_AddSP N'Floral Puff Sleeve Mini Dress',40,'S',220000,'69.jpg',N'Việt Nam','LSP14'
EXEC sp_AddSP N'Blossom Floral Mini Dress',40,'M',730000,'70.jpg',N'Trung Quốc','LSP14'

--đầm trễ vai
EXEC sp_AddSP N'Floral Bell Sleeve Corset Mini Dress',40,'L',360000,'71.jpg',N'Hàn Quốc','LSP15'
EXEC sp_AddSP N'Off Shoulder Corset Mini Dress',40,'S',740000,'72.jpg',N'Nhật','LSP15'
EXEC sp_AddSP N'Illusion Tie Dye Ruched Maxi Dress',40,'XL',460000,'73.jpg',N'Thái Lan','LSP15'
EXEC sp_AddSP N'Curve & Plus Floral Ruffle Halter Mini Dress',40,'S',340000,'74.jpg',N'Hàn Quốc','LSP15'
EXEC sp_AddSP N'Tie Dye Off-Shoulder Mini Dress',40,'L',230000,'75.jpg',N'Mỹ','LSP15'
--set
EXEC sp_AddSP N'Illusion Floral Knotted Maxi Dress',40,'XL',600000,'76.jpg',N'Việt Nam','LSP16'
EXEC sp_AddSP N'Solid V-Neckline Cami Dress',40,'M',750000,'77.jpg',N'Trung Quốc','LSP16'
EXEC sp_AddSP N'Watercolor Floral Backless Maxi Dress',40,'M',540000,'78.jpg',N'Hàn Quốc','LSP16'
EXEC sp_AddSP N'Satin Off-Shoulder Maxi Dress',40,'L',350000,'79.jpg',N'Mỹ','LSP16'
EXEC sp_AddSP N'Colorblock Rib Knit Midi Dress',40,'S',460000,'80.jpg',N'Việt Nam','LSP16'

--Phụ kiện
--mũ
EXEC sp_AddSP N'Solid Bucket Hat',40,'M',570000,'81.jpg',N'Thái Lan','LSP17'
EXEC sp_AddSP N'Letter C Baker Boy Hat',40,'S',240000,'82.jpg',N'Trung Quốc','LSP17'
EXEC sp_AddSP N'Flower Decor Straw hat',40,'XL',230000,'83.jpg',N'Việt Nam','LSP17'
EXEC sp_AddSP N'Heart Knit Hat',40,'L',350000,'84.jpg',N'Hàn Quốc','LSP17'
EXEC sp_AddSP N'Letter Bucket Hat',40,'S',250000,'85.jpg',N'Mỹ'
--túi

EXEC sp_AddSP N'Túi trái tim',40,'S',760000,'86.jpg',N'Hàn Quốc','LSP18'
EXEC sp_AddSP N'Túi nơ',40,'M',780000,'87.jpg',N'Mỹ','LSP18'
EXEC sp_AddSP N'Túi trắng',40,'L',970000,'88.jpg',N'Việt Nam','LSP18'
EXEC sp_AddSP N'Túi hồng',40,'XL',770000,'89.jpg',N'Trung Quốc','LSP18'
EXEC sp_AddSP N'Túi đen',40,'L',850000,'90.jpg',N'Việt Nam','LSP18'

--đồng hồ
EXEC sp_AddSP N'Đồng hồ 1',40,'M',570000,'91.jpg',N'Việt Nam','LSP19'
EXEC sp_AddSP N'Đồng hồ 2',40,'L',670000,'92.jpg',N'Mỹ','LSP19'
EXEC sp_AddSP N'Đồng hồ 3',40,'XL',760000,'93.jpg',N'Việt Nam','LSP19'
EXEC sp_AddSP N'Đồng hồ 4',40,'S',470000,'94.jpg',N'Trung Quốc','LSP19'
EXEC sp_AddSP N'Đồng hồ 5',40,'L',870000,'95.jpg',N'Hàn Quốc','LSP19'

--Giày
EXEC sp_AddSP N'Giày cao gót 1',40,'L',1230000,'96.jpg',N'Mỹ','LSP19'
EXEC sp_AddSP N'Giày búp bê',40,'XL',2040000,'97.jpg',N'Việt Nam','LSP19'
EXEC sp_AddSP N'Giày cao gót 2',40,'M',5600000,'98.jpg',N'Trung Quốc','LSP19'
EXEC sp_AddSP N'Giày cao gót 3',40,'XL',6420000,'99.jpg',N'Việt Nam','LSP19'
EXEC sp_AddSP N'Giày sneaker',40,'S',2530000,'100.jpg',N'Trung Quốc','LSP19'

select TENSP,TENLOAI from SANPHAM,LOAISP WHERE SANPHAM.MALSP=LOAISP.MALSP

--BẢNG HÓA ĐƠN
	CREATE PROC sp_AddHD(
    @NGTAO DATETIME, -- NGÀY TẠO HÓA ĐƠN
    @THANHTOAN FLOAT, -- TỔNG (SỐ LƯỢNG * ĐƠN GIÁ)
    @TINHTRANG NVARCHAR(50), -- CHƯA THANHTOAN,DATT
    @MAKH VARCHAR(11),
    @MANV VARCHAR(10) )

AS 
	--THÊM MỚI DỮ LIỆU
	INSERT INTO HOADON(NGTAO,THANHTOAN,TINHTRANG,MAKH,MANV)
	VALUES(@NGTAO,@THANHTOAN,@TINHTRANG,@MAKH,@MANV)
GO

EXEC sp_AddHD '08/12/2020','1',N'Đã thanh toán','0934214565','NV01'
EXEC sp_AddHD '08/01/2020','1',N'Đã thanh toán','0948571923','NV02'
EXEC sp_AddHD '08/05/2020','1',N'Đã thanh toán','0968492918','NV03'

--BẢNG CHI TIẾT HÓA ĐƠN
CREATE PROC sp_AddCTHD(
    @MAHD INT,
    @MASP INT,
    @SOLUONG INT)

AS 
	--KIỂM TRA TRÙNG KHÓA CHÍNH
	IF EXISTS(SELECT * FROM CHITIETHD WHERE MASP=@MASP AND MAHD=@MAHD)
		RETURN 0
	--THÊM MỚI DỮ LIỆU
	INSERT INTO CHITIETHD(MAHD,MASP,SOLUONG)
	VALUES(@MAHD,@MASP,@SOLUONG)
GO

EXEC sp_AddCTHD '1','6','1'
EXEC sp_AddCTHD '1','23','1'
EXEC sp_AddCTHD '1','7','1'
EXEC sp_AddCTHD '1','32','1'
EXEC sp_AddCTHD '1','40','1'
EXEC sp_AddCTHD '1','69','1'

EXEC sp_AddCTHD '2','4','1'
EXEC sp_AddCTHD '2','11','1'
EXEC sp_AddCTHD '2','36','1'
EXEC sp_AddCTHD '2','1','1'
EXEC sp_AddCTHD '2','2','1'
EXEC sp_AddCTHD '2','3','1'


EXEC sp_AddCTHD '3','42','1'
EXEC sp_AddCTHD '3','67','1'
EXEC sp_AddCTHD '3','8','1'
EXEC sp_AddCTHD '3','9','1'
EXEC sp_AddCTHD '3','3','1'
EXEC sp_AddCTHD '3','5','1'

SELECT * FROM CHITIETHD
SELECT * FROM HOADON
SELECT * FROM SANPHAM

--Thống kê doanh thu
CREATE PROC up_RevenueStatistics @From Date, @To Date
AS
	SELECT CONVERT(DATE,NGTAO) 'NgayXuatHD', SUM(THANHTOAN) 'ThanhTien'
	FROM HOADON 
	WHERE CONVERT(DATE,NGTAO) BETWEEN @From AND @To 
	GROUP BY CONVERT(DATE,NGTAO)
GO

--Thống kê sản phẩm
CREATE PROC up_ProductStatistics @From Date, @To Date
AS
	SELECT TENSP, SUM(CHITIETHD.SOLUONG) 'TongSoLuong'
	FROM HOADON, CHITIETHD, SANPHAM
	WHERE HOADON.MAHD=CHITIETHD.MAHD AND CHITIETHD.MASP=SANPHAM.MASP
	AND CONVERT(DATE, NGTAO) BETWEEN @From AND @To
	GROUP BY SANPHAM.MASP, TENSP
GO


CREATE PROC sp_ChartSanPham
@nam int
AS
	SELECT TOP 10 TENSP, SUM(CTHD.SOLUONG) SOLUONGBANRA
	FROM HOADON HD JOIN CHITIETHD CTHD 
		ON HD.MAHD = CTHD.MAHD JOIN SANPHAM SP
		ON SP.MASP = CTHD.MASP
	WHERE YEAR(NGTAO) = @nam
	GROUP BY TENSP
	ORDER BY SOLUONGBANRA DESC
GO

CREATE PROC sp_ChartNhanVien
@nam int
AS
	SELECT HOTEN, SUM(THANHTOAN) DOANHTHU
	FROM HOADON HD JOIN NHANVIEN NV
		ON NV.MANV = HD.MANV JOIN THONGTINTAIKHOAN TTTK
		ON TTTK.MATK = NV.MATK
	WHERE YEAR(HD.NGTAO) = @nam
	GROUP BY HOTEN
	ORDER BY DOANHTHU DESC
GO

CREATE PROC sp_ChartDoanhThu
@nam int
AS
	DECLARE @tbDoanhThu TABLE (THANG INT, DOANHTHU FLOAT)
	INSERT @tbDoanhThu
		SELECT m, SUM(THANHTOAN) DOANHTHU
		FROM (SELECT * FROM HOADON WHERE YEAR(NGTAO) = @nam) dtn RIGHT JOIN (
			SELECT m
			FROM (VALUES (1), (2), (3), (4), (5), (6), (7), (8), (9), (10), (11), (12))
			[1 to 12](m)
		) listMonth
			ON MONTH(NGTAO)=listMonth.m
		GROUP BY m
		ORDER BY m
	
	UPDATE @tbDoanhThu SET DOANHTHU = 0 WHERE DOANHTHU IS NULL
	SELECT * FROM @tbDoanhThu
GO
