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
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Threading;


namespace STOK_TAKİP_PROGRAMI
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=giris.accdb");
        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet st = new DataSet();

        SpeechSynthesizer syht = new SpeechSynthesizer();
        PromptBuilder build = new PromptBuilder();
        SpeechRecognitionEngine recognize = new SpeechRecognitionEngine();
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = false;
            }
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
            label2.Text = Convert.ToString(sayi);
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                groupBox2.Visible = true;
                groupBox1.Visible = false;
            }
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            listele();
            stoksayac();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                // dataGridView1.ClearSelection();
                st.Clear();
            }
            else
            {
                st.Clear();
                baglanti.Open();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From satis where barkot like '" + textBox1.Text + "%' ", baglanti);
                adtr.Fill(st, "satis");
                dataGridView1.DataSource = st.Tables["satis"];
                adtr.Dispose();
                baglanti.Close();
                stoksayac();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                // dataGridView1.ClearSelection();
                st.Clear();
            }
            else
            {
                st.Clear();
                baglanti.Open();
                OleDbDataAdapter adtr = new OleDbDataAdapter("Select * From satis where stok_kodu like '" + textBox2.Text + "%' ", baglanti);
                adtr.Fill(st, "satis");
                dataGridView1.DataSource = st.Tables["satis"];
                adtr.Dispose();
                baglanti.Close();
                stoksayac();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            build.ClearContent();
            build.AppendText(label2.Text);
            syht.Speak(build);
        }
    }
}
