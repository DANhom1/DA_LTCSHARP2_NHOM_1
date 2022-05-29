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
using GUI;

namespace GUI
{
    public partial class  ManHinhNV : Form
    {
        public ManHinhNV()
        {
            InitializeComponent();
        }
        BLLTaiKhoan bllTK = new BLLTaiKhoan();
        QLQADataContext qlqa = new QLQADataContext();
        public static string matk;
        public static string tentk;
        public static string tenhienthi;
        public static string manv;
        private void ManHinhNV_Load(object sender, EventArgs e)
        {
            //var f = new DangNhap();
            //f.ShowDialog();
            //TAIKHOAN taikhoan = f.taikhoan;
            //NHANVIEN nv = f.nv;
            //if (f.taikhoan.MAQUYEN == 1)
            //{
            //    MessageBox.Show("Xin Chào: " + taikhoan.TENTK);
            //    label1.Text = String.Format("QUẢN LÝ: {0}", taikhoan.TENTK);
            //    tenhienthi = taikhoan.TENTK;
            //    ThongTinTaiKhoan.matk = taikhoan.MATK;
            //}
            //else
            //{
            //    //ManHinhNV a = new ManHinhNV();
            //    ////MessageBox.Show("Xin Chào: " + taikhoan.TENTK);
            //    //tentk = taikhoan.TENTK;
            //    //matk = taikhoan.MATK;
            //    //a.ShowDialog();
            //    //this.Dispose();

            //    MessageBox.Show("Xin Chào: " + taikhoan.TENTK);
            //    label1.Text = String.Format("NHÂN VIÊN: {0}", taikhoan.TENTK);
            //    manv = nv.MANV;
            //    tenhienthi = taikhoan.TENTK;
            //    nhânViênToolStripMenuItem.Enabled = false;
            //    //danhMụcToolStripMenuItem.Enabled = false;
            //    thốngKêToolStripMenuItem.Enabled = false;
            //    ThongTinTaiKhoan.matk = taikhoan.MATK;
            //}
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ManHinhNV_Load(sender, e);
        }

    }
}
