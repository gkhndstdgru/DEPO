using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArızaTakipFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Tamam_Click(object sender, EventArgs e)
        {
           
                if (textBox2.Text == "1234"&&textBox1.Text=="admin")
                {
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("Giriş Yaptınız!!");
                    Form2 frm = new Form2();
                    frm.Show();
                    this.Hide();

                }
                else {
                    MessageBox.Show("Kıllanıcı Id veya Şifre Yanlış!!");
                    textBox1.Text= " ";
                    textBox2.Text= " ";
                   
                    Form1 frm = new Form1();
                    frm.Show();
                    this.Hide();
                }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
