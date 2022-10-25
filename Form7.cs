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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        void listele()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From satis", baglanti);
            adtr.Fill(st, "satis");
            dataGridView1.DataSource = st.Tables["satis"];
            adtr.Dispose();
            baglanti.Close();
        }
        void stoksayac()
        {
            int sayi = 0;
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("Select Count(barkot) from satis");
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
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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
                    if (dr["barkot"].ToString() == textBox1.Text)
                    {
                        textBox2.Text = dr["stok_kodu"].ToString();
                        textBox3.Text = dr["stok_adi"].ToString();
                        textBox4.Text = dr["alis_fiyati"].ToString();
                        textBox5.Text = dr["satis_fiyati"].ToString();
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

        private void Form7_Load(object sender, EventArgs e)
        {
            listele();
            stoksayac();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           /* string isim;
            baglanti.Open();
            OleDbCommand cmd = new OleDbCommand("Select bayi_adi from bayi");
            cmd.Connection = baglanti;
            OleDbDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                isim = rdr["bayi_adi"].ToString();
                if (isim == textBox6.Text)
                {
                    komut.Connection = baglanti;
                    komut.CommandText = "Insert Into " + textBox6.Text + "(barkot,stok_adi, stok_kodu, alinan_ücret,adet) values ('" + textBox1.Text + "','" + textBox3.Text + "','" + textBox2.Text + "','" + textBox5.Text + "','1')";
                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    komut.Dispose();
                    baglanti.Close();
                }
               
            }
            baglanti.Close();*/
            komut.Connection = baglanti;
            komut.CommandText = "Insert Into satis(barkot, stok_kodu,stok_adi,alis_fiyati,satis_fiyati, satilan_firma, s_tarihi) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','"+textBox6.Text+"','"+dateTimePicker1.Text+"')";
            baglanti.Open();
            komut.ExecuteNonQuery();
            komut.Dispose();
            baglanti.Close();
            st.Clear();    
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "delete * from stok_kayitlari where barkot='" + textBox1.Text + "'";
            komut.ExecuteNonQuery();
            MessageBox.Show("Satış Başarılı");
            baglanti.Close();
            st.Clear();
            listele();
            stoksayac();
            /*try
            {
               
            }
            catch (Exception hata)
            {
                
            }*/

        }
    }
}
