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
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            
        }

    }
}
