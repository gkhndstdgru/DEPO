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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip2; Integrated Security=true;");
            SqlDataAdapter adapter = new SqlDataAdapter("select E.EkipAd,A.Tarih,A.Adres,A.Sikayet,T.TalepciAd,T.TalepciSoyad,I.Acıklama,I.IslemTarih from Personel P,PersonelEkip PE,Ekip E,Arıza A,ArızaArızaTalep AT,ArızaTalep T,ArızaIslem AI,ArızaEkip AE,Islem I where PE.EkipNo=E.EkipNo and AE.ArızaNo=A.ArızaNo and PE.TcNo=P.TcNo and AE.EkipNo=E.EkipNo and AT.TalepNo=T.TalepNo and AT.ArızaNo=A.ArızaNo and AI.IslemNo=I.IslemNo and AI.ArızaNo=A.ArızaNo and P.PersonelAd='"+textBox2.Text+"' and P.PersonelSoyad='"+textBox3.Text+"' order by A.Tarih", baglanti);
            DataTable tablo = new DataTable();
            tablo.Clear();
            baglanti.Open();
            adapter.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip2; Integrated Security=true;");
            SqlDataAdapter adapter = new SqlDataAdapter("Select P.PersonelAd,P.PersonelSoyad,A.Adres,A.Sikayet,T.TalepciAd,T.TalepciSoyad,E.EkipAd,I.IslemTarih,I.Acıklama from Arıza A ,ArızaTalep T,ArızaArızaTalep AT,ArızaEkip AE, Islem I,ArızaIslem AI,Ekip E ,Personel P,PersonelEkip PE where A.ArızaNo=AT.ArızaNo and T.TalepNo=AT.TalepNo and E.EkipNo=AE.EkipNo and P.TcNo=PE.TcNo and PE.EkipNo=E.EkipNo and A.ArızaNo=AE.ArızaNo and I.IslemNo=AI.IslemNo and A.ArızaNo=AI.ArızaNo and A.Tarih='" + dateTimePicker1.Value.ToShortDateString() + "'", baglanti);
            DataTable tablo2 = new DataTable();
            tablo2.Clear();
            baglanti.Open();
            adapter.Fill(tablo2);
            dataGridView1.DataSource = tablo2;
            baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip2; Integrated Security=true;");
            SqlDataAdapter adapter = new SqlDataAdapter("Select P.PersonelAd,P.PersonelSoyad,E.EkipAd,PE.Tarih from Ekip E ,Personel P,PersonelEkip PE where   P.TcNo=PE.TcNo and PE.EkipNo=E.EkipNo  and E.EkipNo=12 and PE.Tarih='" + dateTimePicker1.Value.ToShortDateString() + "'", baglanti);
            DataTable tablo2 = new DataTable();
            tablo2.Clear();
            baglanti.Open();
            adapter.Fill(tablo2);
            dataGridView1.DataSource = tablo2;
            baglanti.Close();
        }
    }
}
