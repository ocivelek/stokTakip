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
    public partial class Form3 : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=" + Application.StartupPath + "\\giris.accdb");
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        public Form3()
        {
            InitializeComponent();
        }
        string gsoru, cevap, sifre;
        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand("Select sifre,g_soru,cevap from kullanicilar where k_adi='" + textBox3.Text + "'");
            cmd.Connection = con;
            OleDbDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                sifre = rdr[0].ToString();
                gsoru = rdr[1].ToString();
                cevap = rdr[2].ToString();
            }
            con.Close();
            textBox4.Text = gsoru;
            textBox4.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            textBox5.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == cevap)
            {
                MessageBox.Show("Şifreniz=" + sifre);
            }
            else
                MessageBox.Show("Cevabınız Yanlış");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }
    }
}
