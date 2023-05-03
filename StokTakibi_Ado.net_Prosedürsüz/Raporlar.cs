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

namespace StokTakibi_Ado.net_Prosedürsüz
{
    public partial class Raporlar : Form
    {
        public Raporlar()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection("Server=DESKTOP-8RSV7HJ\\SQLKODLAMALAB;Database=StokTakip;Integrated Security=true;");
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                SqlCommand cmd = new SqlCommand("Select * from Ürün where cins = 'Süperge' order by Fiyat asc", conn);
                SqlDataAdapter dr = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                dr.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
            else if (radioButton2.Checked == true)
            {

                SqlCommand cmd = new SqlCommand("Select * from Ürün where cins = 'Televizyon' order by Fiyat asc", conn);
                SqlDataAdapter dr = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                dr.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }

        }

        private void Raporlar_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Select gir.BarkodNo, u.ÜrünAdı, gir.Cins, SUM(gir.GirdiAdet) as 'Girdi Adedi', SUM(cik.ÇıktıAdet) as 'Çıktı Adedi' From Girdi gir, Çıktı cik, Ürün u Where cik.BarkodNo = gir.BarkodNo and gir.BarkodNo = u.BarkodNo and gir.Cins = u.Cins group by gir.BarkodNo, cik.BarkodNo, gir.Cins, u.ÜrünAdı", conn);
            SqlDataAdapter dr = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}




