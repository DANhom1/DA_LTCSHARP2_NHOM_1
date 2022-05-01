using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class ManHinhAdmin : Form
    {
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
    }
}
