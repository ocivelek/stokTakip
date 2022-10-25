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
    public partial class Form1 : Form
    {

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=" + Application.StartupPath + "\\giris.accdb");
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        public static string k_adi;
        public Form1()
        {
            InitializeComponent();
        }
        string sifre;
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 a = new Form3();
            a.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                textBox2.UseSystemPasswordChar = false;
            else
                textBox2.UseSystemPasswordChar = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            con.Open();
            OleDbCommand cmd = new OleDbCommand("Select sifre from kullanicilar where k_adi='" + textBox1.Text + "'");
            cmd.Connection = con;
            OleDbDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                sifre = rdr[0].ToString();
            }
            con.Close();
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                if (textBox2.Text == sifre)
                {
                    k_adi = textBox1.Text;
                    MessageBox.Show("Giriş Başarılı :)");
                    Form4 a = new Form4();
                    a.Show();
                    this.Hide();
                }
                else
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
            }
            else
                MessageBox.Show("Lütfen boş alan girmeyiniz!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 a = new Form2();
            a.Show();
            this.Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult cvp;
            cvp = MessageBox.Show("Çıkış yapmak istediğinize emin misiniz ?", "Uyarı", MessageBoxButtons.YesNo);
            if (cvp == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
