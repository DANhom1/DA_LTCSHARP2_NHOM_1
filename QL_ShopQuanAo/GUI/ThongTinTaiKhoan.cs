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
    public partial class ThongTinTaiKhoan : Form
    {
        BLLTaiKhoan bbTK = new BLLTaiKhoan();
        QLQADataContext qlqa = new QLQADataContext();
        public static string  matk;
        
        public ThongTinTaiKhoan()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void ThongTinTaiKhoan_Load(object sender, EventArgs e)
        {
            THONGTINTAIKHOAN tttk = bbTK.ThongTinTK(matk);
            ManHinhAdmin mh = new ManHinhAdmin();
            label6.Text = matk;
            txtHoTen.Text = tttk.HOTEN;
            txtDiaChi.Text = tttk.DCHI;
            txtGT.Text = tttk.GTINH;
            DateTime datens = DateTime.Parse(tttk.NGSINH.ToString());
            dtpNS.Value = DateTime.Parse(datens.ToShortDateString());

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string ns=dtpNS.Value.ToString();
            bbTK.SuaTaiKhoan(label6.Text, txtHoTen.Text, txtDiaChi.Text, ns, txtGT.Text);
            MessageBox.Show("Sửa Thông Tin Thành Công");
            ThongTinTaiKhoan_Load(sender, e);
        }


    }
}
