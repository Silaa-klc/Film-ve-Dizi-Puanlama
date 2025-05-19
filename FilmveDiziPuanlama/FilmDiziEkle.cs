using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FilmveDiziPuanlama
{
    public partial class FilmDiziEkle : Form
    {
        private Form1 form1;  // Form1 referansı

        public FilmDiziEkle(Form1 frm)
        {
            InitializeComponent();
            form1 = frm;  // Form1 referansını al
        }

        private void label4_Click(object sender, EventArgs e)
        {
            // Bu metod şimdilik kullanılmıyor, gerekirse buraya işlev ekleyebilirsiniz.
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            // 1. Giriş kontrollerinin dolu olup olmadığını kontrol et
            if (string.IsNullOrWhiteSpace(txtAd.Text) ||
                string.IsNullOrWhiteSpace(cmbTür.Text) ||
                string.IsNullOrWhiteSpace(txtYil.Text) ||
                string.IsNullOrWhiteSpace(cmbPuan.Text) ||
                string.IsNullOrWhiteSpace(txtResimLink.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. SQL bağlantısı ve veri ekleme işlemi
            try
            {
                string connectionString = "Server=SILA;Database=FilmveDizi;Trusted_Connection=True;";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "INSERT INTO filmler (film_adi, film_turu, cikis_yili, puan, resim_linki, kullanici_id) " +
                                   "VALUES (@film_adi, @film_turu, @cikis_yili, @puan, @resim_linki, @kullanici_id)"; // Kullanıcı ID'sini ekledik

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@film_adi", txtAd.Text.Trim());
                        cmd.Parameters.AddWithValue("@film_turu", cmbTür.Text.Trim());
                        cmd.Parameters.AddWithValue("@cikis_yili", int.Parse(txtYil.Text));
                        cmd.Parameters.AddWithValue("@puan", decimal.Parse(cmbPuan.Text.Replace(",", "."), System.Globalization.CultureInfo.InvariantCulture));
                        cmd.Parameters.AddWithValue("@resim_linki", txtResimLink.Text.Trim());
                        cmd.Parameters.AddWithValue("@kullanici_id", Form1.CurrentUserId);  // Giriş yapan kullanıcının ID'sini ekledik

                        cmd.ExecuteNonQuery();
                    }

                    conn.Close();
                }

                MessageBox.Show("Film başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

                // Film ekleme sonrası Form1'deki verileri yenile
                form1.YukleFilmleri();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FilmDiziEkle_Load(object sender, EventArgs e)
        {
            // Film türleri combobox'ına ekleme
            cmbTür.Items.Add("Aksiyon");
            cmbTür.Items.Add("Komedi");
            cmbTür.Items.Add("Dram");
            cmbTür.Items.Add("Bilim Kurgu");
            cmbTür.Items.Add("Romantik");
            cmbTür.Items.Add("Korku");
            cmbTür.Items.Add("Macera");
            cmbTür.Items.Add("Belgesel");
            cmbTür.Items.Add("Fantastik");

            // Puan combobox'ına 1-5 arasındaki sayıları ekleme
            for (int i = 1; i <= 5; i++)
            {
                cmbPuan.Items.Add(i.ToString());
            }
        }

        private void txtYil_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Eğer basılan tuş sayı (0-9) veya Backspace (silme tuşu) değilse, işlemi engelle
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true; // Bu karakteri kabul etme
            }
        }

        private void cmbPuan_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbPuan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Harf veya özel karakter girilmişse engelle
            }
        }

        private void cmbPuan_TextChanged(object sender, EventArgs e)
        {
            if (cmbPuan.Text.Length > 5)
            {
                cmbPuan.Text = cmbPuan.Text.Substring(0, 5);
                cmbPuan.SelectionStart = cmbPuan.Text.Length; // İmleci sona getir
            }
        }
    }
}
