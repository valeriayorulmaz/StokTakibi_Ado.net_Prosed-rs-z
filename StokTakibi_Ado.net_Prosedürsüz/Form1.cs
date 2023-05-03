using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace StokTakibi_Ado.net_Prosedürsüz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=DESKTOP-8RSV7HJ\\SQLKODLAMALAB;Database=StokTakip;Integrated Security=true;");
        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand("select*from Kullanici where KullaniciAdi=@KullaniciAdi and Sifre=@Sifre", conn);
            cmd.Parameters.AddWithValue("@KullaniciAdi", textBox1.Text);
            cmd.Parameters.AddWithValue("@Sifre", textBox2.Text);
            SqlDataReader dr = cmd.ExecuteReader();


            if (dr.Read())
            {
                AnaSayfa go = new AnaSayfa();
                go.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("başarısız");
                textBox1.Clear();
                textBox2.Clear();
            }
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Kullanici ( KullaniciAdi, Sifre, TelefonNo) values (@KullaniciAdi, @Sifre,@TelefonNo )", conn);
            cmd.Parameters.AddWithValue("@KullaniciAdi", textBox3.Text);
            cmd.Parameters.AddWithValue("@Sifre", textBox4.Text);
            cmd.Parameters.AddWithValue("@TelefonNo", textBox5.Text);
            cmd.ExecuteNonQuery();
            conn.Close();

            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

        }
    }
}
