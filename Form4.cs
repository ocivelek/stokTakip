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
    public partial class Form4 : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=" + Application.StartupPath + "\\giris.accdb");
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        public Form4()
        {
            InitializeComponent();
        }
        string ad, soyad, yetki,r_yolu;
        private void button8_Click(object sender, EventArgs e)

        {
            DialogResult cvp;
            cvp = MessageBox.Show("Oturumu kapatmak istediğinize eeeemin misiniz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cvp == DialogResult.Yes)
            {
                Form1 a = new Form1();
                a.Show();
                this.Hide();
            }
            else
            {
                
            }

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand("Select ad,soyad,pozisyon,r_yolu from kullanicilar where k_adi='" + Form1.k_adi + "'");
            cmd.Connection = con;
            OleDbDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                ad = rdr[0].ToString();
                soyad = rdr[1].ToString();
                yetki = rdr[2].ToString();
                r_yolu = rdr[3].ToString();
            }
            con.Close();
            label5.Text = ad;
            label6.Text = soyad;
            label7.Text = yetki;
            pictureBox1.ImageLocation = (r_yolu);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 a = new Form5();
            this.Visible = false;
            a.ShowDialog();
            this.Visible = true;
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult cvp;
            cvp = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cvp == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form9 a = new Form9();
            this.Visible = false;
            a.ShowDialog();
            this.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form10 a = new Form10();
            this.Visible = false;
            a.ShowDialog();
            this.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form11 a = new Form11();
            this.Visible = false;
            a.ShowDialog();
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form12 a = new Form12();
            this.Visible = false;
            a.ShowDialog();
            this.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form13 a = new Form13();
            this.Visible = false;
            a.ShowDialog();
            this.Visible = true;
        }
    }
}
