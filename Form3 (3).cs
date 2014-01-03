using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ArızaTakipFinal
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip2; Integrated Security=true;");

                SqlCommand cmd2 = new SqlCommand();
                cmd2.Connection = baglanti;
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Lütfen Alanları Eksiksiz Doldurun");
                }
              
                
                else
                {

                   
                    baglanti.Open();
                    cmd2.CommandText = "PersonelEkle";
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.AddWithValue("@YeniAd",textBox1.Text);
                    cmd2.Parameters.AddWithValue("@YeniSoyad", textBox2.Text);
                    cmd2.Parameters.AddWithValue("@YeniTcNo", textBox3.Text);
                    cmd2.Parameters.AddWithValue("@YeniTelNo", textBox4.Text);
                    cmd2.ExecuteNonQuery();
                    
                    MessageBox.Show("   kayit tamamlandi !!!");
                    baglanti.Close();
                    listele();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
            }
            catch{
                MessageBox.Show("Bu TC Kimlik Numarasına Ait personel Bulunmaktadır !");
            
            }

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip2; Integrated Security=true;");
           
            DataTable tablo = new DataTable();
            tablo.Clear();
            SqlDataAdapter adtr = new SqlDataAdapter("Select *from Personel ", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;   
        }
        void listele() {
            SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip2; Integrated Security=true;");
            SqlDataAdapter adapter = new SqlDataAdapter("select *from Personel", baglanti);
            DataTable tablo = new DataTable();
            tablo.Clear();
            baglanti.Open();
            adapter.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        
        
        
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show("Personeli Silmek istediginizden Eminmisiniz?", "Uyarı!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip2; Integrated Security=true;");

                baglanti.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Personel Where TcNo= '" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'", baglanti);
                cmd.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("KİŞİ SİLİNDİ !!!");
                listele();

            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip2; Integrated Security=true;");
            SqlDataAdapter adapter = new SqlDataAdapter("select *from Personel where PersonelAd LIKE '%"+ textBox5.Text +"%'", baglanti);
            DataTable tablo = new DataTable();
            tablo.Clear();
            baglanti.Open();
            adapter.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip2; Integrated Security=true;");

        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

       
    }


}
