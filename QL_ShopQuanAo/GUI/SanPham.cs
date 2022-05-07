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

namespace GUI
{
    public partial class SanPham : Form
    {
        public SanPham()
        {
            InitializeComponent();
        }
        BLLSanPham bllSP = new BLLSanPham();
        QLQADataContext qlqa = new QLQADataContext();
        private void SanPham_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bllSP.LoadSanPham();
            var CBO_MaLSP = from sp in qlqa.LOAISPs
                            select new
                            {
                                sp.MALSP
                            };
            cbo_MALSP.DataSource = CBO_MaLSP;
            cbo_MALSP.ValueMember = "MALSP";
            cbo_MALSP.DisplayMember = "MALSP";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMSP.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTenSP.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSL.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtDG.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtNSX.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            cbo_MALSP.SelectedItem = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            bllSP.ThemSanPham(txtTenSP.Text, int.Parse(txtSL.Text), float.Parse(txtDG.Text), txtNSX.Text, cbo_MALSP.SelectedValue.ToString());
            MessageBox.Show("Thêm Sản Phẩm Thành Công");
            SanPham_Load(sender, e);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            bllSP.XoaSP(int.Parse(txtMSP.Text));
            MessageBox.Show("Xoá Sản Phẩm Thành Công");
            SanPham_Load(sender, e);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            bllSP.SuaSanPham(int.Parse(txtMSP.Text), txtTenSP.Text, int.Parse(txtSL.Text), float.Parse(txtDG.Text), txtNSX.Text, cbo_MALSP.SelectedValue.ToString());
            MessageBox.Show("Sửa Sản Phẩm Thành Công");
            SanPham_Load(sender, e);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
