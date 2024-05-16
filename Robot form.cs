using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje2
{
    public partial class Robot_form : Form
    {
        int xKonumu = 0;
        int yKonumu = 0;
        int hareketler = 0;
        string komutlar;
        public Robot_form()
        {
            InitializeComponent();
        }

        SqlConnection conn;

        private void Robot_form_Load(object sender, EventArgs e)
        {

            conn = new SqlConnection();
            conn.ConnectionString = "Data Source=DESKTOP-GGI8RL1\\MEYREMAA; Initial Catalog=proje; Integrated Security=True";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Konumlandır
            xKonumu = Convert.ToInt32(textBox2.Text);
            yKonumu = Convert.ToInt32(textBox3.Text);
            komutlar = textBox4.Text;
            listView1.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Hareket Ettir
            string komutlar = textBox4.Text;
            int komutlarUzunlugu = textBox4.Text.Length;

            for (int i = 0; i < komutlarUzunlugu; i++) //Uzunluğa göre döngü içinde her harfi arıyoruz.
            {
                switch (komutlar[i])
                {
                    case 'R':
                        {
                            if (comboBox1.Text == "K")
                            {
                                comboBox1.Text = "D";
                            }
                            else if (comboBox1.Text == "D")
                            {
                                comboBox1.Text = "G";
                            }
                            else if (comboBox1.Text == "G")
                            {
                                comboBox1.Text = "B";
                            }
                            else if (comboBox1.Text == "B")
                            {
                                comboBox1.Text = "K";
                            }
                        }
                        break;
                    case 'L':
                        {
                            if (comboBox1.Text == "K")
                            {
                                comboBox1.Text = "B";
                            }
                            else if (comboBox1.Text == "B")
                            {
                                comboBox1.Text = "G";
                            }
                            else if (comboBox1.Text == "G")
                            {
                                comboBox1.Text = "D";
                            }
                            else if (comboBox1.Text == "D")
                            {
                                comboBox1.Text = "K";
                            }
                        }
                        break;
                    case 'M':
                        {
                            if (comboBox1.Text == "K")
                            {
                                yKonumu++;
                            }
                            else if (comboBox1.Text == "D")
                            {
                                xKonumu++;
                            }
                            else if (comboBox1.Text == "G")
                            {
                                yKonumu--;
                            }
                            else if (comboBox1.Text == "B")
                            {
                                xKonumu--;
                            }

                            int yeniHareketler = hareketler;
                            int yeniXKonumu = xKonumu;
                            int yeniYKonumu = yKonumu;

                            listView1.Items.Add((hareketler + 1).ToString());
                            listView1.Items[yeniHareketler].SubItems.Add(yeniXKonumu.ToString()); //ListView'e X konumunu yazdırıyoruz.
                            listView1.Items[yeniHareketler].SubItems.Add(yeniYKonumu.ToString()); //ListView'e Y konumunu yazdırıyoruz.

                            label7.Text = yeniXKonumu.ToString() + " " + yeniYKonumu.ToString();
                            hareketler++;

                            // Veritabanına ekleme işlemi
                            conn.Open();
                            string insertSorgusu = "INSERT INTO tablo_robot(hareket_sırası, X_konumu, Y_konumu) VALUES ('" + (hareketler + 1).ToString() + "', '" + yeniXKonumu.ToString() + "', '" + yeniYKonumu.ToString() + "')";
                            SqlCommand insertCommand = new SqlCommand(insertSorgusu, conn);
                            insertCommand.ExecuteNonQuery();
                            conn.Close();
                        }
                        break;
                }
            }
           
        }


    }
}
