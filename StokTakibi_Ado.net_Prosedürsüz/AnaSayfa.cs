using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StokTakibi_Ado.net_Prosedürsüz
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ürünler go = new Ürünler();
            go.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GirdiForm go = new GirdiForm();
            go.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ÇıktıForm go = new ÇıktıForm();
            go.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Raporlar go = new Raporlar();
            go.Show();
            this.Hide();
        }
    }
}
