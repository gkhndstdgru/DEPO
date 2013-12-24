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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form9_Load(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
           
            SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip2; Integrated Security=true;");
            SqlDataAdapter adapter = new SqlDataAdapter("select P.PersonelAd,P.PersonelSoyad, E.EkipAd,A.Tarih,A.Adres,A.Sikayet,T.TalepciAd,T.TalepciSoyad,I.Acıklama,I.IslemTarih from Personel P,PersonelEkip PE,Ekip E,Arıza A,ArızaArızaTalep AT,ArızaTalep T,ArızaIslem AI,ArızaEkip AE,Islem I where AE.ArızaNo=A.ArızaNo and PE.TcNo=P.TcNo and PE.EkipNo=E.EkipNo and AE.EkipNo=E.EkipNo and AT.TalepNo=T.TalepNo and AT.ArızaNo=A.ArızaNo and AI.IslemNo=I.IslemNo and AI.ArızaNo=A.ArızaNo and A.Tarih='"+frm.dateTimePicker1.Value.ToShortDateString()+"'", baglanti);
            DataTable tablo = new DataTable();
            tablo.Clear();
            baglanti.Open();
            adapter.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();
        }
    }
}
