using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace BUS
{
    public class BUSSanPham
    {
        Data da = new Data();
        public DataTable getSP()
        {
            DataTable dt = null;
            String sql = "SELECT MASP, TENSP,DONGIA FROM SANPHAM";
            dt = da.getTable(sql);
            return dt;
        }
    }
}
