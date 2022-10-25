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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        public static string ad;
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=giris.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet st = new DataSet();
        void listele()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From bayi", baglanti);
            adtr.Fill(st, "bayi");
            dataGridView1.DataSource = st.Tables["bayi"];
            dataGridView2.DataSource = st.Tables["bayi"];
            adtr.Dispose();
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            komut.Connection = baglanti;
            komut.CommandText = "Insert Into bayi(bayi_adi,adresi,adi,soyadi,tel_no) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
            baglanti.Open();
            komut.ExecuteNonQuery();
            komut.Dispose();
            baglanti.Close();
            komut.Connection = baglanti;
            komut.CommandText = "Create table "+textBox1.Text+" (barkot varchar(50),stok_adi varchar(20), stok_kodu int, adet int, alinan_ücret int)";
            baglanti.Open();
            komut.ExecuteNonQuery();
            komut.Dispose();
            baglanti.Close();
            st.Clear();
            listele();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 1)
            {
                ad = dataGridView2.CurrentRow.Cells["bayi_adi"].Value.ToString();
            }
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From "+ad+"", baglanti);
            adtr.Fill(st, ""+ad+"");
            dataGridView2.DataSource = st.Tables[""+ad+""];
            adtr.Dispose();
            baglanti.Close();
            label7.Text = ad + " Bayisi";
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            label12.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            textBox9.Visible = true;
            textBox10.Visible = true;
            button3.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            st.Clear();
            listele();
            label7.Text = "Bayi Seç...";
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            textBox9.Visible = false;
            textBox10.Visible = false;
            button3.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            komut.Connection = baglanti;
            komut.CommandText = "Insert Into "+ad+"(barkot,stok_adi, stok_kodu, alinan_ücret,adet) values ('" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','"+textBox10.Text+"','"+textBox9.Text+"')";
            baglanti.Open();
            komut.ExecuteNonQuery();
            komut.Dispose();
            baglanti.Close();
            st.Clear();
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From "+ad+"", baglanti);
            adtr.Fill(st, ""+ad+"");
            dataGridView2.DataSource = st.Tables[""+ad+""];
            adtr.Dispose();
            baglanti.Close();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "delete * from stok_kayitlari where barkot='" + textBox6.Text + "'";
            komut.ExecuteNonQuery();
            MessageBox.Show("Satış Başarılı");
            baglanti.Close();
        }
    }
}
