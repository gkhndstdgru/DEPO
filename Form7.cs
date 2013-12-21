using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ArızaTakipFinal
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip2; Integrated Security=true;");
            SqlCommand cmd = new SqlCommand();
            DataTable tablo = new DataTable();
            tablo.Clear();
            SqlDataAdapter adtr = new SqlDataAdapter("Select A.ArızaNo,A.Tarih,A.Adres,A.Sikayet,T.TalepciAd,T.TalepciSoyad,E.EkipAd from Arıza A ,ArızaTalep T,ArızaArızaTalep AT,ArızaEkip AE ,Ekip E where A.ArızaNo=AT.ArızaNo and T.TalepNo=AT.TalepNo and E.EkipNo=AE.EkipNo and A.ArızaNo=AE.ArızaNo and A.Tarih='" + dateTimePicker1.Value.ToShortDateString() + "'  ", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
           
        }
        void listele() {
            SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip2; Integrated Security=true;");
            SqlCommand cmd = new SqlCommand();
            DataTable tablo = new DataTable();
            tablo.Clear();
            SqlDataAdapter adtr = new SqlDataAdapter("Select A.ArızaNo,A.Tarih,A.Adres,A.Sikayet,T.TalepciAd,T.TalepciSoyad,E.EkipAd,I.IslemTarih,I.Acıklama from Arıza A ,ArızaTalep T,ArızaArızaTalep AT,ArızaEkip AE, Islem I,ArızaIslem AI,Ekip E where A.ArızaNo=AT.ArızaNo and T.TalepNo=AT.TalepNo and E.EkipNo=AE.EkipNo and A.ArızaNo=AE.ArızaNo and I.IslemNo=AI.IslemNo and A.ArızaNo=AI.ArızaNo and A.ArızaNo='"+dataGridView1.CurrentRow.Cells[0].Value.ToString()+"' and  A.Tarih='" + dateTimePicker2.Value.ToShortDateString() + "' ", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;    
        
        
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 frm = new Form6();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen Açıklama Giriniz !");
            }
            else
            {
                SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip2; Integrated Security=true;");
                SqlCommand cmd = new SqlCommand();

                SqlCommand cmd3 = new SqlCommand();
                cmd.Connection = baglanti;

                cmd3.Connection = baglanti;
                cmd.CommandText = "insert into Islem(Acıklama,IslemTarih) values('" + textBox1.Text + "','" + dateTimePicker1.Value.ToShortDateString() + "')";

                cmd3.CommandText = "insert into ArızaIslem(ArızaNo,IslemNo) values('" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "',(select max(IslemNo) from Islem)) ";
                baglanti.Open();

                cmd.ExecuteNonQuery();

                cmd3.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("İşlem Tamamlandı!");
                listele();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip2; Integrated Security=true;");
            SqlCommand cmd = new SqlCommand();
            DataTable tablo = new DataTable();
            tablo.Clear();
            SqlDataAdapter adtr = new SqlDataAdapter("Select A.ArızaNo,A.Tarih,A.Adres,A.Sikayet,T.TalepciAd,T.TalepciSoyad,E.EkipAd from Arıza A ,ArızaTalep T,ArızaArızaTalep AT,ArızaEkip AE,Ekip E,Islem I,ArızaIslem AI where A.ArızaNo=AT.ArızaNo and T.TalepNo=AT.TalepNo and E.EkipNo=AE.EkipNo and A.ArızaNo=AE.ArızaNo and  A.Tarih='" + dateTimePicker2.Value.ToShortDateString() + "' ", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo; 

        }
    }
}
