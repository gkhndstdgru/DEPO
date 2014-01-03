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
    public partial class Form6 : Form
    {
        public Form6()
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
            if (textBox1.Text == ""  || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Lütfen Bütün Alanları Doldurun");
            }
            else
            {
                SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip2; Integrated Security=true;");

                SqlCommand cmd = new SqlCommand();

                SqlCommand cmd2 = new SqlCommand();

                SqlCommand cmd4 = new SqlCommand();
                baglanti.Open();


                cmd.Connection = baglanti;
                cmd.CommandText = "ArızaEkle";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@YeniTarih",dateTimePicker1.Value.ToShortDateString());
                cmd.Parameters.AddWithValue("@YeniAdres", textBox1.Text);
                cmd.Parameters.AddWithValue("@YeniSikayet",textBox3.Text);

                cmd2.Connection = baglanti;
                cmd2.CommandText = "TalepEkle";
                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@YeniAd",textBox4.Text);
                cmd2.Parameters.AddWithValue("@YeniSoyad", textBox5.Text);
                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();

                cmd4.Connection = baglanti;
                cmd4.CommandText = "insert into ArızaArızaTalep(ArızaNo,TalepNo) values((select MAX(ArızaNo) from Arıza  ),(select MAX(TalepNo) from  ArızaTalep ))";
                cmd4.ExecuteNonQuery();
                baglanti.Close();
                textBox1.Text = "";                
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                MessageBox.Show("   Kayit Tamamlandı !!!");

                listele();


            }
          
            
           
        }
            
        private void Form6_Load(object sender, EventArgs e)
        {
           
            comboBox1.Items.Clear();
            SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip2; Integrated Security=true;");
            SqlDataReader oku;
            SqlCommand cmd = new SqlCommand();
            DataTable tablo = new DataTable();
            tablo.Clear();
            SqlDataAdapter adtr = new SqlDataAdapter("Select A.ArızaNo, A.Tarih,A.Adres,A.Sikayet,T.TalepciAd,T.TalepciSoyad from Arıza A ,ArızaTalep T,ArızaArızaTalep AT where A.ArızaNo=AT.ArızaNo and T.TalepNo=AT.TalepNo  and A.Tarih='"+dateTimePicker1.Value.ToShortDateString()+"'", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo; 
            baglanti.Open();
            cmd.Connection = baglanti;
            cmd.CommandText = "Select *from Ekip where EkipNo!=12";
            oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku[1].ToString());
            }
           

            
            baglanti.Close();
        }
        void listele() {
            SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip2; Integrated Security=true;");
            SqlCommand cmd = new SqlCommand();
            DataTable tablo = new DataTable();
            tablo.Clear();
            SqlDataAdapter adtr = new SqlDataAdapter("Select A.ArızaNo, A.Tarih,A.Adres,A.Sikayet,T.TalepciAd,T.TalepciSoyad from Arıza A ,ArızaTalep T,ArızaArızaTalep AT where A.ArızaNo=AT.ArızaNo and T.TalepNo=AT.TalepNo  and A.Tarih='" + dateTimePicker1.Value.ToShortDateString() + "'", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
        
    }
        void Listele1() {
            SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip2; Integrated Security=true;");
            SqlCommand cmd = new SqlCommand();
            DataTable tablo = new DataTable();
            tablo.Clear();
            SqlDataAdapter adtr = new SqlDataAdapter("Select A.ArızaNo,A.Tarih,A.Adres,A.Sikayet,T.TalepciAd,T.TalepciSoyad,E.EkipAd from Arıza A ,ArızaTalep T,ArızaArızaTalep AT,ArızaEkip AE ,Ekip E where A.ArızaNo=AT.ArızaNo and T.TalepNo=AT.TalepNo and E.EkipNo=AE.EkipNo and A.ArızaNo=AE.ArızaNo and A.Tarih='"+dateTimePicker1.Value.ToShortDateString()+"' ", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
        
        
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip2; Integrated Security=true;");

                SqlCommand cmd = new SqlCommand();

                cmd.Connection = baglanti;

                if (Convert.ToString(comboBox1.SelectedItem.ToString()) == "Merkez1")
                {

                    cmd.CommandText = "insert into ArızaEkip(ArızaNo,EkipNo) values('" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "',7)";
                    baglanti.Open();

                    cmd.ExecuteNonQuery();
                    Listele1();
                    baglanti.Close();

                }
                else if (Convert.ToString(comboBox1.SelectedItem.ToString()) == "Merkez2")
                {
                    cmd.CommandText = "insert into ArızaEkip(ArızaNo,EkipNo) values('" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "',8)";
                    baglanti.Open();

                    cmd.ExecuteNonQuery();
                    Listele1();
                    baglanti.Close();

                }
                else if (Convert.ToString(comboBox1.SelectedItem.ToString()) == "Merkez3")
                {

                    cmd.CommandText = "insert into ArızaEkip(ArızaNo,EkipNo) values('" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "',9)";
                    baglanti.Open();

                    cmd.ExecuteNonQuery();
                    Listele1();
                    baglanti.Close();
                }
                else if (Convert.ToString(comboBox1.SelectedItem.ToString()) == "Merkez4")
                {

                    cmd.CommandText = "insert into ArızaEkip(ArızaNo,EkipNo) values('" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "',10)";
                    baglanti.Open();

                    cmd.ExecuteNonQuery();
                    Listele1();
                    baglanti.Close();
                }
                else if (Convert.ToString(comboBox1.SelectedItem.ToString()) == "Merkez5")
                {
                    cmd.CommandText = "insert into ArızaEkip(ArızaNo,EkipNo) values('" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "',11)";
                    baglanti.Open();

                    cmd.ExecuteNonQuery();
                    Listele1();
                    baglanti.Close();
                }
            }
            catch {
                MessageBox.Show("Lütfen Ekibi Seçiniz !");
            }
           
            //listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show("Personeli Silmek istediginizden Eminmisiniz?", "Uyarı!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip2; Integrated Security=true;");
                SqlCommand cmd = new SqlCommand("DELETE FROM Arıza Where ArızaNo= '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", baglanti);
                SqlCommand cmd1 = new SqlCommand("delete from Islem from Islem I inner join ArızaIslem AI on I.IslemNo=AI.IslemNo where AI.ArızaNo='"+dataGridView1.CurrentRow.Cells[0].Value.ToString()+"'",baglanti);
                SqlCommand cmd2 = new SqlCommand("delete from ArızaTalep from ArızaTalep A inner join ArızaArızaTalep AT on A.TalepNo=AT.TalepNo where AT.ArızaNo='"+dataGridView1.CurrentRow.Cells[0].Value.ToString()+"'",baglanti);
                
                baglanti.Open();
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd.ExecuteNonQuery();     
                 
                baglanti.Close();

                MessageBox.Show("ARIZA SİLİNDİ !!!");
                listele();

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form7 frm = new Form7();
            frm.Show();
            this.Hide();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
