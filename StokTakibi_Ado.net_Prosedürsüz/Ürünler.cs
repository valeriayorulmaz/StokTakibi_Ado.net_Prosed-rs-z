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
    public partial class Ürünler : Form
    {
        public Ürünler()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=DESKTOP-8RSV7HJ\\SQLKODLAMALAB;Database=StokTakip;Integrated Security=true;");
        public void Listele(string baglan)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(baglan, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Listele("select * from Ürün");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Ürün ( ÜrünAdı, Depo, Cins, Fiyat) values (@Ürünadı,@Depo, @Cins, @Fiyat)", conn);
            cmd.Parameters.AddWithValue("@Ürünadı", textBox2.Text);
            cmd.Parameters.AddWithValue("@Depo", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Cins", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Fiyat", textBox3.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            Listele("select * from Ürün");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Ürün set  ÜrünAdı=@ÜrünAdı, Depo=@Depo, Cins=@Cins, Fiyat=@Fiyat where BarkodNo=@BarkodNo ", conn);
            cmd.Parameters.AddWithValue("@BarkodNo", textBox1.Text);
            cmd.Parameters.AddWithValue("@Ürünadı", textBox2.Text);
            cmd.Parameters.AddWithValue("@Depo", comboBox1.Text);
            cmd.Parameters.AddWithValue("@Cins", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Fiyat", textBox3.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            Listele("select * from Ürün");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from Ürün where BarkodNo=@BarkodNo", conn);
            cmd.Parameters.AddWithValue("@BarkodNo", textBox1.Tag);
            cmd.ExecuteNonQuery();
            conn.Close();
            Listele("select * from Ürün");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Ürün where ÜrünAdı like'%" + textBox2.Text + "%'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            textBox1.Text = row.Cells["BarkodNo"].Value.ToString();
            textBox2.Text = row.Cells["ÜrünAdı"].Value.ToString();
            comboBox1.Text = row.Cells["Depo"].Value.ToString();
            comboBox2.Text = row.Cells["Cins"].Value.ToString();
            textBox3.Text = row.Cells["Fiyat"].Value.ToString();
        }
    }
}
