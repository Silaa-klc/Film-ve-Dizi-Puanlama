using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace FilmveDiziPuanlama
{
    public partial class Form1 : Form
    {
        // Giriş yapan kullanıcının ID'si
        public static int CurrentUserId;

        public Form1()
        {
            InitializeComponent();
        }

        // Film listeleme fonksiyonu, veritabanından filmleri yükler
        public void YukleFilmleri()
        {
            string connectionString = "Server=SILA;Database=FilmveDizi;Trusted_Connection=True;";
            string query = "SELECT id, film_adi, film_turu, cikis_yili, puan, resim_linki FROM filmler WHERE kullanici_id = @kullanici_id";

            flowLayoutPanel1.Controls.Clear(); // Önceki kartları temizle

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kullanici_id", CurrentUserId);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int filmId = Convert.ToInt32(reader["id"]);

                    // Kart paneli
                    Panel kart = new Panel();
                    kart.Size = new Size(200, 430);
                    kart.Margin = new Padding(10);
                    kart.BorderStyle = BorderStyle.FixedSingle;

                    // Resim
                    PictureBox resim = new PictureBox();
                    resim.Size = new Size(180, 230);
                    resim.Location = new Point(10, 10);
                    resim.SizeMode = PictureBoxSizeMode.StretchImage;
                    try
                    {
                        resim.Load(reader["resim_linki"].ToString());
                    }
                    catch
                    {
                        // Resim yüklenemezse boş bırak
                    }

                    // Film Adı
                    Label baslik = new Label();
                    baslik.Text = reader["film_adi"].ToString();
                    baslik.Location = new Point(10, 250);
                    baslik.AutoSize = true;

                    // Tür
                    Label tur = new Label();
                    tur.Text = "Tür: " + reader["film_turu"].ToString();
                    tur.Location = new Point(10, 275);
                    tur.AutoSize = true;

                    // Yıl
                    Label yil = new Label();
                    yil.Text = "Yıl: " + reader["cikis_yili"].ToString();
                    yil.Location = new Point(10, 300);
                    yil.AutoSize = true;

                    // Puan
                    Label puan = new Label();
                    puan.Text = "Puan: " + reader["puan"].ToString();
                    puan.Location = new Point(10, 325);
                    puan.AutoSize = true;

                    // Yıldız Paneli
                    Panel starPanel = new Panel();
                    starPanel.Location = new Point(10, 350);
                    starPanel.Size = new Size(180, 20);

                    int filmPuan = Convert.ToInt32(reader["puan"]);

                    for (int i = 0; i < 5; i++)
                    {
                        PictureBox star = new PictureBox();
                        star.Size = new Size(20, 20);
                        star.Location = new Point(i * 25, 0);

                        if (i < filmPuan)
                        {
                            star.Image = Properties.Resources.dolu_yildiz;
                        }
                        else
                        {
                            star.Image = Properties.Resources.boş_yildiz;
                        }

                        star.SizeMode = PictureBoxSizeMode.StretchImage;
                        starPanel.Controls.Add(star);
                    }

                    // Sil butonu
                    Button btnSil = new Button();
                    btnSil.Text = "Filmi Sil";
                    btnSil.Size = new Size(70, 35);
                    btnSil.Location = new Point(120, 385);
                    btnSil.Tag = filmId;

                    btnSil.Click += (s, e) =>
                    {
                        int id = Convert.ToInt32(((Button)s).Tag);
                        string deleteQuery = "DELETE FROM filmler WHERE id = @id";

                        using (SqlConnection deleteConn = new SqlConnection(connectionString))
                        {
                            deleteConn.Open();
                            SqlCommand deleteCmd = new SqlCommand(deleteQuery, deleteConn);
                            deleteCmd.Parameters.AddWithValue("@id", id);
                            deleteCmd.ExecuteNonQuery();
                            deleteConn.Close();
                        }

                        MessageBox.Show("Film başarıyla silindi.", "Silindi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        YukleFilmleri();
                    };

                    // Kart içeriğini ekle
                    kart.Controls.Add(resim);
                    kart.Controls.Add(baslik);
                    kart.Controls.Add(tur);
                    kart.Controls.Add(yil);
                    kart.Controls.Add(puan);
                    kart.Controls.Add(starPanel);
                    kart.Controls.Add(btnSil);

                    // FlowLayoutPanel'e ekle
                    flowLayoutPanel1.Controls.Add(kart);
                }

                conn.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            YukleFilmleri(); // Form yüklendiğinde filmleri yükle
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // FilmDiziEkle formunu açarken Form1 referansını geçir
            FilmDiziEkle filmdiziEkle = new FilmDiziEkle(this);
            filmdiziEkle.Show();  // FilmDiziEkle formunu aç
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            // Artık kullanılmıyor. Her kartın içinde sil butonu var.
        }
    }
}
