﻿using System;
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
    public partial class ManHinhAdmin : Form
    {
        
        BLLTaiKhoan bllTK = new BLLTaiKhoan();
        QLQADataContext qlqa = new QLQADataContext();
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
            //BLLTaiKhoan bll = new BLLTaiKhoan();
            MessageBox.Show("Xin Chào: " + taikhoan.TENTK);
            label1.Text = String.Format("QUẢN LÝ: {0}", taikhoan.TENTK);
            ThongTinTaiKhoan.matk = taikhoan.MATK;
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
    }
}
