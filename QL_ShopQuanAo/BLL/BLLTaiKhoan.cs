using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;
using DAL;

namespace BLL
{
    public class BLLTaiKhoan
    {
        DALTaiKhoan daltk = new DALTaiKhoan();
        public int LoadTaiKhoan(int quyen)
        {
            return daltk.LoadTaiKhoan(quyen);
        }
        public THONGTINTAIKHOAN ThongTinTK(string maTK)
        {
            return daltk.ThongTinTK(maTK);
        }
    }
}
