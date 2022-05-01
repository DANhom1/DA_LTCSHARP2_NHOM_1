using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class BLLHoaDon
    {
        DALHoaDon dalhoadon = new DALHoaDon();
        public BLLHoaDon()
        { 

        }
        public List<View_HoaDon> LoadHoaDon()
        {
            return dalhoadon.LoadHoaDon();
        }
        public void ThemHoaDon(DateTime ngTao, float thanhToan, String tinhTrang, String maKH, string maNV)
        {
            dalhoadon.ThemHoaDon( ngTao, thanhToan, tinhTrang, maKH, maNV);
        }
        public void XoaHoaDon(int maHD)
        {
            dalhoadon.XoaHoaDon(maHD);
        }
        public void SuaHoaDon(int maHD, DateTime ngTao, float thanhToan, String tinhTrang, String maKH, string maNV)
        {
            dalhoadon.SuaHoaDon( maHD, ngTao, thanhToan, tinhTrang, maKH, maNV);
        }
        public int ktMaHD(int maHD)
        {
            return dalhoadon.ktMaHD(maHD);
        }
    }
}
