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
    public partial class ÇıktıForm : Form
    {
        public ÇıktıForm()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Server=DESKTOP-8RSV7HJ\\SQLKODLAMALAB;Database=StokTakip;Integrated Security=true;");
        private void ÇıktıForm_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select*From Ürün", conn);
            conn.Open();
            SqlDataReader dr;
            dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                comboBox2.Items.Add(dr["BarkodNo"]);
            }
            conn.Close();
        }

        public void Listele(string baglan)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(baglan, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Listele("select * from Çıktı");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Çıktı ( BarkodNo, Cins, ÇıktıAdet, ÇıkışTarihi) values (@BarkodNo, @Cins,@ÇıktıAdet, @ÇıkışTarihi)", conn);
            cmd.Parameters.AddWithValue("@BarkodNo", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Cins", comboBox1.Text);
            cmd.Parameters.AddWithValue("@ÇıktıAdet", textBox1.Text);
            cmd.Parameters.AddWithValue("@ÇıkışTarihi", Convert.ToDateTime(dateTimePicker1.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            Listele("select * from Çıktı");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Çıktı set  BarkodNo=@BarkodNo, Cins=@Cins, ÇıktıAdet=@ÇıktıAdet, ÇıkışTarihi=@ÇıkışTarihi where ÇİşlemNo=@ÇişlemNo", conn);
            cmd.Parameters.AddWithValue("@ÇİşlemNo", comboBox2.Tag);
            cmd.Parameters.AddWithValue("@BarkodNo", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Cins", comboBox1.Text);
            cmd.Parameters.AddWithValue("@ÇıktıAdet", textBox1.Text);
            cmd.Parameters.AddWithValue("@ÇıkışTarihi", Convert.ToDateTime(dateTimePicker1.Text));


            cmd.ExecuteNonQuery();
            conn.Close();
            Listele("select * from Çıktı");
        }

        private void button4_Click(object sender, EventArgs e)
        {

            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from Çıktı where ÇİşlemNo=@ÇİşlemNo", conn);
            cmd.Parameters.AddWithValue("@ÇİşlemNo", comboBox2.Tag);
            cmd.ExecuteNonQuery();
            conn.Close();
            Listele("select * from Çıktı");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            comboBox2.Tag = row.Cells["ÇİşlemNo"].Value.ToString();
            comboBox2.Text = row.Cells["BarkodNo"].Value.ToString();
            comboBox1.Text = row.Cells["Cins"].Value.ToString();
            textBox1.Text = row.Cells["ÇıktıAdet"].Value.ToString();
            dateTimePicker1.Text = row.Cells["ÇıkışTarihi"].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            SqlCommand komut = new SqlCommand("select * from Çıktı where BarkodNo like'%" + comboBox2.Text + "%'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
