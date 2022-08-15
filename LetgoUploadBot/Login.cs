using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Reflection;

namespace LetgoUploadBot
{
    public partial class Login : Form
    {
        string Pathexe = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\";
        public Login()
        {
            InitializeComponent();
        }
        string hash = "";
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string iDate = encoder(textBox1.Text);
                DateTime oDate = Convert.ToDateTime(iDate);
                TimeSpan ts = oDate - GetDateTime();
                if (Convert.ToUInt32(ts.Days.ToString()) > 0)
                {
                    Form1 fr1 = new Form1(ts.Days.ToString());
                    StreamWriter Yaz = new StreamWriter(Pathexe+"LastSerialNumber.txt");
                    Yaz.Write(textBox1.Text);
                    Yaz.Close();
                    fr1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Girilen Key'in Tarihi Dolmuştur ! Yeni Key Satın Almak İçin Ulaşınız : 05316261050");
                }
            }
            catch
            {
                MessageBox.Show("Girilen Key Hatalıdır !");
            }
            
            
        }

        private string encoder(string value)
        {
            string sifre = Decrypt(value);
            string metincoz = sifre;
            byte[] veridizimcozulen = Convert.FromBase64String(metincoz);
            string anametin2 = ASCIIEncoding.ASCII.GetString(veridizimcozulen);
            return anametin2;
        }
        string iDate;
        string Decrypt(string text)
        {
            byte[] data = Convert.FromBase64String(text);
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                byte[] keys = md5.ComputeHash(Encoding.Default.GetBytes(hash));
                using (TripleDESCryptoServiceProvider tripleDes = new TripleDESCryptoServiceProvider() { Key = keys, Mode = CipherMode.ECB, Padding = PaddingMode.PKCS7 })
                {
                    ICryptoTransform transform = tripleDes.CreateDecryptor();
                    byte[] results = transform.TransformFinalBlock(data, 0, data.Length);
                    return Encoding.Default.GetString(results);
                }
            }
        }
        public static DateTime GetDateTime()
        {
            DateTime dateTime = DateTime.MinValue;
            System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("http://www.microsoft.com");
            request.Method = "GET";
            request.Accept = "text/html, application/xhtml+xml, */*";
            request.UserAgent = "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.1; Trident/6.0)";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.NoCacheNoStore);
            System.Net.HttpWebResponse response = (System.Net.HttpWebResponse)request.GetResponse();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string todaysDates = response.Headers["date"];

                dateTime = DateTime.ParseExact(todaysDates, "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
                System.Globalization.CultureInfo.InvariantCulture.DateTimeFormat, System.Globalization.DateTimeStyles.AssumeUniversal);
            }

            return dateTime;
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.StreamReader Oku = new System.IO.StreamReader(Pathexe+"LastSerialNumber.txt");
            string metin = Oku.ReadLine();
            Oku.Close();
            try
            {
                string iDate = encoder(metin);
                DateTime oDate = Convert.ToDateTime(iDate);
                TimeSpan ts = oDate - GetDateTime();
                if (Convert.ToUInt32(ts.Days.ToString()) > 0)
                {
                    Form1 fr1 = new Form1(ts.Days.ToString());
                    fr1.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Girilen Key'in Tarihi Dolmuştur ! Yeni Key Satın Almak İçin Ulaşınız : 05316261050");
                }
            }
            catch
            {
                MessageBox.Show("Girilen Key Hatalıdır !");
            }
        }
    }
}
