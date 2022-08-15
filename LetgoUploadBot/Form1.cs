using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;
using System.Drawing.Imaging;
using System.IO;
using System.Resources;
using SeleniumUndetectedChromeDriver;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace LetgoUploadBot
{
    public partial class Form1 : Form
    {
        ChromeDriverService service;
        ChromeOptions options;
        ChromeDriver driver;
        //UndetectedChromeDriver driver;
        List<string> filesPath = new List<string>();
        List<string> filesName = new List<string>();
        List<string> filesNameFolder = new List<string>();
        List<product> urunler = new List<product>();
        Bitmap bmp1;
        string Pathexe = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\";
        string folderPath;
        Color renk = Color.Black;
        int boyut = 0;


        //Þehirler - Ýlçeler

        List<string[]> marmara = new List<string[]>();
        List<string[]> istanbulAnkara = new List<string[]>();
        List<string[]> istanbul = new List<string[]>();

        //Ýstanbul
        string[] istanbulAvrupa = { "istanbul", "Arnavutköy", "Avcýlar", "Baðcýlar", "Bahçelievler", "Bakýrköy", "Baþakþehir", "Bayrampaþa", "Beþiktaþ", "Beylikdüzü", "Beyoðlu", "Büyükçekmece", "Çatalca", "Esenler", "Esenyurt", "Eyüp", "Fatih", "Gaziosmanpaþa", "Güngören", "Kâðýthane", "Küçükçekmece", "Sarýyer", "Silivri", "Sultangazi", "Þiþli", "Zeytinburnu" };
        string[] istanbulAnadolu = { "istanbul", "Adalar", "Ataþehir", "Beykoz", "Çekmeköy", "Kadýköy", "Kartal", "Maltepe", "Pendik", "Sancaktepe", "Sultanbeyli", "Þile", "Tuzla", "Ümraniye", "Üsküdar" };

        //Ankara
        string[] ankara = { "ankara", "ALTINDAÐ", "AYAÞ", "BALA", "BEYPAZARI", "ÇAMLIDERE", "ÇANKAYA", "KAZAN", "KEÇÝÖREN", "KIZILCAHAMAM", "ÇUBUK", "ELMADAÐ", "MAMAK", "ETÝMESGUT", "EVREN", "NALLIHAN", "GÖLBAÞI", "POLATLI", "GÜDÜL", "HAYMANA", "KALECÝK", "PURSAKLAR", "SÝNCAN", "ÞEREFLÝKOÇHÝSAR", "YENÝMAHALLE" };
        //Sakarya
        string[] sakarya = { "sakarya", "Adapazarý", "Arifiye", "Erenler", "Serdivan", "Akyazý", "Ferizli", "Geyve", "Hendek", "Karapürçek", "Karasu", "Kaynarca", "Kocaali", "Pamukova", "Sapanca", "Söðütlü", "Taraklý" };
        //Bursa
        string[] bursa = { "bursa", "Osmangazi", "Nilüfer", "Büyükorhan", "Yýldýrým", "Gemlik", "Gürsu", "Harmancýk", "Ýnegöl", "Ýznik", "Karacabey", "Keles", "Kestel", "Mudanya", "Mustafakemalpaþa", "Orhaneli", "Orhangazi", "Yeniþehir" };
        //Kocaeli
        string[] kocaeli = { "kocaeli", "BAÞÝSKELE", "ÇAYIROVA", "DARICA", "DERÝNCE", "DÝLOVASI", "GEBZE", "GÖLCÜK", "ÝZMÝT", "KANDIRA", "KARAMÜRSEL", "KARTEPE", "KÖRFEZ" };
       
        //Eskiþehir 
        string[] eskisehir = { "eskisehir", "BAÞÝSKELE", "ÇAYIROVA", "DARICA", "DERÝNCE", "DÝLOVASI", "GEBZE", "GÖLCÜK", "ÝZMÝT", "KANDIRA", "KARAMÜRSEL", "KARTEPE", "KÖRFEZ" };
        //Tekirdað
        string[] tekirdag = { "tekirdag", "Çerkezköy", "Çorlu", "Ergene", "Hayrabolu", "Kapaklý", "Malkara", "Marmaraereðlisi", "Saray", "Þarköy", "Süleymanpaþa" };
        //Balýkesir
        string[] balikesir = { "balikesir", "Karesi", "Altýeylül", "Edremit", "Bandýrma", "Gönen", "Ayvalýk", "Burhaniye", "Bigadiç", "Susurluk", "Dursunbey", "Sýndýrgý", "Erdek", "Ývrindi", "Havran", "Kepsut", "Manyas", "Savaþtepe", "Gömeç", "Balya", "Marmara" };
        //Çanakkale
        string[] canakkale = { "canakkale", "Biga", "Çan", "Gelibolu", "Ayvacýk", "Yenice", "Ezine", "Bayramiç", "Lapseki", "Eceabat", "Gökçeada", "Bozcaada" };
        //Yalova
        string[] yalova = { "yalova", "Merkez", "Çiftlikköy", "Çýnarcýk", "Altýnova", "Armutlu", "Termal" };
        //edirne
        string[] edirne = {"edirne","Enez", "Havsa", "Ýpsala", "Keþan", "Lalapaþa", "Meriç", "Süloðlu", "Uzunköprü"};


        //Þehirler - Ýlçeler Kapanýþ
        public Form1(string metin)
        {
            kalanGun = metin;
            InitializeComponent();
        }

      
        string time;
        string kalanGun = "";
        private void button1_Click(object sender, EventArgs e)
        {
           
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Marmara Bölgesi
            marmara.Add(edirne);
            marmara.Add(tekirdag);
            marmara.Add(istanbulAnadolu);
            marmara.Add(istanbulAvrupa);
            marmara.Add(kocaeli);
            marmara.Add(sakarya);
            marmara.Add(yalova);
            marmara.Add(bursa);
            marmara.Add(balikesir);
            marmara.Add(canakkale);

            //istanbulAnkara
            istanbulAnkara.Add(istanbulAnadolu);
            istanbulAnkara.Add(istanbulAvrupa);
            istanbulAnkara.Add(kocaeli);
            istanbulAnkara.Add(sakarya);
            istanbulAnkara.Add(ankara);
            istanbulAnkara.Add(eskisehir);
            istanbulAnkara.Add(bursa);

            //Ýstanbul
            istanbul.Add(istanbulAnadolu);
            istanbul.Add(istanbulAvrupa);

            for (int i = 1; i < istanbulAnadolu.Count(); i++)
            {
                comboBox2.Items.Add(istanbulAnadolu[0] + " " + istanbulAnadolu[i]);
            }
            for (int i = 1; i < istanbulAvrupa.Count(); i++)
            {
                comboBox2.Items.Add(istanbulAvrupa[0] + " " + istanbulAvrupa[i]);
            }

            Directory.CreateDirectory("fotograflar");
            folderPath = Pathexe + "fotograflar\\";
            timer1.Start();
            string[] sehirler = { "Adana", "Adýyaman", "Afyon", "Aðrý", "Amasya", "Ankara", "Antalya", "Artvin", "Aydýn", "Balýkesir", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankýrý", "Çorum", "Denizli", "Diyarbakýr", "Edirne", "Elazýð", "Erzincan", "Erzurum", "Eskiþehir", "Gaziantep", "Giresun", "Gümüþhane", "Hakkari", "Hatay", "Isparta", "Mersin", "Ýstanbul", "Ýzmir", "Kars", "Kastamonu", "Kayseri", "Kýrklareli", "Kýrþehir", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Kahramanmaraþ", "Mardin", "Muðla", "Muþ", "Nevþehir", "Niðde", "Ordu", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Tekirdað", "Tokat", "Trabzon", "Tunceli", "Þanlýurfa", "Uþak", "Van", "Yozgat", "Zonguldak", "Aksaray", "Bayburt", "Karaman", "Kýrýkkale", "Batman", "Þýrnak", "Bartýn", "Ardahan", "Iðdýr", "Yalova", "Karabük", "Kilis", "Osmaniye", "Düzce" };
            foreach (var item in sehirler)
            {
                comboBox1.Items.Add(item);
            }
            string[] kategoriler = {"ELEKTRONÝK","SPOR,EÐLENCE VE OYUNLAR","ARABA","MOTOSÝKLET VE DÝÐER ARAÇLAR","EV VE BAHÇE","MODA VE AKSESUAR","BEBEK VE ÇOCUK","FÝLM,KÝTAP VE MÜZÝK","DÝÐER"};
            foreach (var kategori in kategoriler)
            {
                kategoricmbBox.Items.Add(kategori);
            }
            label12.Text = "Kalan Gün Sayýnýz : " + kalanGun;
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
            
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
             time = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            filesName.Clear();
            filesPath.Clear();
            pictureBox1.ImageLocation = "";
            pictureBox2.ImageLocation = "";
            pictureBox3.ImageLocation = "";
            pictureBox4.ImageLocation = "";
            pictureBox5.ImageLocation = "";
            pictureBox6.ImageLocation = "";
            pictureBox7.ImageLocation = "";
            pictureBox8.ImageLocation = "";
            pictureBox9.ImageLocation = "";
            pictureBox10.ImageLocation = "";
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            file.Multiselect = true;

            if (file.ShowDialog() == DialogResult.OK)
            {
                string[] DosyaYolu = file.FileNames;
                string[] DosyaAdi = file.SafeFileNames;

                for (int i = 0; i < DosyaYolu.Length && i < 10; i++)
                {
                    filesPath.Add(DosyaYolu[i]);
                    filesName.Add(DosyaAdi[i]);
                }
            }
            try
            {
                pictureBox1.ImageLocation = filesPath[0];
            }
            catch
            {

            }
            try
            {
                pictureBox2.ImageLocation = filesPath[1];
            }
            catch
            {

            }
            try
            {
                pictureBox3.ImageLocation = filesPath[2];
            }
            catch
            {

            }
            try
            {
                pictureBox4.ImageLocation = filesPath[3];
            }
            catch
            {

            }
            try
            {
                pictureBox5.ImageLocation = filesPath[4];
            }
            catch
            {

            }
            try
            {
                pictureBox6.ImageLocation = filesPath[5];
            }
            catch
            {

            }
            try
            {
                pictureBox7.ImageLocation = filesPath[6];
            }
            catch
            {

            }
            try
            {
                pictureBox8.ImageLocation = filesPath[7];
            }
            catch
            {

            }
            try
            {
                pictureBox9.ImageLocation = filesPath[8];
            }
            catch
            {

            }
            try
            {
                pictureBox10.ImageLocation = filesPath[9];
            }
            catch
            {

            }

            
           
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            if (kategoricmbBox.Text == "" ||  baslikBox.Text == "" || aciklamaTxtBox.Text == "" || filesPath.Count() == 0 || filigranTxtBox.Text == "" || filigranTxtBox.Text == "")
            {
                MessageBox.Show("Lütfen Tüm Boþluklarý Doldurunuz !");
            }
            else
            {
                
                
                if(fiyatBox.Enabled == false)
                {
                    for (int z = 0; z < filesPath.Count(); z++)
                    {
                        product urun = new product();
                        urun.price = filesName[z];
                        urun.description = aciklamaTxtBox.Text;
                        urun.title = baslikBox.Text;
                        urun.category = kategoricmbBox.Text;
                        urun.filePath = folderPath;
                        urun.filigrafRenk = renk;
                        urun.filigranBoyut = trackBar1.Value;
                        urun.filigranMetin = filigranTxtBox.Text;
                        urun.images.Add(filesPath[z]);
                        if (checkBox1.Checked == true)
                        {
                            foreach (var item in richTextBox1.Lines)
                            {
                                if (item != "")
                                {
                                    urun.sehirler.Add(item.ToString());
                                }

                            }
                        }
                        else if (checkBox2.Checked == true)
                        {
                            for (int i = 1; i < istanbulAnkara.Count(); i++)
                            {
                                for (int j = 1; j < istanbulAnkara[i].Count(); j++)
                                {
                                    urun.sehirler.Add(istanbulAnkara[i][0] + " " + istanbulAnkara[i][j]);
                                }
                            }

                        }
                        else if (checkBox3.Checked == true)
                        {
                            for (int i = 1; i < marmara.Count(); i++)
                            {
                                for (int j = 1; j < marmara[i].Count(); j++)
                                {
                                    urun.sehirler.Add(marmara[i][0] + " " + marmara[i][j]);
                                }
                            }

                        }
                        else if (checkBox4.Checked == true)
                        {
                            for (int i = 0; i < istanbul.Count(); i++)
                            {
                                for (int j = 1; j < istanbul[i].Count(); j++)
                                {
                                    urun.sehirler.Add(istanbul[i][0] + " " + istanbul[i][j]);
                              
                                }
                            }
                     
                        }
                        else
                        {
                            foreach (var item in richTextBox1.Lines)
                            {
                                if (item != "")
                                {
                                    urun.sehirler.Add(item.ToString());
                                }

                            }
                        }


                        urunler.Add(urun);
                        eklenicekUrunlerBox.Text += kategoricmbBox.Text + ";" + fiyatBox.Text + ";" + baslikBox.Text + ";" + aciklamaTxtBox.Text + ";" + filesPath.Count() + " Adet Resim" + "\n";
                        logBox.Text += time + " Tarihinde " + urun.images.Count() + " Adet Resimli Ürün Yüklendi." + "\n";

                    }
                    
                }
                else
                {
                    product urun = new product();
                    urun.price = fiyatBox.Text;
                    urun.description = aciklamaTxtBox.Text;
                    urun.title = baslikBox.Text;
                    urun.category = kategoricmbBox.Text;
                    urun.filePath = folderPath;
                    urun.filigrafRenk = renk;
                    urun.filigranBoyut = trackBar1.Value;
                    urun.filigranMetin = filigranTxtBox.Text;
                    for (int i = 0; i < filesPath.Count(); i++)
                    {
                        urun.images.Add(filesPath[i]);
                    }
                    if (checkBox1.Checked == true)
                    {
                        foreach (var item in richTextBox1.Lines)
                        {
                            if (item != "")
                            {
                                urun.sehirler.Add(item.ToString());
                            }

                        }
                    }
                    else if (checkBox2.Checked == true)
                    {
                        for (int i = 1; i < istanbulAnkara.Count(); i++)
                        {
                            for (int j = 1; j < istanbulAnkara[i].Count(); j++)
                            {
                                urun.sehirler.Add(istanbulAnkara[i][0] + " " + istanbulAnkara[i][j]);
                            }
                        }

                    }
                    else if (checkBox3.Checked == true)
                    {
                        for (int i = 1; i < marmara.Count(); i++)
                        {
                            for (int j = 1; j < marmara[i].Count(); j++)
                            {
                                urun.sehirler.Add(marmara[i][0] + " " + marmara[i][j]);
                            }
                        }

                    }
                    else if (checkBox4.Checked == true)
                    {
                        for (int i = 0; i < istanbul.Count(); i++)
                        {
                            for (int j = 1; j < istanbul[i].Count(); j++)
                            {
                                urun.sehirler.Add(istanbul[i][0] + " " + istanbul[i][j]);
                                
                            }
                        }

                    }
                    else
                    {
                        foreach (var item in richTextBox1.Lines)
                        {
                            if (item != "")
                            {
                                urun.sehirler.Add(item.ToString());
                            }

                        }
                    }


                    urunler.Add(urun);
                    eklenicekUrunlerBox.Text += kategoricmbBox.Text + ";" + fiyatBox.Text + ";" + baslikBox.Text + ";" + aciklamaTxtBox.Text + ";" + filesPath.Count() + " Adet Resim" + "\n";
                    logBox.Text += time + " Tarihinde " + filesPath.Count() + " Adet Resimli Ürün Yüklendi." + "\n";



                }



            }
        }

        private void girisYapBTN_Click(object sender, EventArgs e)
        {
            //Setup();
            logBox.Text += time + " Tarihinde " + " Tarayýcý Açýldý" + "\n";
            service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            options = new ChromeOptions();
            var driverExecutablePath = Pathexe + "chromedriver.exe";

            //driver = UndetectedChromeDriver.Create(
            //   driverExecutablePath: driverExecutablePath,options: options);
            driver = new ChromeDriver(service, options);
            driver.Manage().Window.Maximize();


            driver.Navigate().GoToUrl("https://www.letgo.com/tr-tr");
            Thread.Sleep(1000);
            try
            {
                driver.FindElement(By.XPath("/html/body/div[1]/main/div[1]/header/div/div/div[4]/button")).Click();
            }
            catch
            {
                Thread.Sleep(500);
                driver.FindElement(By.XPath("/html/body/div[1]/main/div[1]/header/div/div/div[4]/button")).Click();
            }

            Thread.Sleep(1000);

            try
            {
                driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div/div/div/div[2]/div[2]/button")).Click();
            }
            catch
            {
                Thread.Sleep(500);
                driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div/div/div/div[2]/div[2]/button")).Click();
            }
            Thread.Sleep(500);
            driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div/div/div/form/div/div/div/div/input")).SendKeys(textBox1.Text);
            
            try
            {
                driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div/div/div/form/button")).Click();
            }
            catch
            {
                Thread.Sleep(500);
                driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div/div/div/form/button")).Click();
            }
            MessageBox.Show("Hesaba Girince Onaylayýnýz!");
            logBox.Text += time + " Tarihinde " + " Letgo Hesabýna Giriþ Yapýldý" + "\n";
            
            
        }

        private void baslatBTN_Click(object sender, EventArgs e)
        {
            string[] sehirler = { "Adana", "Adýyaman", "Afyon", "Aðrý", "Amasya", "Ankara", "Antalya", "Artvin", "Aydýn", "Balýkesir", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankýrý", "Çorum", "Denizli", "Diyarbakýr", "Edirne", "Elazýð", "Erzincan", "Erzurum", "Eskiþehir", "Gaziantep", "Giresun", "Gümüþhane", "Hakkari", "Hatay", "Isparta", "Mersin", "Ýstanbul", "Ýzmir", "Kars", "Kastamonu", "Kayseri", "Kýrklareli", "Kýrþehir", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Kahramanmaraþ", "Mardin", "Muðla", "Muþ", "Nevþehir", "Niðde", "Ordu", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Tekirdað", "Tokat", "Trabzon", "Tunceli", "Þanlýurfa", "Uþak", "Van", "Yozgat", "Zonguldak", "Aksaray", "Bayburt", "Karaman", "Kýrýkkale", "Batman", "Þýrnak", "Bartýn", "Ardahan", "Iðdýr", "Yalova", "Karabük", "Kilis", "Osmaniye", "Düzce" };
            for (int k = 0; k < urunler.Count(); k++)
            {
                for (int z = 0; z < urunler[k].sehirler.Count(); z++)
                {
                    driver.Navigate().GoToUrl("https://www.letgo.com/tr-tr/user-settings/info");
                    for (int i = 0; i < 150; i++)
                    {
                        driver.FindElement(By.CssSelector("#edit-info__location > div > div > div > div > div > div > div.InputTextFieldstyles__InputTextFieldContainer-sc-1uzvgff-0.kzKGLa > div > input")).SendKeys(OpenQA.Selenium.Keys.Backspace);
                    }
                    driver.FindElement(By.CssSelector("#edit-info__location > div > div > div > div > div > div > div.InputTextFieldstyles__InputTextFieldContainer-sc-1uzvgff-0.kzKGLa > div > input")).SendKeys(urunler[k].sehirler[z]);
                    Thread.Sleep(2500);
                    try
                    {
                       
                        try
                        {
                            driver.FindElement(By.XPath("/html/body/div[1]/main/main/article/div/div[2]/div[1]/form/fieldset[3]/div/div[2]/div/section/ul/li[1]")).Click();
                        }
                        catch
                        {
                            Thread.Sleep(1000);
                            driver.FindElement(By.XPath("/html/body/div[1]/main/main/article/div/div[2]/div[1]/form/fieldset[3]/div/div[2]/div/section/ul/li[1]")).Click();
                        }
                    }
                    catch
                    {
                        Thread.Sleep(2000);
                       
                        try
                        {
                            driver.FindElement(By.XPath("/html/body/div[1]/main/main/article/div/div[2]/div[1]/form/fieldset[3]/div/div[2]/div/section/ul/li[1]")).Click();
                        }
                        catch
                        {
                            Thread.Sleep(500);
                            driver.FindElement(By.XPath("/html/body/div[1]/main/main/article/div/div[2]/div[1]/form/fieldset[3]/div/div[2]/div/section/ul/li[1]")).Click();
                        }
                    }
                    Thread.Sleep(2000);
                 
                    try
                    {
                        driver.FindElement(By.XPath("/html/body/div[1]/main/main/article/div/div[2]/div[1]/form/div/div/button")).Click();
                    }
                    catch
                    {
                        Thread.Sleep(2500);
                        driver.FindElement(By.XPath("/html/body/div[1]/main/main/article/div/div[2]/div[1]/form/div/div/button")).Click();
                    }
                    Thread.Sleep(1300);
                    driver.Navigate().GoToUrl("https://www.letgo.com/tr-tr");
                    Thread.Sleep(500);
                    
                    try
                    {
                        driver.FindElement(By.XPath("/html/body/div[1]/main/div[1]/header/div/div/div[3]/button")).Click();
                    }
                    catch
                    {
                        Thread.Sleep(500);
                        driver.FindElement(By.XPath("/html/body/div[1]/main/div[1]/header/div/div/div[3]/button")).Click();
                    }
                    Thread.Sleep(1500);
                    try
                    {
                        driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div[2]/div/div/div[" + (kategoricmbBox.SelectedIndex + 1).ToString() + "]")).Click();
                    }
                    catch
                    {
                        try
                        {
                            Thread.Sleep(1500);
                            driver.FindElement(By.XPath("/html/body/div[1]/main/div[1]/header/div/div/div[3]/button")).Click();
                            Thread.Sleep(500);
                        }
                        catch
                        {

                        }
                        Thread.Sleep(500);
                        driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div[2]/div/div/div[" + (kategoricmbBox.SelectedIndex + 1).ToString() + "]")).Click();
                    }
                    Thread.Sleep(700);
                    Random rastgele = new Random();
                    string[] dosyalar = Directory.GetFiles(folderPath);
                    for (int q = 0; q < dosyalar.Length; q++)
                    {
                        File.Delete(Path.Combine(folderPath, dosyalar[q]));
                    }
                    for (int i = 0; i < urunler[k].images.Count(); i++)
                    {
                        bmp1 = new Bitmap(urunler[k].images[i]);
                        int sayi = rastgele.Next(14, urunler[k].filigranBoyut+15);
                        int en = rastgele.Next(10, bmp1.Width - 300);
                        int boy = rastgele.Next(10, bmp1.Height - 50);

                        Graphics gr = Graphics.FromImage(bmp1);
                        gr.DrawString(filigranTxtBox.Text, new Font("Segoe UI", Convert.ToInt16(sayi), FontStyle.Bold), new SolidBrush(renk), en, boy);
                        bmp1.Save(System.IO.Path.Combine(folderPath, i + "resim.jpg"));
                    }
                    string[] files = Directory.GetFiles(folderPath);
                    string fotograflar = "";
                    for (int q = 0; q < files.Length; q++)
                    {
                        fotograflar += folderPath + "\\" + Convert.ToString(q) + "resim.jpg";
                        if (q != files.Length - 1)
                        {
                            fotograflar += " \n ";
                        }
                    }

                    IWebElement photo = driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div[2]/div[2]/div/input"));
                    photo.SendKeys(fotograflar);

                    Thread.Sleep(2000);
                    driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div[2]/div[1]/div[1]/div[2]/div/div/div/div[1]/div[1]/div/div/div/input")).SendKeys(urunler[k].price);
                    driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div[2]/div[1]/div[1]/div[3]/div/div/div/input")).SendKeys(urunler[k].title);
                    driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div[2]/div[1]/div[1]/div[4]/div[1]/div/div/textarea")).SendKeys(urunler[k].description);
                    Thread.Sleep(1200);
                    try
                    {
                        driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div[2]/div[2]/button")).Click();
                    }
                    catch
                    {
                        Thread.Sleep(500);
                        driver.FindElement(By.XPath("/html/body/div[3]/div[2]/div/div[2]/div[2]/button")).Click();
                    }
                    Thread.Sleep(1000);
                    logBox.Text += time + " Tarihinde " + urunler[k].sehirler[z] + " Þehrine " + urunler[k].title + " Ýsimli Ürününüz Yüklendi" + "\n";
                }
            }




        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    folderPath = fbd.SelectedPath;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            renk = colorDialog1.Color;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            boyut = 15 + trackBar1.Value;
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            string[] sehirler = { "Adana", "Adýyaman", "Afyon", "Aðrý", "Amasya", "Ankara", "Antalya", "Artvin", "Aydýn", "Balýkesir", "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankýrý", "Çorum", "Denizli", "Diyarbakýr", "Edirne", "Elazýð", "Erzincan", "Erzurum", "Eskiþehir", "Gaziantep", "Giresun", "Gümüþhane", "Hakkari", "Hatay", "Isparta", "Mersin", "Ýstanbul", "Ýzmir", "Kars", "Kastamonu", "Kayseri", "Kýrklareli", "Kýrþehir", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Kahramanmaraþ", "Mardin", "Muðla", "Muþ", "Nevþehir", "Niðde", "Ordu", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Tekirdað", "Tokat", "Trabzon", "Tunceli", "Þanlýurfa", "Uþak", "Van", "Yozgat", "Zonguldak", "Aksaray", "Bayburt", "Karaman", "Kýrýkkale", "Batman", "Þýrnak", "Bartýn", "Ardahan", "Iðdýr", "Yalova", "Karabük", "Kilis", "Osmaniye", "Düzce" };
            checkBox1.Enabled = false;
            checkBox4.Enabled = true;
            checkBox4.Checked = false;
            checkBox2.Enabled = true;
            checkBox3.Enabled = true;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            foreach (var item in sehirler)
            {
              if(richTextBox1.Text == "")
                {
                    richTextBox1.Text += item;
                }
                else
                {
                    richTextBox1.Text += "\n" + item;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if(richTextBox1.Text == "")
            {
                richTextBox1.Text += comboBox1.Text;
            }
            else
            {
                richTextBox1.Text += "\n" + comboBox1.Text;
            }
           
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void groupBox7_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
        
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            checkBox4.Enabled = true;
            checkBox4.Checked = false;
            checkBox2.Enabled = false;
            checkBox1.Enabled = true;
            checkBox3.Enabled = true;
            checkBox1.Checked = false;
            checkBox3.Checked = false;
            foreach (var item in istanbulAnkara)
            {
                foreach (var item2 in item)
                {
                    if (richTextBox1.Text == "")
                    {
                        richTextBox1.Text += item2;
                    }
                    else
                    {
                        richTextBox1.Text += "\n" + item2;
                    }
                }
                
            }
        }

        private void checkBox3_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            checkBox4.Enabled = true;
            checkBox4.Checked = false;
            checkBox3.Enabled = false;
            checkBox1.Enabled = true;
            checkBox2.Enabled = true;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            
            foreach (var item in marmara)
            {
                foreach (var item2 in item)
                {
                    if (richTextBox1.Text == "")
                    {
                        richTextBox1.Text += item2;
                    }
                    else
                    {
                        richTextBox1.Text += "\n" + item2;
                    }
                }

            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            checkBox1.Enabled = true;
            checkBox1.Checked = false;
            checkBox2.Enabled = true;
            checkBox2.Checked = false;
            checkBox3.Enabled = true;
            checkBox3.Checked = false;
            checkBox4.Enabled = true;
            checkBox4.Checked = false;
            richTextBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            fiyatBox.Enabled = false;
            OpenFileDialog choofdlog = new OpenFileDialog();

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    //Ýsim Döndürücü
                    for (int i = 0; i < files.Length; i++)
                    {
                        filesPath.Add(files[i]);
                        int sayac = 0;
                        int sayac2 = 0;
                        string filename = "";
                        for (int k = 0; k < files[i].Length; k++)
                        {
                            if (files[i][k].ToString() == "\\")
                            {
                                sayac++;
                            }
                        }
                        for (int k = 0; k < files[i].Length; k++)
                        {
                            if (files[i][k].ToString() == "\\")
                            {
                                sayac2++;
                            }
                            if(sayac2 == sayac)
                            {
                                filename += files[i][k].ToString();
                            }
                        }
                         filesName.Add(filename.Replace(".jpg","").Replace(".png","").Replace(".jpeg","").Replace("\\",""));
                         
                    }
                    

                    System.Windows.Forms.MessageBox.Show("Bulunan Resim Sayýsý: " + files.Length.ToString());
                }
            }
            label28.Text = "Ekleme Baþarýlý!";
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            

        }

        private void checkBox4_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            checkBox4.Enabled = false;
            checkBox4.Checked = true;
            checkBox3.Enabled = true;
            checkBox3.Checked = false;
            checkBox2.Enabled = true;
            checkBox2.Checked = false;
            checkBox1.Enabled = true;
            checkBox1.Checked = false;
            foreach (var item in istanbul)
            {
                foreach (var item2 in item)
                {
                    if (richTextBox1.Text == "")
                    {
                        richTextBox1.Text += item2;
                    }
                    else
                    {
                        richTextBox1.Text += "\n" + item2;
                    }
                }

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "")
            {
                richTextBox1.Text += comboBox2.Text;
            }
            else
            {
                richTextBox1.Text += "\n" + comboBox2.Text;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            urunler.Clear();
            eklenicekUrunlerBox.Text = "";
            button3.Enabled = true;
            fiyatBox.Enabled = true;
        }
    }
}