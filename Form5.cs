using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace STOK_TAKİP_PROGRAMI
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void stokKaydıToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form6 a = new Form6();
            a.MdiParent = this;
            a.Show();
        }

        private void satışİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 a = new Form7();
            a.MdiParent = this;
            a.Show();
        }

        private void alışİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 a = new Form8();
            a.MdiParent = this;
            a.Show();
        }

        private void dağıtımİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 a = new Form9();
            a.MdiParent = this;
            a.Show();
        }
    }
}
