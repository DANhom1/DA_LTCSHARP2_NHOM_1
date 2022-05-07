using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DALSanPham
    {
        QLQADataContext qlqa = new QLQADataContext();
        public DALSanPham()
        { }

        public List<View_SanPham> LoadSanPham()
        {
            List<SANPHAM> kq = qlqa.SANPHAMs.Select(t => t).ToList<SANPHAM>();
            var kqnew = kq.ConvertAll(m => new View_SanPham()
            {
                MASP=m.MASP,
                TENSP=m.TENSP,
                SOLUONG=m.SOLUONG,
                DONGIA=m.DONGIA,
                NSX=m.NSX,
                MALSP=m.MALSP
            });
            return kqnew.ToList<View_SanPham>();
        }
        public void ThemSanPham(string tenSP,int soluong, float dongia, string nsx, string malsp)
        {
            SANPHAM sp = new SANPHAM();
            sp.TENSP = tenSP;
            sp.SOLUONG = soluong;
            sp.DONGIA = dongia;
            sp.NSX = nsx;
            sp.MALSP = malsp;
            qlqa.SANPHAMs.InsertOnSubmit(sp);
            qlqa.SubmitChanges();
        }
        public void XoaSanPham(int maSP)
        {
            var xoa = qlqa.SANPHAMs.Single(t => t.MASP == maSP);
            qlqa.SANPHAMs.DeleteOnSubmit(xoa);
            qlqa.SubmitChanges();
        }
        public void SuaSanPham(int maSP, string tenSP, int soluong, float dongia, string nsx, string malsp)
        {
            SANPHAM sp = new SANPHAM();
            var sua = qlqa.SANPHAMs.Single(t => t.MASP == maSP);
            sua.TENSP = tenSP;
            sua.SOLUONG = soluong;
            sua.DONGIA = dongia;
            sua.NSX = nsx;
            sua.MALSP = malsp;
            qlqa.SubmitChanges();
        }
    }
}
