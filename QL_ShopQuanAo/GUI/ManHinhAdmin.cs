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
    public partial class ManHinhAdmin : Form
    {
        BLLTaiKhoan bllTK = new BLLTaiKhoan();
        QLQADataContext qlqa = new QLQADataContext();
        public static string matk;
        public static string tentk;
        public static string tenhienthi;
        public static string manv;
        public ManHinhAdmin()
        {
            InitializeComponent();
        }
        private Form formCheck(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == ftype)
                {
                    return f;
                }
            }
            return null;
        }
        private void danhMụcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = formCheck(typeof(DanhMuc));
            if (frm == null)
            {
                DanhMuc f = new DanhMuc();
                f.MdiParent = this;
                f.Show();
            }
            else
            {
                frm.Activate();
            }
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongTinTaiKhoan frm = new ThongTinTaiKhoan();
            frm.MdiParent=this;
            
            frm.Show();
        }

        private void ManHinhAdmin_Load(object sender, EventArgs e)
        {
            var f = new DangNhap();
            f.ShowDialog();
            TAIKHOAN taikhoan = f.taikhoan;
            NHANVIEN nv = f.nv;
            if(f.taikhoan.MAQUYEN==1)
            {
                MessageBox.Show("Xin Chào: " + taikhoan.TENTK);
                label1.Text = String.Format("QUẢN LÝ: {0}", taikhoan.TENTK);
                tenhienthi = taikhoan.TENTK;
                ThongTinTaiKhoan.matk = taikhoan.MATK;
            }
            else
            {
                //ManHinhNV a = new ManHinhNV();
                ////MessageBox.Show("Xin Chào: " + taikhoan.TENTK);
                //tentk = taikhoan.TENTK;
                //matk = taikhoan.MATK;
                //a.ShowDialog();
                //this.Dispose();
                //ManHinhNV a = new ManHinhNV();
                MessageBox.Show("Xin Chào: " + taikhoan.TENTK);
                label1.Text = String.Format("NHÂN VIÊN: {0}", taikhoan.TENTK);
                manv = nv.MANV;
                tenhienthi = taikhoan.TENTK;
                //a.ShowDialog();
                //this.Dispose();
                nhânViênToolStripMenuItem.Enabled = false;
                danhMụcToolStripMenuItem.Enabled = false;
                thốngKêToolStripMenuItem.Enabled = false;
                ThongTinTaiKhoan.matk = taikhoan.MATK;
            }
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HoaDon f = new HoaDon();
            f.ShowDialog();
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sảnPhẩmToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SanPham f = new SanPham();
            f.ShowDialog();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMatKhau f = new DoiMatKhau();
            f.ShowDialog();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                //this.Close();
                ManHinhAdmin f = new ManHinhAdmin();
                f.ShowDialog();
            }
        }

        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKe f = new ThongKe();
            f.ShowDialog();
        }

        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BanHang f = new BanHang();
            f.ShowDialog();
        }

        private void sảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KhachHang f = new KhachHang();
            f.ShowDialog();
        }

    }
}
