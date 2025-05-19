using System;
using System.Windows.Forms;

namespace FilmveDiziPuanlama
{
    internal static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new CustomApplicationContext());
        }
    }

    public class CustomApplicationContext : ApplicationContext
    {
        public CustomApplicationContext()
        {
            GirisEkrani girisForm = new GirisEkrani();
            girisForm.FormClosed += GirisForm_FormClosed;
            girisForm.Show();
        }

        private void GirisForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Form1.CurrentUserId > 0)
            {
                Form1 form1 = new Form1();
                form1.FormClosed += (s, args) => ExitThread(); // Form1 kapandığında tüm uygulamayı kapat
                form1.Show();
            }
            else
            {
                ExitThread(); // Giriş başarısız veya iptal edildiyse çık
            }
        }
    }
}
