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
    public partial class GirdiForm : Form
    {
        public GirdiForm()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=DESKTOP-8RSV7HJ\\SQLKODLAMALAB;Database=StokTakip;Integrated Security=true;");
        private void GirdiForm_Load(object sender, EventArgs e)
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
            Listele("select * from Girdi");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //conn.Open();

            //SqlCommand cmd = new SqlCommand("select*from Ürün where BarkodNo=@BarkodNo and Cins=@Cins", conn);
            //cmd.Parameters.AddWithValue("@BarkodNo", comboBox2.Text);
            //cmd.Parameters.AddWithValue("@Cins", comboBox1.Text);
            //SqlDataReader dr = cmd.ExecuteReader();


            //if (dr.Read())
            //{
            //    MessageBox.Show("okudu");
            //    SqlCommand cmd1 = new SqlCommand("insert into Girdi ( BarkodNo, Cins, GirdiAdet, GirişTarihi) values (@BarkodNo, @Cins,@GirdiAdet, @GirişTarihi)", conn);
            //    cmd1.Parameters.AddWithValue("@BarkodNo", comboBox2.Text);
            //    cmd1.Parameters.AddWithValue("@Cins", comboBox1.Text);
            //    cmd1.Parameters.AddWithValue("@GirdiAdet", textBox1.Text);
            //    cmd1.Parameters.AddWithValue("@GirişTarihi", Convert.ToDateTime(dateTimePicker1.Text));
            //    cmd1.ExecuteNonQuery();

            //    Listele("select * from Girdi");
            //}
            //else
            //{
            //    MessageBox.Show("başarısız");

            //}
            //conn.Close();


            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Girdi ( BarkodNo, Cins, GirdiAdet, GirişTarihi) values (@BarkodNo, @Cins,@GirdiAdet, @GirişTarihi)", conn);
            cmd.Parameters.AddWithValue("@BarkodNo", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Cins", comboBox1.Text);
            cmd.Parameters.AddWithValue("@GirdiAdet", textBox1.Text);
            cmd.Parameters.AddWithValue("@GirişTarihi", Convert.ToDateTime(dateTimePicker1.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
            Listele("select * from Girdi");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("update Girdi set  BarkodNo=@BarkodNo, Cins=@Cins, GirdiAdet=@GirdiAdet, GirişTarihi=@GirişTarihi where GİşlemNo=@GİşlemNo", conn);
            cmd.Parameters.AddWithValue("@GİşlemNo", comboBox2.Tag);
            cmd.Parameters.AddWithValue("@BarkodNo", comboBox2.Text);
            cmd.Parameters.AddWithValue("@Cins", comboBox1.Text);
            cmd.Parameters.AddWithValue("@GirdiAdet", textBox1.Text);
            cmd.Parameters.AddWithValue("@GirişTarihi", Convert.ToDateTime(dateTimePicker1.Text));
       

            cmd.ExecuteNonQuery();
            conn.Close();
            Listele("select * from Girdi");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from Girdi where GİşlemNo=@GİşlemNo", conn);
            cmd.Parameters.AddWithValue("@GİşlemNo", comboBox2.Tag);
            cmd.ExecuteNonQuery();
            conn.Close();
            Listele("select * from Girdi");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from Girdi where BarkodNo like'%" + comboBox2.Text + "%'", conn);
            SqlDataAdapter adapter = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.CurrentRow;
            comboBox2.Tag = row.Cells["GİşlemNo"].Value.ToString();
            comboBox2.Text = row.Cells["BarkodNo"].Value.ToString();
            comboBox1.Text = row.Cells["Cins"].Value.ToString();
            textBox1.Text = row.Cells["GirdiAdet"].Value.ToString();
            dateTimePicker1.Text = row.Cells["GirişTarihi"].Value.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            

        }
    }
}
