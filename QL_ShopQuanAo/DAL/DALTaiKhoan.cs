using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class DALTaiKhoan
    {
        QLQADataContext qlqa = new QLQADataContext();
        
        public int LoadTaiKhoan(int quyen)
        {
            return qlqa.TAIKHOANs.Where(t => t.MAQUYEN == quyen).Count();
        }
        //public List<THONGTINTAIKHOAN> ThongTinTK(string maTK)
        //{
        //    return qlqa.THONGTINTAIKHOANs.Where(t => t.MATK == maTK).ToList<THONGTINTAIKHOAN>();
        //}
        public THONGTINTAIKHOAN ThongTinTK(string maTK)
        {
            return qlqa.THONGTINTAIKHOANs.SingleOrDefault(t => t.MATK == maTK);
        }
        
    }
}
