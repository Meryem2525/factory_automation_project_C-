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

namespace Proje2
{
    public partial class Çalışan_çıkarma : Form
    {
        public Çalışan_çıkarma()
        {
            InitializeComponent();
        }
        SqlConnection conn;
        private void Çalışan_çıkarma_Load(object sender, EventArgs e)
        {

            conn = new SqlConnection();
            conn.ConnectionString = "Data Source=DESKTOP-GGI8RL1\\MEYREMAA; Initial Catalog=proje; Integrated Security=True";
        }
       

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                // TC'ye göre çalışanı sorgula
                string sorgu = "SELECT * FROM calisan WHERE CalisanTcNo  = '" + textBox1.Text + "'";
                SqlCommand kontrolCommand = new SqlCommand(sorgu, conn);
                SqlDataReader kontrolReader = kontrolCommand.ExecuteReader();

                if (kontrolReader.HasRows)
                {
                    kontrolReader.Close();
                    // Eğer çalışan bulunduysa, diğer kontrolleri aktive et
                    button2.Enabled = true;
                    MessageBox.Show("Çalışan bulundu.");
                    listBox1.Items.Add(textBox1.Text);
                }
                else
                {
                    kontrolReader.Close();
                    // Eğer çalışan bulunamazsa, hata mesajını göster ve silme butonunu deaktive et
                    button2.Enabled = false;
                    MessageBox.Show("Çalışan bulunamadı. Lütfen geçerli bir TC girin.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();

                // TC'ye göre çalışanı sil
                string silmeSorgusu = "DELETE FROM calisan WHERE CalisanTcNo = '" + textBox1.Text + "'";
                SqlCommand silmeCommand = new SqlCommand(silmeSorgusu, conn);
                int affectedRows = silmeCommand.ExecuteNonQuery();

                if (affectedRows > 0)
                {
                    MessageBox.Show("Silme başarılı");
                    button2.Enabled = false; // Silme işlemi tamamlandıktan sonra silme butonunu deaktive et
                }
                else
                {
                    MessageBox.Show("Silme işlemi sırasında bir hata oluştu");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

        }
    }
    }
        

