using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
using System.Data.Common;

namespace GUI
{
    public partial class HoaDon : Form
    {
        BLLHoaDon bllhoadon = new BLLHoaDon();
        QLQADataContext qlqa = new QLQADataContext();
        public HoaDon()
        {
            InitializeComponent();
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bllhoadon.LoadHoaDon();

            var CBO_MaNV = from hd in qlqa.NHANVIENs
                           select new
                           {
                               hd.MANV
                           };
            cb_manv.DataSource =  CBO_MaNV;
            cb_manv.ValueMember = "MaNV";
            cb_manv.DisplayMember = "MaNV";

            var CBO_MaKH = from hd in qlqa.KHACHHANGs
                           select new
                           {
                               hd.MAKH
                           };
            cbo_MaKH.DataSource = CBO_MaKH;
            cbo_MaKH.ValueMember = "MaKH";
            cbo_MaKH.DisplayMember = "MaKH";

            var CBO_TT = (from hd in qlqa.HOADONs select hd.TINHTRANG).Distinct();
                         //select new
                         //{
                         //    hd.TINHTRANG
                         //};
            CBo_TT.DataSource = CBO_TT;
            //CBo_TT.ValueMember = "TINHTRANG";
            //CBo_TT.DisplayMember = "TINHTRANG";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string dtp = dtpNT.Value.ToString();
            if (txtmaHD.Text.Trim() == "")
            {
                MessageBox.Show("Không được bỏ trống Mã Hoá Đơn");
            }
            //else if (bllhoadon.ktMaHD(int.Parse(txtmaHD.Text)) > 0)
            //{
            //    MessageBox.Show("Đã có Mã Hoá Đơn này");
            //}
            else
            {
                bllhoadon.ThemHoaDon(dtp, float.Parse(txt_THHTOAN.Text), CBo_TT.SelectedValue.ToString(), cbo_MaKH.SelectedValue.ToString(), cb_manv.SelectedValue.ToString());
                MessageBox.Show("Thêm Hoá Đơn Thành Công");
                HoaDon_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bllhoadon.XoaHoaDon(int.Parse(txtmaHD.Text));
            MessageBox.Show("Xoá Hoá Đơn Thành Công");
            HoaDon_Load(sender, e);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmaHD.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            //dtpNT.Value.ToString("dd/MM/yyyy")= dataGridView1.CurrentRow.Cells[1].Value.ToString();
            DateTime datens = DateTime.Parse(dataGridView1.CurrentRow.Cells[1].Value.ToString());
            dtpNT.Value = DateTime.Parse(datens.ToShortDateString());
            txt_THHTOAN.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            CBo_TT.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            cbo_MaKH.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            cb_manv.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string dtp = dtpNT.Value.ToString();
            bllhoadon.SuaHoaDon(int.Parse(txtmaHD.Text), dtp, float.Parse(txt_THHTOAN.Text), CBo_TT.SelectedValue.ToString(), cbo_MaKH.SelectedValue.ToString(), cb_manv.SelectedValue.ToString());
            MessageBox.Show("Sửa Hoá Đơn Thành Công");
            HoaDon_Load(sender, e);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if(txtTimKiem.TextLength==0)
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm!");
                txtTimKiem.Focus();
            }
                dataGridView1.DataSource = bllhoadon.TimKiem(txtTimKiem.Text);
            }
        }
    }
