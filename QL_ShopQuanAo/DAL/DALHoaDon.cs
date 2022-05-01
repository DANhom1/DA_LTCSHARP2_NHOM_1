﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DALHoaDon
    {
        QLQADataContext qlqa = new QLQADataContext();
        public DALHoaDon()
        {

        }
        public List<View_HoaDon> LoadHoaDon()
        {
            List<HOADON> kq = qlqa.HOADONs.Select(t => t).ToList<HOADON>();
            var kqnew = kq.ConvertAll(m => new View_HoaDon()
            {
                MAHD = m.MAHD,
                NGTAO = m.NGTAO,
                THANHTOAN=m.THANHTOAN,
                TINHTRANG=m.TINHTRANG,
                MAKH=m.MAKH,
                MANV=m.MANV
            });
            return kqnew.ToList<View_HoaDon>();
        }
        public void ThemHoaDon(DateTime ngTao,float thanhToan,String tinhTrang,String maKH,string maNV )
        {
            HOADON hd = new HOADON();
            hd.NGTAO = ngTao;
            hd.THANHTOAN=thanhToan;
            hd.TINHTRANG=tinhTrang;
            hd.MAKH=maKH;
            hd.MANV=maNV;
            qlqa.HOADONs.InsertOnSubmit(hd);
            qlqa.SubmitChanges();
        }
        public void XoaHoaDon(int maHD)
        {
            var xoa = qlqa.HOADONs.Single(t => t.MAHD == maHD);
            qlqa.HOADONs.DeleteOnSubmit(xoa);
            qlqa.SubmitChanges();
        }
        public void SuaHoaDon(int maHD,DateTime ngTao,float thanhToan,String tinhTrang,String maKH,string maNV )
        {
            HOADON hd = new HOADON();
            var sua = qlqa.HOADONs.Single(t => t.MAHD == maHD);
            sua.NGTAO = ngTao;
            sua.THANHTOAN=thanhToan;
            sua.TINHTRANG=tinhTrang;
            sua.MAKH=maKH;
            sua.MANV=maNV;
            qlqa.SubmitChanges();
        }
        public int ktMaHD(int maHD)
        {
            return qlqa.HOADONs.Where(t => t.MAHD == maHD).Count();
        }
    }
}