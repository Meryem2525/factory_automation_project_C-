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

namespace Proje2
{
    public partial class Çalışan_Ekle__Çıkar : Form
    {
        public Çalışan_Ekle__Çıkar()
        {
            InitializeComponent();
        }

        SqlConnection conn;

        private void Çalışan_Ekle__Çıkar_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection();
            conn.ConnectionString = "Data Source=DESKTOP-GGI8RL1\\MEYREMAA; Initial Catalog=proje; Integrated Security=True";
        }


        private void button1_Click(object sender, EventArgs e)
        {
             try
            {
                string cins = "";
                if (radioButton1.Checked)
                    cins = "Kadın";
                else
                    cins = "Erkek";

                conn.Open();
                String sqlCumlesi = "INSERT INTO calisan(CalisanTcNo, Sifre, Ad,Soyad,cinsiyet) VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + cins+ "')";
                SqlCommand sql = new SqlCommand(sqlCumlesi, conn);
                SqlDataReader oku = sql.ExecuteReader();
                conn.Close();

                MessageBox.Show("kayıt başarılı");
                textBox1.Text = " ";
                textBox2.Text = " ";
                textBox3.Text = " ";
                textBox4.Text = " ";

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            Application.Exit();

        }


    }
}
