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
        private void ManHinhNV_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Xin Chào: " + ManHinhAdmin.tentk);
            label1.Text = String.Format("NHÂN VIÊN: {0}", ManHinhAdmin.tentk);
            ThongTinTaiKhoan.matk = ManHinhAdmin.matk;
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}
