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
    public partial class DoiMatKhau : Form
    {
        public DoiMatKhau()
        {
            InitializeComponent();
        }
        BLLTaiKhoan bllTK = new BLLTaiKhoan();

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassCu.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassCu.UseSystemPasswordChar = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtPassMoi.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassMoi.UseSystemPasswordChar = true;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtRePassMoi.UseSystemPasswordChar = false;
            }
            else
            {
                txtRePassMoi.UseSystemPasswordChar = true;
            }
        }

        private void butonQuanAo2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butonQuanAo1_Click(object sender, EventArgs e)
        {
            if (bllTK.kiemTraPass(ManHinhAdmin.tenhienthi,txtPassCu.Text) != null)
            {
                if (!txtPassMoi.Text.Equals(txtRePassMoi.Text))
                {
                    errorProvider1.SetError(txtRePassMoi, "Mật khẩu nhập lại không khớp");
                }
                else
                {
                    //errorProvider1.SetError(txtRePassMoi, null);
                    //if (bllTK.DoiPass(ManHinhAdmin.tenhienthi, txtPassMoi.Text) != null)
                    //{
                        bllTK.DoiPass(ManHinhAdmin.tenhienthi, txtPassMoi.Text);
                        MessageBox.Show("Đổi Mật Khẩu Thành Công");
                        DoiMatKhau_Load(sender, e);
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Đổi Mật Khẩu Thất Bại");
                    //}
                }
            }
            else
            {
                MessageBox.Show("Đổi Mật Khẩu Thất Bại");
            }
        }

        private void DoiMatKhau_Load(object sender, EventArgs e)
        {
            txtPassCu.Focus();
        }
    }
}
