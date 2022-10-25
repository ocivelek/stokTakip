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
    public partial class Form6 : Form
    {
        public static int a = 0;
        public Form6()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=giris.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet st = new DataSet();
        void stoksayac()
        {
            int sayi=0;
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("Select Count(barkot) from stok_kayitlari");
            cmd.Connection = baglanti;
            OleDbDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                sayi = Convert.ToInt16(rdr[0].ToString());
            }
            baglanti.Close();
            label17.Text = Convert.ToString(sayi);
            a = sayi;
        }
        void listele()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From stok_kayitlari", baglanti);

            adtr.Fill(st, "stok_kayitlari");
            dataGridView1.DataSource = st.Tables["stok_kayitlari"];
            dataGridView2.DataSource = st.Tables["stok_kayitlari"];
            dataGridView3.DataSource = st.Tables["stok_kayitlari"];
            adtr.Dispose();
            baglanti.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
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

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "delete * from stok_kayitlari where barkot='" + textBox6.Text + "'";
            komut.ExecuteNonQuery();
            MessageBox.Show("Silme Başarılı");
            baglanti.Close();
            st.Clear();
            listele();
            stoksayac();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "update stok_kayitlari set barkot='" + textBox11.Text + "',stok_kodu='" + textBox12.Text + "',stok_adi='" + textBox13.Text + "',alis_fiyati='" + textBox14.Text + "',satis_fiyati='" + textBox15.Text + "' where barkot='" + textBox11.Text + "'";
            komut.ExecuteNonQuery();
            komut.Dispose();
            MessageBox.Show("Kayıt Tamamlandı.");
            baglanti.Close();
            st.Clear();
            listele();
            stoksayac();
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(13))
            {
                baglanti.Open();
                OleDbDataReader dr;
                komut.Connection = baglanti;
                komut.CommandText = "select * from stok_kayitlari";
                dr = komut.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    if (dr["barkot"].ToString() == textBox6.Text)
                    {
                        textBox7.Text = dr["stok_kodu"].ToString();
                        textBox8.Text = dr["stok_adi"].ToString();
                        textBox9.Text = dr["alis_fiyati"].ToString();
                        textBox10.Text = dr["satis_fiyati"].ToString();
                        i = 1;
                        break;
                    }
                }
                if (i == 0) MessageBox.Show("Böyle Bir Kayıt Yok.");
                {

                }
                baglanti.Close();
            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)(13))
            {
                baglanti.Open();
                OleDbDataReader dr;
                komut.Connection = baglanti;
                komut.CommandText = "select * from stok_kayitlari";
                dr = komut.ExecuteReader();
                int i = 0;
                while (dr.Read())
                {
                    if (dr["barkot"].ToString() == textBox11.Text)
                    {
                        textBox12.Text = dr["stok_kodu"].ToString();
                        textBox13.Text = dr["stok_adi"].ToString();
                        textBox14.Text = dr["alis_fiyati"].ToString();
                        textBox15.Text = dr["satis_fiyati"].ToString();
                        i = 1;
                        break;
                    }
                }
                if (i == 0) MessageBox.Show("Böyle Bir Kayıt Yok.");
                {

                }
                baglanti.Close();
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            listele();
            stoksayac();
            
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
