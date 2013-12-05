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
            SqlConnection baglanti = new SqlConnection("Data source=DOSTDOGRU\\SQLEXPRESS; Initial Catalog=ArızaTakip; Integrated Security=true;");

            SqlCommand cmd = new SqlCommand("Insert Into Personel(PersonelAd,PersonelSoyad,TcNo,TelNo) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", baglanti);
            baglanti.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("   kayit tamamlandi !!!");
            baglanti.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}
