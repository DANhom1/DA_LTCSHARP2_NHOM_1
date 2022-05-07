using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;

namespace GUI
{
    public partial class    ManHinhNV : Form
    {
        public ManHinhNV()
        {
            InitializeComponent();
        }
        BLLTaiKhoan bllTK = new BLLTaiKhoan();
        QLQADataContext qlqa = new QLQADataContext();
        private void ManHinhNV_Load(object sender, EventArgs e)
        {
            var f = new DangNhap();
            f.ShowDialog();
            TAIKHOAN taikhoan = f.taikhoan;
            //BLLTaiKhoan bll = new BLLTaiKhoan();
            MessageBox.Show("Xin Chào: " + taikhoan.TENTK);
            label1.Text = String.Format("NHANVIEN: {0}", taikhoan.TENTK);
            ThongTinTaiKhoan.matk = taikhoan.MATK;
        }

    }
}
