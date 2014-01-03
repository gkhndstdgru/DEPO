using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

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
            SqlDataAdapter adapter = new SqlDataAdapter("select P.PersonelAd,P.PersonelSoyad, E.EkipAd,A.Tarih,A.Adres,A.Sikayet,T.TalepciAd,T.TalepciSoyad from Personel P,PersonelEkip PE,Ekip E,Arıza A,ArızaArızaTalep AT,ArızaTalep T,ArızaEkip AE where AE.ArızaNo=A.ArızaNo and PE.TcNo=P.TcNo and PE.EkipNo=E.EkipNo and AE.EkipNo=E.EkipNo and AT.TalepNo=T.TalepNo and AT.ArızaNo=A.ArızaNo and A.Tarih='"+frm.dateTimePicker1.Value.ToShortDateString()+"' and PE.Tarih='"+frm.dateTimePicker1.Value.ToShortDateString()+"'", baglanti);
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Pesquisar_Items pesquisar = new Pesquisar_Items();

                var client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("gkhn.dostdogru@gmail.com", "pes1991gkhn");

                var mail = new MailMessage();
                mail.From = new MailAddress("gkhn.dostdogru@gmail.com");
                mail.To.Add("ayazici@ogu.edu.tr");
                mail.IsBodyHtml = true;
                mail.Subject = "Günlük Arıza Bilgileri";

                string mailBody = "<table width='100%' style='border:Solid 1px Black;'>"; ;

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    mailBody += "<tr>";
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        mailBody += "<td>" + cell.Value + "</td>";
                    }
                    mailBody += "</tr>";
                }
                mailBody += "</table>";

                //your rest of the original code
                mail.Body = mailBody;
                client.Send(mail);
                MessageBox.Show("Email Gönderildi!");
            }
            catch 
            {
                MessageBox.Show("Email göderilemedi !");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form9_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
