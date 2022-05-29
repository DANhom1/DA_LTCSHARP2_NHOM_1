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
using System.IO;
using System.Drawing.Imaging;

namespace GUI
{
    public partial class SanPham : Form
    {
        public SanPham()
        {
            InitializeComponent();
        }
        private bool isThem = false;
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

            var CBO_SIZE = (from sp in qlqa.SANPHAMs select sp.SIZE).Distinct();
            cbo_size.DataSource = CBO_SIZE;
        }

        public void nhapHinhAnh()
        {
            //BMP, GIF, JPEG, EXIF, PNG và TIFF, ICO...
            openFileDialog1.Filter = "All Image (*.jpg)|*.jpg|All Image (*.png)|*.png|All Image (*.gif)|*.gif|All Image (*.jpn)|*.jpn";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                picHA.Image = Image.FromFile(openFileDialog1.FileName.ToString());

                string[] name = openFileDialog1.FileName.Split('\\');
                string tenFile = name[name.Length - 1].ToString().Trim();

                txtAnh.Text = tenFile;
            }
        }

        public void luuHinhAnh(string tenFile)
        {
            bool kt = File.Exists(System.Windows.Forms.Application.StartupPath + "\\img\\" + tenFile);
            if (kt == false)
                picHA.Image.Save(System.Windows.Forms.Application.StartupPath + "\\img\\" + tenFile, ImageFormat.Png);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMSP.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtTenSP.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtSL.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cbo_size.SelectedItem = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtDG.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtAnh.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtNSX.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            cbo_MALSP.SelectedItem = dataGridView1.CurrentRow.Cells[7].Value.ToString();

            bool ktFileTonTai = File.Exists(System.Windows.Forms.Application.StartupPath + "\\img\\" + dataGridView1.Rows[e.RowIndex].Cells["Column5"].FormattedValue.ToString());
            if (ktFileTonTai == true)
            {
                picHA.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\" + dataGridView1.Rows[e.RowIndex].Cells["Column5"].FormattedValue.ToString() + "");
            }
            else
                anhDefault("nen7.jpg");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            SanPham sp = new SanPham();
            string url = txtAnh.Text;
            bllSP.ThemSanPham(txtTenSP.Text, int.Parse(txtSL.Text), cbo_size.SelectedValue.ToString(), float.Parse(txtDG.Text), txtAnh.Text, txtNSX.Text, cbo_MALSP.SelectedValue.ToString());
            MessageBox.Show("Thêm Sản Phẩm Thành Công");
            luuHinhAnh(url);
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
            bllSP.SuaSanPham(int.Parse(txtMSP.Text), txtTenSP.Text, int.Parse(txtSL.Text), cbo_size.SelectedValue.ToString(), float.Parse(txtDG.Text), txtAnh.Text, txtNSX.Text, cbo_MALSP.SelectedValue.ToString());
            MessageBox.Show("Sửa Sản Phẩm Thành Công");
            SanPham_Load(sender, e);
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
            dataGridView1.DataSource = bllSP.TimKiem(txtTimKiem.Text);
            
        }

        private void btnThemAnh_Click(object sender, EventArgs e)
        {
            nhapHinhAnh();
        }
        public void anhDefault(string tenFile)
        {
            picHA.Image = Image.FromFile(System.Windows.Forms.Application.StartupPath + "\\img\\" + tenFile);
            txtAnh.Text = tenFile;
        }
    }
}
