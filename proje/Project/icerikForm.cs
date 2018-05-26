using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
using Dropbox;
using Dropbox.Api.Files;
using Dropbox.Api;

namespace proje
{
    public partial class icerikForm : Form
    {
        List<string> klasorunIlkHali = new List<string>();
        List<string> buluttanSilinecekler = new List<string>();
        string kasaIsmi;
        string guvenlik;
        string path = "";
        Klasor klasor = new Klasor();
        Kripto kripto = new Kripto();
        FileSystemWatcher systemWatcher = new FileSystemWatcher();
        serverClient sc = new serverClient();
        VeriTabaniIslemleri vb = new VeriTabaniIslemleri();
        static DropboxClient dc = new DropboxClient("CtkHQuOTCVAAAAAAAAAACKI7ZNCmgYPCGOJzN1lPAqwY2V0ymUwHCQnOUaI77xOt");
        public icerikForm()
        {
            InitializeComponent();
        }
        private void icerikForm_Load(object sender, EventArgs e)
        {
            listViewVeriEkleme();
            btn_kasaKitle.Enabled = false;
            btn_kasaSil.Enabled = false;
            Path.Combine(@"c:\sifreler");
            Directory.CreateDirectory(@"C:\sifreler");
        }

        #region yardımcıMetotlar

        public void listViewVeriEkleme()
        {
            listViewGoruntuleme();
            List<string> kasaIsimleri = new List<string>();
            ImageList iList = new ImageList();

            // herbir resmin boyutu belirleniyor
            iList.ImageSize = new Size(20,20);
           
            string p = Path.Combine(Directory.GetCurrentDirectory(),"..","..","icons","folder.png");

            // dbdeki isimleri listeye atıyoruz.
            kasaIsimleri = vb.diziyeVeriOkuma();

            for (int i = 0; i < kasaIsimleri.Count; i++)
            {
                iList.Images.Add(Image.FromFile(p));
                listv_Kasalar.Items.Add(kasaIsimleri[i],i);
            }
            listv_Kasalar.SmallImageList = iList;
            
        }

        public void listViewGoruntuleme()
        {
            listv_Kasalar.Clear();
            listv_Kasalar.View = View.Details;
            listv_Kasalar.Columns.Add("Kasalar", 245);
        }

        private void WriteTxtFile(string kasa)
        {
            StreamWriter writer = new StreamWriter(kasa + ".txt");
            string path = @"c:\" + kasa;
            string[] allFiles = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

            for (int i = 0; i < allFiles.Length; i++)
            {
                writer.WriteLine(allFiles[i]);
            }
            writer.Close();
        }

        #endregion

        #region butonlar ve Eventlar

        private void btn_kasaEkle_Click(object sender, EventArgs e)
        {
            KasaOlusturma kForm = new KasaOlusturma();
            kForm.kasaOlustu += listViewVeriEkleme;
            kForm.Show();
        }

        private void btn_kasaSil_Click(object sender, EventArgs e)
        {

            string fileName = "";
            if (MessageBox.Show("Bu kasayı silmek istediğinizden emin misiniz ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                fileName = listv_Kasalar.SelectedItems[0].Text;

                string txtPath = Directory.GetCurrentDirectory() +"\\"+ fileName + ".txt";

                DirectoryInfo dir = new DirectoryInfo(@"c:\"+fileName);
                klasor.EmptyFolder(dir);

                vb.veriSilme(fileName);

                if(File.Exists(txtPath) == true)
                {
                    StreamReader reader = new StreamReader(txtPath);
                    List<string> files = new List<string>();
                    while(reader.EndOfStream == false)
                    {
                        files.Add(reader.ReadLine());
                    }
                    reader.Close();
                    if (files.Count != 0)
                    {
                        buluttanSil(fileName);
                    }
                    File.Delete(txtPath);
                }

             
                MessageBox.Show("Kasa silindi.");
                listViewVeriEkleme();
            }
        }

        private void btn_onay_Click(object sender, EventArgs e)
        {
            string hashliSifre = "";
            string dosyaMac;
            kasaIsmi = listv_Kasalar.SelectedItems[0].SubItems[0].Text;
            string girilenSifre = txtBox_kasaSifre.Text;
            
            // girilen şifreyi hash fonksiyonu ile hashliyoruz
            girilenSifre = kripto.kasaSifreHashleme(girilenSifre);
            // daha önceden hashlenmiş şifreyi okuyoruz
            hashliSifre = vb.sifre_guvenlikOkuma(kasaIsmi)[0];
            // güvenlik derecesini alıyoruz
            guvenlik = vb.sifre_guvenlikOkuma(kasaIsmi)[1];

            dosyaMac = vb.sifre_guvenlikOkuma(kasaIsmi)[2];
            var pcMac =
                (from nic in NetworkInterface.GetAllNetworkInterfaces()
                 where nic.OperationalStatus == OperationalStatus.Up
                 select nic.GetPhysicalAddress().ToString()
                 ).FirstOrDefault();
            
            // eğer klasörü oluşturan bilgisayarın mac adresi ile dosyaya erişmeye çalışan bilgisayarın mac adresleri farklı ise klasör açılmayacaktır
            if(pcMac != dosyaMac)
            {
                MessageBox.Show("Dosyaya başka bir bilgisayardan erişelemez!");

                return;
            }

            // eğer hashler uyuşmuyorsa şifre yanlış demektir.
            if (girilenSifre == hashliSifre)
            {
                klasor.Ac(kasaIsmi);

                path = @"C:\" + kasaIsmi;
                btn_kasaKitle.Enabled = true;
                klasorunIlkHali = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).ToList();


                systemWatcher.Path = path;
                systemWatcher.EnableRaisingEvents = true;
                systemWatcher.NotifyFilter = NotifyFilters.Size;

                systemWatcher.Changed += new FileSystemEventHandler(onChanged);

            }
            else
            {
                MessageBox.Show("Şifreniz Yanlış.");
            }
            lbl_sifre.Visible = false;
            txtBox_kasaSifre.Visible = false;
            btn_onay.Visible = false;
            txtBox_kasaSifre.Text = "";
        }

        private void onChanged(object sender,FileSystemEventArgs e)
        {
            systemWatcher.EnableRaisingEvents = false;
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
               DialogResult = MessageBox.Show("Dosyada bir değişiklik yaptınız bunu buluta yüklemek ister misiniz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.Yes)
                {
                    string[] yol = e.FullPath.Split('\\');
                    
                    string fileName = e.Name;
                    yol[0] = "";
                    yol[yol.Length - 1] = "";
                    string x = string.Join("\\",yol);
                    x = x.Replace(kasaIsmi, "sifreler");
                    Directory.CreateDirectory(x);
                    kripto.Sifrele(fileName,x,x.Replace("sifreler",kasaIsmi),guvenlik);
                    btn_kasaKitle_Click(e.FullPath,e);
                }
            }
            
        }

        private async void btn_kasaKitle_Click(object sender, EventArgs e)
        {
            string sifrelerYol = @"c:\sifreler";
            bool tf = false;
            string txtPath = Directory.GetCurrentDirectory() + "\\" + kasaIsmi + ".txt";

            // sifreler klasöründeki tüm eski dosyaları siliyoruz.
            DirectoryInfo dirInfo = new DirectoryInfo(sifrelerYol);
            klasor.EmptyFolder(dirInfo);
            Directory.CreateDirectory(sifrelerYol);

            // FIXX SADECE TEK DOSYA YÜKLEME DURUMUNA BAK
            // atılan şey klasör mü yoksa dosya mı diye bakıyoruz dosya ise;
            if ((File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory)
            {
                // tüm alt dosyaları diziye atıyoruz.
                List<string> allFiles = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).ToList();
                if (allFiles.Count == 0)
                {
                    MessageBox.Show("Kasa boş olduğu için herhangi bir şifreleme işlemi yapılamayacaktır.");
                    return;
                }
                // uzantıların ilk C harfini küçük harf yapıyoruz.
                allFiles = klasor.uzantiDuzenle(allFiles);
                klasorunIlkHali = klasor.uzantiDuzenle(klasorunIlkHali);

                // önceden klasörde olup daha sonra klasörde olmayan dosyaları siliyoruz.
                buluttanSilinecekler = klasor.buluttanSilinecekDosyalar(allFiles, klasorunIlkHali);

                for (int i = 0; i < buluttanSilinecekler.Count; i++)
                {
                    string[] yol = buluttanSilinecekler[i].Split('\\');
                    string fileName = yol[yol.Length - 1];
                    yol[yol.Length - 1] = "";
                    yol[0] = "";

                    string x = string.Join("\\",yol);
                    x = x.Replace('\\', '/');
                    x = x.Substring(0, x.Length - 1);

                    var sil = sc.Delete(dc, x, fileName, "");
                    await sil;
                }

                for (int i = 0; i < allFiles.Count; i++)
                {
                    // dosyanın uzantısını bölüp diziye atıyoruz.
                    string[] yol = allFiles[i].Split('\\');

                    // dosya adını çekiyoruz.
                    string fileName = yol[yol.Length - 1];
                    // en sondaki elemanı yani dosya ismini siliyoruz.
                    yol[yol.Length - 1] = "";

                    // diziyi stringe çeviriyoruz.
                    string x = string.Join("\\", yol);

                    // klasör ismini sifreler ile değiştiriyoruz.
                    x = x.Replace(kasaIsmi, "sifreler");

                    // uzantı oluşturuyoruz
                    Directory.CreateDirectory(x);

                    // sifrelemek için fonksiyona veriyoruz.
                    tf = kripto.Sifrele(fileName, x, x.Replace("sifreler", kasaIsmi), guvenlik);

                    string text = allFiles[i];
                }
                WriteTxtFile(kasaIsmi);
                if (tf == true)
                    MessageBox.Show("Kasa kilitlendi");
                if (allFiles.Count != 0)
                {
                    var taskYukle = bulutaYukle(true);
                    await taskYukle;
                    MessageBox.Show("Yükleme başarılı");
                }
            }
            else
            {
          //      var task2 = bulutaYukle(false,);
            //    await task2;
                MessageBox.Show("Değişiklikler kayıt edilmiştir.");
            }
            systemWatcher.EnableRaisingEvents = true;
        }

        private void listv_Kasalar_MouseClick(object sender, MouseEventArgs e)
        {
            btn_kasaSil.Enabled = true;
        }

        private void listv_Kasalar_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            btn_kasaSil.Enabled = false;
        }

        private void listv_Kasalar_DoubleClick(object sender, EventArgs e)
        {
            lbl_sifre.Visible = true;
            txtBox_kasaSifre.Visible = true;
            btn_onay.Visible = true;

        }

        private async void btn_yedekAl_Click(object sender, EventArgs e)
        {
            string decryptKlasorYol = @"c:\decryptKlasor";
            Kripto kripto = new Kripto();
            List<string> kasaAdlari = new List<string>();
            string kasaAdi = "";

            kasaAdlari = vb.diziyeVeriOkuma();

            // girilen string boş mu diye bakılıyor..
            if (txt_yedekKasaAdi.Text == string.Empty)
            {
                MessageBox.Show("Lütfen bir kasa ismi giriniz.");
                return;
            }

            // girilen kasa adi gerçekte var mı diye kontrol ediliyor.
            for (int i = 0; i < kasaAdlari.Count; i++)
            {
                if(kasaAdlari[i]==txt_yedekKasaAdi.Text)
                {
                    kasaAdi = txt_yedekKasaAdi.Text;
                }
            }
            // yok ise hata döndürülüyor
            if(kasaAdi == string.Empty)
            {
                MessageBox.Show("Geçerli kasa adı giriniz.");
                return;
            }

            // eğer önceden bu dosya oluşturulmuşsa silinir.
            if (Directory.Exists(decryptKlasorYol))
            {
                DirectoryInfo dir = new DirectoryInfo(decryptKlasorYol);
                klasor.EmptyFolder(dir);
            }


            // buluttan indirme işlemi
            var taskIndir = buluttanIndir(kasaAdi);
            await taskIndir;

            /// buluttan indirlen dosyaların şifreleri çözülüyor..
            string path = Directory.GetCurrentDirectory() + "\\yedek\\" + kasaAdi;

            // path klasör mü diye kontrol yapılıyor.
            if ((File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory)
            {
                // tüm alt dosyaları diziye atıyoruz.
                List<string> allFiles = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).ToList();

                for (int i = 0; i < allFiles.Count; i++)
                {
                    // dosyanın uzantısını bölüp diziye atıyoruz.
                    string[] yol = allFiles[i].Split('\\');
                    string yol2 = string.Join("\\", yol);
                    for (int j = 0; j < yol.Length; j++)
                    {
                        if (yol[j] != kasaAdi)
                        {
                            yol[j] = "";
                        }
                        else
                            break;
                    }
                    // dosya adını çekiyoruz.
                    string fileName = yol[yol.Length - 1];
                    // en sondaki elemanı yani dosya ismini siliyoruz.
                    yol[yol.Length - 1] = "";

                    // diziyi stringe çeviriyoruz.
                    string x = string.Join("\\", yol);
                    x = x.Substring(x.IndexOf(kasaAdi));

                    x = Path.Combine(decryptKlasorYol + "\\" + x);
                    // uzantı oluşturuyoruz
                    Directory.CreateDirectory(x);

                    // şifreyi çözmek için fonksiyonu çağırıyoruz.
                    kripto.sifreyiCoz(fileName, yol2, x, guvenlik);
                }
                MessageBox.Show("Yedek alınmıştır");
                System.Diagnostics.Process.Start(decryptKlasorYol);
            }
        }

        #endregion

        #region  bulut işlemleri

        private async Task bulutaYukle(bool yesNo,string dosyaYol="")
        {
            string path = @"c:\sifreler";
            if (yesNo == true)
            {
                string[] allFiles = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
                for (int i = 0; i < allFiles.Length; i++)
                {
                    string[] yol = allFiles[i].Split('\\');

                    string fileName = yol[yol.Length - 1];
                    yol[yol.Length - 1] = "";
                    yol[0] = "";
                    string x = string.Join("\\", yol);

                    x = x.Replace('\\', '/');
                    x = x.Substring(0, x.Length - 1);

                    // await sc.Upload(dc,"/maliv3","xx.txt");
                    await sc.Upload(dc, x, fileName, kasaIsmi);
                }
            }
            else
            {
                string[] yol = dosyaYol.Split('\\');
                string fileName = yol[yol.Length - 1];
                yol[yol.Length - 1] = "";
                yol[0] = "";

                string x = string.Join("\\",yol);

                x = x.Replace('\\','/');
                x = x.Substring(0,x.Length-1);

                await sc.Upload(dc, x, fileName, kasaIsmi);
            }
            
        }

        private async Task buluttanIndir(string kasa)
        {
            string yedekYol = Directory.GetCurrentDirectory() + "\\yedek";
            Dictionary<string,string> dosyalar = yedekIndirme(kasa);
            string y = "";


            foreach (var path in dosyalar)
            {
                y = path.Key.Replace("\\", "/");
                var task1 = sc.Download(dc, y, "", kasa);
                await task1;

                string[] dosya = path.Key.Split('\\');
                string dosyaAdi = dosya[dosya.Length - 1];
                dosya[dosya.Length - 1] = "";

                string dir = yedekYol+string.Join("\\", dosya);
                if(Directory.Exists(dir)==false)
                    Directory.CreateDirectory(dir);

                try
                {
                    File.Move(Directory.GetCurrentDirectory() + "\\" + dosyaAdi, dir + dosyaAdi);
                }
                catch(IOException)
                {
                    File.Delete(dir+dosyaAdi);
                    File.Move(Directory.GetCurrentDirectory()+"\\"+dosyaAdi,dir+dosyaAdi);
                }
            }
        }
        
        private async void buluttanSil(string kasa)
        {
            await sc.Delete(dc,"/"+kasa,"","");
        }

        private Dictionary<string,string> yedekIndirme(string kasa)
        {
            string yedekPath = Directory.GetCurrentDirectory() + "\\yedek";

            if(Directory.Exists(yedekPath)==false)
                Directory.CreateDirectory(yedekPath);
            List<string> allFiles = new List<string>();

            string txtPath = Directory.GetCurrentDirectory() + "\\" + kasa + ".txt";

            // eğer txtpath dosyası silinmiş ise , orjinal klasöre gidilip dosya isimleri alınıyorç
            if(File.Exists(txtPath) == false)
            {
                WriteTxtFile(kasa);
            }

            StreamReader reader = new StreamReader(txtPath);
           
            Dictionary<string,string> newFilePaths = new Dictionary<string,string>();

            while (!reader.EndOfStream)
            {
                allFiles.Add(reader.ReadLine());
            }
            reader.Close();

            for (int i = 0; i < allFiles.Count; i++)
            {
                string[] path = allFiles[i].Split('\\');
                for (int j = 0; j < path.Length; j++)
                {
                    if(path[j]!=kasa)
                    {
                        path[j] = "";
                    }
                    else
                    {
                        break;
                    }
                }
                newFilePaths.Add(string.Join("\\", path),allFiles[i]);
            }
            return newFilePaths;
        }

        #endregion

    }
}
