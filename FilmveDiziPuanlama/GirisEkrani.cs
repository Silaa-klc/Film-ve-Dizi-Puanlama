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
    public partial class GirisEkrani : Form
    {
        public GirisEkrani()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=SILA;Database=FilmveDizi;Trusted_Connection=True;";
            string query = "SELECT id FROM Kullanici WHERE kullaniciadi = @kullaniciadi AND sifre = @sifre";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kullaniciadi", txtKullaniciAd.Text);
                cmd.Parameters.AddWithValue("@sifre", txtSifre.Text);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int kullaniciId = (int)reader["id"];
                    Form1.CurrentUserId = kullaniciId;

                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Hide();

                    // Form1 kapanınca Giriş Ekranı da kapansın
                    form1.FormClosed += (s, args) => this.Close();
                }
                else
                {
                    MessageBox.Show("Geçersiz kullanıcı adı veya şifre.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnHesapOlustur_Click(object sender, EventArgs e)
        {
            HesapOlustur hesapOlustur = new HesapOlustur();
            hesapOlustur.ShowDialog();
        }
    }
}
