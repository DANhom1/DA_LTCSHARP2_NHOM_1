using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class BLLSanPham
    {
        DALSanPham dalsp = new DALSanPham();
        public List<View_SanPham> LoadSanPham()
        {
            return dalsp.LoadSanPham();
        }
        public void ThemSanPham(string tensp, int soluong, float dongia, string nsx, string malsp)
        {
            dalsp.ThemSanPham(tensp, soluong, dongia, nsx, malsp);
        }
        public void XoaSP(int maSP)
        {
            dalsp.XoaSanPham(maSP);
        }
        public void SuaSanPham(int maSP, string tensp, int soluong, float dongia, string nsx, string malsp)
        {
            dalsp.SuaSanPham(maSP, tensp, soluong, dongia, nsx, malsp);
        }
    }
}
