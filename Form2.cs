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
using System.IO;

namespace STOK_TAKİP_PROGRAMI
{
    public partial class Form2 : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=" + Application.StartupPath + "\\giris.accdb");
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        public static string ryol;
        public Form2()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "insert into kullanicilar (ad,soyad,k_adi,sifre,pozisyon,g_soru,cevap,r_yolu) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox5.Text + "','"+ryol+"')";
            cmd.ExecuteNonQuery();
            con.Close(); MessageBox.Show("Kayıt Tamamlandı.");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Text = "Pozisyon Seç...";
            comboBox2.Text = "Soru Seç...";
            textBox5.Text = "";

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.Filter = "JPEG Files(*.jpg;*.jpeg;*.jpe;*.jfif)|*.jpg|All Files(*.*)|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                    ryol = openFileDialog1.FileName.ToString();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
    }
}
