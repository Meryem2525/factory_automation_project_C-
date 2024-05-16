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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Yönetici_Giris_Bilgileri yönetici= new Yönetici_Giris_Bilgileri();  
            yönetici.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Çalışan_Giris_Bilgileri calışan_bilgi = new Çalışan_Giris_Bilgileri();
            calışan_bilgi.Show();
            this.Hide();


        }
    }
}
