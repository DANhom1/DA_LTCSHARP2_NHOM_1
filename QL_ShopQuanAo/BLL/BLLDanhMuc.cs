using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class BLLDanhMuc
    {
        DALDanhMuc daldanhmuc = new DALDanhMuc();
        public BLLDanhMuc()
        { 

        }
        public List<DANHMUC> LoadDanhMuc()
        {
            return daldanhmuc.LoadDanhMuc();
        }
        public void ThemDanhMuc(string tenDM)
        {
            daldanhmuc.ThemDanhMuc(tenDM);
        }
        public void XoaDanhMuc(int maDM)
        {
            daldanhmuc.XoaDanhMuc(maDM);
        }
        public void SuaDanhMuc(int maDM,string tenDM)
        {
            daldanhmuc.SuaDanhMuc(maDM,tenDM);
        }
        public int ktMaDM(int maDM)
        {
            return daldanhmuc.ktMaDM(maDM);
        }
    }
}
