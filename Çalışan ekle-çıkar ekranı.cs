using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje2
{
    public partial class Çalışan_ekle_çıkar_ekranı : Form
    {
        public Çalışan_ekle_çıkar_ekranı()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Çalışan_Ekle__Çıkar ekle_cıkar = new Çalışan_Ekle__Çıkar();
            ekle_cıkar.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Çalışan_çıkarma cıkarma=new Çalışan_çıkarma();
            cıkarma.Show();
            this.Hide();
        }
    }
}
