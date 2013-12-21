using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.Sql;

namespace ArızaTakipFinal
{
    public partial class Form4 : Form
    {

        public Form4()
        {
            InitializeComponent();
            SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip2; Integrated Security=true;");
            

            DataTable tablo = new DataTable();
            //DataTable tablo2 = new DataTable();
            tablo.Clear();
            //tablo2.Clear();           
            SqlDataAdapter adtr = new SqlDataAdapter("Select *from Personel ", baglanti);            
            //SqlDataAdapter adtr2 = new SqlDataAdapter("select PersonelAd,PersonelSoyad,TcNo,EkipAd from Personel P, Ekip E, where P.EkipNo=E.EkipNo", baglanti);
            adtr.Fill(tablo);
            //adtr2.Fill(tablo2);
            dataGridView1.DataSource =tablo;
            //dataGridView2.DataSource = tablo2;
           
            
           
            
            

        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip2; Integrated Security=true;");


                SqlCommand cmd1 = new SqlCommand();

                cmd1.Connection = baglanti;
                if (Convert.ToString(comboBox1.SelectedItem.ToString()) == "Merkez1")
                {



                    cmd1.CommandText = "insert into PersonelEkip(TcNo,EkipNo,Tarih) values('" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "',7,'" + dateTimePicker1.Value.ToShortDateString() + "')";
                    baglanti.Open();

                    cmd1.ExecuteNonQuery();
                    baglanti.Close();
                }
                else if (Convert.ToString(comboBox1.SelectedItem.ToString()) == "Merkez2")
                {



                    cmd1.CommandText = "insert into PersonelEkip(TcNo,EkipNo,Tarih) values('" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "',8,'" + dateTimePicker1.Value.ToShortDateString() + "')";
                    baglanti.Open();

                    cmd1.ExecuteNonQuery();
                    baglanti.Close();
                }
                else if (Convert.ToString(comboBox1.SelectedItem.ToString()) == "Merkez3")
                {

                    cmd1.CommandText = "insert into PersonelEkip(TcNo,EkipNo,Tarih) values('" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "',9,'" + dateTimePicker1.Value.ToShortDateString() + "')";
                    baglanti.Open();

                    cmd1.ExecuteNonQuery();
                    baglanti.Close();
                }
                else if (Convert.ToString(comboBox1.SelectedItem.ToString()) == "Merkez4")
                {

                    cmd1.CommandText = "insert into PersonelEkip(TcNo,EkipNo,Tarih) values('" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "',10,'" + dateTimePicker1.Value.ToShortDateString() + "')";
                    baglanti.Open();

                    cmd1.ExecuteNonQuery();
                    baglanti.Close();
                }
                else if (Convert.ToString(comboBox1.SelectedItem.ToString()) == "Merkez5")
                {

                    cmd1.CommandText = "insert into PersonelEkip(TcNo,EkipNo,Tarih) values('" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "',11,'" + dateTimePicker1.Value.ToShortDateString() + "')";
                    baglanti.Open();

                    cmd1.ExecuteNonQuery();
                    baglanti.Close();
                }
                else if (Convert.ToString(comboBox1.SelectedItem.ToString()) == "İzinli")
                {

                    cmd1.CommandText = "insert into PersonelEkip(TcNo,EkipNo,Tarih) values('" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "',12,'" + dateTimePicker1.Value.ToShortDateString() + "')";
                    baglanti.Open();

                    cmd1.ExecuteNonQuery();
                    baglanti.Close();
                }
            }
            catch {
                MessageBox.Show("Lütfen Ekibi Seçiniz!");
            
            }
            //listele();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            this.Hide();

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
           
            comboBox1.Items.Clear();
            SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip2; Integrated Security=true;");
            SqlDataReader oku;
            SqlCommand cmd = new SqlCommand();
            SqlCommand cmd2 = new SqlCommand();
            baglanti.Open();                     
            cmd.Connection = baglanti;
            cmd.CommandText = "Select *from Ekip";
            oku=cmd.ExecuteReader();            
            while (oku.Read()) {
                comboBox1.Items.Add(oku[1].ToString());           
            }
            baglanti.Close();
            

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listele();
        }
        void listele() {
            SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip2; Integrated Security=true;");
          
            DataTable tablo = new DataTable();
            DataTable tablo2 = new DataTable();
            tablo2.Clear();
            tablo.Clear();
            SqlDataAdapter adtr = new SqlDataAdapter("Select *from Personel ", baglanti);
            SqlDataAdapter adtr2 = new SqlDataAdapter("select P.PersonelAd,P.PersonelSoyad,P.TcNo,E.EkipAd from Personel P, Ekip E,PersonelEkip PE where P.TcNo=PE.TcNo and E.EkipNo=PE.EkipNo and PE.Tarih='"+dateTimePicker1.Value.ToShortDateString()+"' ", baglanti);
            adtr2.Fill(tablo2);
            dataGridView2.DataSource = tablo2;
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show("Personeli Silmek istediginizden Eminmisiniz?", "Uyarı!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip2; Integrated Security=true;");
                if (dataGridView1.CurrentRow.Cells[3].Value.ToString()=="Merkez1")
                {
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM PersonelEkip Where TcNo= '" + dataGridView2.CurrentRow.Cells[2].Value.ToString() + "' and EkipNo=7 and Tarih='"+dateTimePicker1.Value.ToShortDateString()+"'", baglanti);
                    cmd.ExecuteNonQuery();
                    baglanti.Close();
                }
                else if (dataGridView1.CurrentRow.Cells[3].Value.ToString()=="Merkez2")
                {
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM PersonelEkip Where TcNo= '" + dataGridView2.CurrentRow.Cells[2].Value.ToString() + "' and EkipNo=8 and Tarih='" + dateTimePicker1.Value.ToShortDateString() + "'", baglanti);
                    cmd.ExecuteNonQuery();
                    baglanti.Close();
                }
                else if (dataGridView1.CurrentRow.Cells[3].Value.ToString()=="Merkez3")
                {
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM PersonelEkip Where TcNo= '" + dataGridView2.CurrentRow.Cells[2].Value.ToString() + "' and EkipNo=9 and Tarih='" + dateTimePicker1.Value.ToShortDateString() + "'", baglanti);
                    cmd.ExecuteNonQuery();
                    baglanti.Close();
                }
                else if (dataGridView1.CurrentRow.Cells[3].Value.ToString()=="Merkez4")
                {
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM PersonelEkip Where TcNo= '" + dataGridView2.CurrentRow.Cells[2].Value.ToString() + "' and EkipNo=10 and Tarih='" + dateTimePicker1.Value.ToShortDateString() + "'", baglanti);
                    cmd.ExecuteNonQuery();
                    baglanti.Close();
                }
                else if (dataGridView1.CurrentRow.Cells[3].Value.ToString()=="Merkez5")
                {
                    baglanti.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM PersonelEkip Where TcNo= '" + dataGridView2.CurrentRow.Cells[2].Value.ToString() + "' and EkipNo=11 and Tarih='" + dateTimePicker1.Value.ToShortDateString() + "'", baglanti);
                    cmd.ExecuteNonQuery();
                    baglanti.Close();
                }
                MessageBox.Show("Ekipten Çıkarıldı !");
                listele();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip2; Integrated Security=true;");
            SqlDataAdapter adapter = new SqlDataAdapter("select *from Personel where PersonelAd LIKE '%" + textBox1.Text + "%'", baglanti);
            DataTable tablo = new DataTable();
            tablo.Clear();
            baglanti.Open();
            adapter.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }


        }
        }

        
