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
    public partial class ThongKe : Form
    {
        QLQADataContext qlqa = new QLQADataContext();
        BLLThongKe blltk = new BLLThongKe();
        public ThongKe()
        {
            InitializeComponent();
        }
        

        private void ThongKe_Load(object sender, EventArgs e)
        {
            cbbNam.SelectedIndexChanged -= cbbNam_SelectedIndexChanged;

            var CBO_Nam = (from n in qlqa.THONGKEs select n.Nam).Distinct();
            cbbNam.DataSource = CBO_Nam;

            int namtk = int.Parse(cbbNam.SelectedValue.ToString());
            dataGridView1.DataSource = blltk.LoadThongKe(namtk);
            //using (QLQADataContext db = new QLQADataContext())
            //{
            chartDoanhThu.DataSource = blltk.LoadThongKe(namtk);
            chartDoanhThu.Series["DoanhThu"].XValueMember = "Thang";
            chartDoanhThu.Series["DoanhThu"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            chartDoanhThu.Series["DoanhThu"].YValueMembers = "DoanhThu";
            chartDoanhThu.Series["DoanhThu"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            //}
            cbbNam.SelectedIndexChanged += cbbNam_SelectedIndexChanged;
        }

        private void cbbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            int namtk = int.Parse(cbbNam.SelectedValue.ToString());
            //using (QLQADataContext db = new QLQADataContext())
            //{
                //chartDoanhThu.DataSource = db.THONGKEs.Where(t => t.Nam == namtk).ToList();
                chartDoanhThu.DataSource = blltk.LoadThongKe(namtk);
                chartDoanhThu.Series["DoanhThu"].XValueMember = "Thang";
                chartDoanhThu.Series["DoanhThu"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
                chartDoanhThu.Series["DoanhThu"].YValueMembers = "DoanhThu";
                chartDoanhThu.Series["DoanhThu"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            //}

            dataGridView1.DataSource = blltk.LoadThongKe(namtk);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
