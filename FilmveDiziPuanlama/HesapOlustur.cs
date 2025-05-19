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

namespace FilmveDiziPuanlama
{
    public partial class HesapOlustur : Form
    {
        public HesapOlustur()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnOlustur_Click(object sender, EventArgs e)
        {
            // Textbox'ların boş olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(txtKullanici.Text) || string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Lütfen kullanıcı adı ve şifreyi giriniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "Server=SILA;Database=FilmveDizi;Trusted_Connection=True;";
            string kontrolQuery = "SELECT COUNT(*) FROM Kullanici WHERE kullaniciadi = @kullaniciadi";
            string insertQuery = "INSERT INTO Kullanici (kullaniciadi, sifre) VALUES (@kullaniciadi, @sifre)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Aynı kullanıcı adı zaten var mı diye kontrol et
                using (SqlCommand kontrolCmd = new SqlCommand(kontrolQuery, conn))
                {
                    kontrolCmd.Parameters.AddWithValue("@kullaniciadi", txtKullanici.Text.Trim());
                    int count = (int)kontrolCmd.ExecuteScalar();
                    if (count > 0)
                    {
                        MessageBox.Show("Bu kullanıcı adı zaten mevcut.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }

                // Yeni kullanıcıyı ekle
                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn))
                {
                    insertCmd.Parameters.AddWithValue("@kullaniciadi", txtKullanici.Text.Trim());
                    insertCmd.Parameters.AddWithValue("@sifre", txtSifre.Text.Trim());
                    insertCmd.ExecuteNonQuery();
                }

                conn.Close();
            }

            MessageBox.Show("Hesap başarıyla oluşturuldu. Giriş yapabilirsiniz.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
