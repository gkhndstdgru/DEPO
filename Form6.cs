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
            SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip; Integrated Security=true;");

            SqlCommand cmd = new SqlCommand("Insert Into Arıza(Adres,Tarih,Sikayet) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')", baglanti);
            SqlCommand cmd2 = new SqlCommand("Insert Into ArızaTalep(TalepciAd,TalepciSoyad) values('" + textBox4.Text + "','" + textBox5.Text + "')", baglanti);
            baglanti.Open();
            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();
            MessageBox.Show("   kayit tamamlandi !!!");
            baglanti.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            listele();

            
           
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            
            comboBox1.Items.Clear();
            SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip; Integrated Security=true;");
            SqlDataReader oku;
            SqlCommand cmd = new SqlCommand();
            DataTable tablo = new DataTable();
            tablo.Clear();
            SqlDataAdapter adtr = new SqlDataAdapter("Select *from Arıza ", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo; 
            baglanti.Open();
            cmd.Connection = baglanti;
            cmd.CommandText = "Select *from Ekip";
            oku = cmd.ExecuteReader();
            while (oku.Read())
            {
                comboBox1.Items.Add(oku[1].ToString());
            }
           

            
            baglanti.Close();
        }
        void listele() {
            SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip; Integrated Security=true;");
            SqlCommand cmd = new SqlCommand();
            DataTable tablo = new DataTable();
            tablo.Clear();
            SqlDataAdapter adtr = new SqlDataAdapter("Select *from Arıza ", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;     
        
        
        
        
        }
        private void button3_Click(object sender, EventArgs e)
        {
           
            SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip; Integrated Security=true;");
            SqlCommand cmd3=new SqlCommand();
            cmd3.Connection = baglanti;

            if (Convert.ToString(comboBox1.SelectedItem.ToString()) == "Merkez1")
            {
                cmd3.CommandText = "update Arıza  set EkipNo=1 where ArızaNo='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() +"'";

                baglanti.Open();
                cmd3.ExecuteNonQuery();
                baglanti.Close();
            }
            else if (Convert.ToString(comboBox1.SelectedItem.ToString()) == "Merkez2")
            {
                cmd3.CommandText = "update Arıza set EkipNo=2 where ArızaNo='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "' ";

                baglanti.Open();
                cmd3.ExecuteNonQuery();
                baglanti.Close();
            }
            else if (Convert.ToString(comboBox1.SelectedItem.ToString()) == "Merkez3")
            {
                cmd3.CommandText = "update Arıza set EkipNo=3 where ArızaNo='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";

                baglanti.Open();
                cmd3.ExecuteNonQuery();
                baglanti.Close();
            }
            else if (Convert.ToString(comboBox1.SelectedItem.ToString()) == "Merkez4")
            {
                cmd3.CommandText = "update Arıza  set EkipNo=4 where ArızaNo='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";

                baglanti.Open();
                cmd3.ExecuteNonQuery();
                baglanti.Close();
            }
            else if (Convert.ToString(comboBox1.SelectedItem.ToString()) == "Merkez5")
            {
                cmd3.CommandText = "update Arıza  set EkipNo=5 where ArızaNo='" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                baglanti.Open();
                cmd3.ExecuteNonQuery();
                baglanti.Close();
            }
            listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show("Personeli Silmek istediginizden Eminmisiniz?", "Uyarı!!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip; Integrated Security=true;");

                baglanti.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Arıza Where ArızaNo= '" + dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'", baglanti);
                cmd.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("ARIZA SİLİNDİ !!!");
                listele();

            }
        }
    }
}
