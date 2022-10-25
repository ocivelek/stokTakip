using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace STOK_TAKİP_PROGRAMI
{
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=giris.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet st = new DataSet();
        public static string a;
        void listele()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From bayi", baglanti);
            adtr.Fill(st, "bayi");
            dataGridView1.DataSource = st.Tables["bayi"];
            adtr.Dispose();
            baglanti.Close();
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                groupBox5.Visible = true;
                groupBox4.Visible = false;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                groupBox4.Visible = true;
                groupBox5.Visible = false;
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                a = dataGridView1.CurrentRow.Cells["bayi_adi"].Value.ToString();
            }
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From " +a+ "", baglanti);
            adtr.Fill(st, "" +a + "");
            dataGridView1.DataSource = st.Tables["" +a+ ""];
            adtr.Dispose();
            baglanti.Close();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                // dataGridView1.ClearSelection();
                st.Clear();
            }
            else
            {
                st.Clear();
                baglanti.Open();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From "+a+" where barkot like '" + textBox4.Text + "%' ", baglanti);
                adtr.Fill(st, ""+a+"");
                dataGridView1.DataSource = st.Tables[""+a+""];
                adtr.Dispose();
                baglanti.Close();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                // dataGridView1.ClearSelection();
                st.Clear();
            }
            else
            {
                st.Clear();
                baglanti.Open();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From "+a+" where stok_kodu like '" + textBox3.Text + "%' ", baglanti);
                adtr.Fill(st, ""+a+"");
                dataGridView1.DataSource = st.Tables[""+a+""];
                adtr.Dispose();
                baglanti.Close();
            }
        }
    }
}
