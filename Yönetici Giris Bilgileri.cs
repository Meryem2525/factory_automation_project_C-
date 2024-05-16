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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proje2
{
    public partial class Yönetici_Giris_Bilgileri : Form
    {
        public Yönetici_Giris_Bilgileri()
        {
            InitializeComponent();
        }
        SqlConnection conn;

        private void Yönetici_Giris_Bilgileri_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Data Source=DESKTOP-GGI8RL1\\MEYREMAA; Initial Catalog=proje; Integrated Security=True";
        }
        private void button1_Click(object sender, EventArgs e)
        {

            // string Tc, sifre;
            // Tc=textBox1.Text;
            //  sifre=textBox2.Text;
            try
            {
              

                conn.Open();
                String sqlCumlesi = "INSERT INTO Yönetici_Tablo(YoneticiTCNo,Sifre) VALUES('" + textBox1.Text + "', '" + textBox2.Text + "')";
                SqlCommand sql = new SqlCommand(sqlCumlesi, conn);
                SqlDataReader oku = sql.ExecuteReader();
                conn.Close();

                MessageBox.Show("kayıt başarılı");
                textBox1.Text = " ";
                textBox2.Text = " ";
              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            Çalışan_ekle_çıkar_ekranı ekle_cıkar_ekranı = new Çalışan_ekle_çıkar_ekranı();
               ekle_cıkar_ekranı.Show();
               this.Hide();
            


        }

      

    }
}
