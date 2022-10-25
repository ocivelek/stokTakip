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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        void listele()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From alis", baglanti);
            adtr.Fill(st, "alis");
            dataGridView1.DataSource = st.Tables["alis"];
            adtr.Dispose();
            baglanti.Close();
        }
        void stoksayac()
        {
            int sayi = 0;
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("Select Count(barkot) from alis");
            cmd.Connection = baglanti;
            OleDbDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                sayi = Convert.ToInt16(rdr[0].ToString());
            }
            baglanti.Close();
            label4.Text = Convert.ToString(sayi);
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=giris.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet st = new DataSet();
        private void Form8_Load(object sender, EventArgs e)
        {
            listele();
            stoksayac();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            komut.Connection = baglanti;
            komut.CommandText = "Insert Into alis(barkot, stok_kodu,stok_adi,alis_fiyati,satis_fiyati, alinan_firma, alis_tarihi) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + dateTimePicker1.Text + "')";
            baglanti.Open();
            komut.ExecuteNonQuery();
            komut.Dispose();
            baglanti.Close();
            st.Clear();
            komut.Connection = baglanti;
            komut.CommandText = "Insert Into stok_kayitlari(barkot, stok_kodu,stok_adi,alis_fiyati,satis_fiyati) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
            baglanti.Open();
            komut.ExecuteNonQuery();
            komut.Dispose();
            baglanti.Close();
            st.Clear();
            listele();
            stoksayac();
        }
    }
}
