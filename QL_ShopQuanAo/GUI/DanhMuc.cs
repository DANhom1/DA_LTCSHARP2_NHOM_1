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
using System.Data.Linq;
namespace GUI
{
    public partial class DanhMuc : Form
    {
        BLLDanhMuc blldanhmuc = new BLLDanhMuc();
        QLQADataContext qlqa = new QLQADataContext();
        public DanhMuc()
        {
            InitializeComponent();
        }

        private void DanhMuc_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = blldanhmuc.LoadDanhMuc();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtTenDM.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            else
            {
                blldanhmuc.ThemDanhMuc(txtTenDM.Text);
                MessageBox.Show("Thêm Thành Công");
                DanhMuc_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            blldanhmuc.XoaDanhMuc(int.Parse(txtMaDM.Text));
            MessageBox.Show("Xoá Thành Công");
            DanhMuc_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            blldanhmuc.SuaDanhMuc(int.Parse(txtMaDM.Text),txtTenDM.Text);
            MessageBox.Show("Sửa Thành Công");
            DanhMuc_Load(sender, e);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaDM.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTenDM.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            txtMaDM.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
