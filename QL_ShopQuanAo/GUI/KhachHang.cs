using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using BLL;
using DTO;
using BUS;

namespace GUI
{
    public partial class KhachHang : Form
    {
        public KhachHang()
        {
            InitializeComponent();
        }
        BLLKhachHang bllkh = new BLLKhachHang();
        BUSKhachHang kh = new BUSKhachHang();
        
        public bool IsValidVietNamPhoneNumber(string phoneNum)
        {
            if (string.IsNullOrEmpty(phoneNum))
                return false;
            string sMailPattern = @"^((09(\d){8})|(03(\d){8})|(08(\d){8})|(07(\d){8})|(05(\d){8}))$";
            return Regex.IsMatch(phoneNum.Trim(), sMailPattern);
        }
        private void KhachHang_Load(object sender, EventArgs e)
        {
            dtv_khachhang.DataSource = bllkh.LoadKH();
        }

        private void txt_sdt_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_diem_TextChanged(object sender, EventArgs e)
        {
            if (txt_diem.Text.Length > 0)
            {
                char phantucuoi = txt_diem.Text[txt_diem.Text.Length - 1];
                if (char.IsDigit(phantucuoi) == false)
                {
                    MessageBox.Show("Bạn nhập không phải số");
                    txt_diem.Text = "";
                    txt_diem.Focus();
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txt_sdt.Text.Length == 0 || txt_diem.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin trước khi thêm!");
                return;
            }
            if (IsValidVietNamPhoneNumber(txt_sdt.Text) == false)
            {
                MessageBox.Show("Số điện thoại sai định dạng!");
                return;
            }
            if (kh.kiemtraKC(txt_sdt.Text) == false)
            {
                MessageBox.Show("Khách hàng này đã tồn tại!");
                return;
            }
            else
            {
                bllkh.ThemKH(txt_sdt.Text, int.Parse(txt_diem.Text));
                KhachHang_Load(sender, e);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn muốn xóa?", "Thông báo",
                               MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                               MessageBoxDefaultButton.Button2) ==

                               System.Windows.Forms.DialogResult.Yes)
            {
                if (txt_sdt.Text == string.Empty)
                {
                    MessageBox.Show("Mã không được rỗng");
                    return;
                }
                if (kh.kiemtraKN(txt_sdt.Text) == false)
                {
                    MessageBox.Show("Khách hàng không thể xóa vì có dữ liệu trên hóa đơn");
                    return;
                }
                else
                {
                    bllkh.XoaKH(txt_sdt.Text);
                    KhachHang_Load(sender, e);
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txt_sdt.Text.Length == 0 || txt_diem.Text.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }
            if (IsValidVietNamPhoneNumber(txt_sdt.Text))
            {
                MessageBox.Show("Số điện thoại sai định dạng!");
                return;
            }
            if (kh.kiemtraKC(txt_sdt.Text) == true)
            {
                MessageBox.Show("Khách hàng này ko tồn tại!");
                return;
            }
            else
            {
                bllkh.SuaKH(txt_sdt.Text, int.Parse(txt_diem.Text));
                KhachHang_Load(sender, e);
            }
        }

        private void dtv_khachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtv_khachhang_SelectionChanged(object sender, EventArgs e)
        {
            txt_sdt.Text = dtv_khachhang.CurrentRow.Cells[0].Value.ToString();
            txt_diem.Text = dtv_khachhang.CurrentRow.Cells[1].Value.ToString();
        }
    }
}
