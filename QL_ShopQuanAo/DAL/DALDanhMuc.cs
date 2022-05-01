using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DALDanhMuc
    {
        QLQADataContext qlqa = new QLQADataContext();
        public DALDanhMuc()
        {

        }
        public List<DANHMUC> LoadDanhMuc()
        {
            List<DANHMUC> kq = qlqa.DANHMUCs.Select(t => t).ToList<DANHMUC>();
            var kqnew = kq.ConvertAll(m => new DANHMUC()
            {
                MADM = m.MADM,
                TENDANHMUC = m.TENDANHMUC,
            });
            return kqnew.ToList<DANHMUC>();
        }
        public void ThemDanhMuc(string tenDM)
        {
            DANHMUC dm = new DANHMUC();
            dm.TENDANHMUC = tenDM;
            qlqa.DANHMUCs.InsertOnSubmit(dm);
            qlqa.SubmitChanges();
        }
        public void XoaDanhMuc(int maDM)
        {
            var xoa = qlqa.DANHMUCs.Single(t => t.MADM == maDM);
            qlqa.DANHMUCs.DeleteOnSubmit(xoa);
            qlqa.SubmitChanges();
        }
        public void SuaDanhMuc(int maDM,string tenDM)
        {
            DANHMUC dm = new DANHMUC();
            var sua = qlqa.DANHMUCs.Single(t => t.MADM == maDM);
            sua.TENDANHMUC = tenDM;
            qlqa.SubmitChanges();
        }
        public int ktMaDM(int maDM)
        {
            return qlqa.DANHMUCs.Where(t => t.MADM == maDM).Count();
        }
    }
}
