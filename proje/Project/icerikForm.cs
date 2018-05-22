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
        string kasaIsmi;
        string guvenlik;
        string path = "";
        Klasor klasor = new Klasor();
        Kripto sifrele = new Kripto();
        serverClient sc = new serverClient();
        VeriTabaniIslemleri vb = new VeriTabaniIslemleri();
        static DropboxClient dc = new DropboxClient("CtkHQuOTCVAAAAAAAAAACKI7ZNCmgYPCGOJzN1lPAqwY2V0ymUwHCQnOUaI77xOt");
        public icerikForm()
        {
            InitializeComponent();
        }
        private void icerikForm_Load(object sender, EventArgs e)
        {
            var task = Task.Run((Func<Task>)icerikForm.Run);
            listViewVeriEkleme();
            btn_kasaKitle.Enabled = false;
            btn_kasaSil.Enabled = false;
            Path.Combine(@"c:\sifreler");
            Directory.CreateDirectory(@"C:\sifreler");

        //    buluttanIndir("maliv4");
        }
        static async Task Run()
        {
            using (var dbx = new DropboxClient("CtkHQuOTCVAAAAAAAAAACKI7ZNCmgYPCGOJzN1lPAqwY2V0ymUwHCQnOUaI77xOt"))
            {
                var full = await dbx.Users.GetCurrentAccountAsync();
            }
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

        private void EmptyFolder(DirectoryInfo directoryInfo)
        {
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
            {
                EmptyFolder(dir);
            }
            Directory.Delete(directoryInfo.FullName);
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
        // fixx   kasaekle butonuna basıldıktan sonra listeyi temizleyip dosya isimlerini tekrardan yazdırmamız gerekiyor.
            KasaOlusturma kForm = new KasaOlusturma();
            kForm.Show();
        }

        private void btn_kasaSil_Click(object sender, EventArgs e)
        {
            string fileName = "";
            //fixxx image list eklenecek, eklenen dosyalar orada görüntülenecek
            if (MessageBox.Show("Bu kasayı silmek istediğinizden emin misiniz ?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                fileName = listv_Kasalar.SelectedItems[0].Text;
                klasor.Sil(@"c:\" + fileName);
                vb.veriSilme(fileName);
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
            girilenSifre = sifrele.kasaSifreHashleme(girilenSifre);
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

        private void button1_Click(object sender, EventArgs e)
        {
            string kasaAdi = "maliv5";
            Kripto kripto = new Kripto();

            string decryptKlasorYol = @"c:\decryptKlasor";
            string path = Directory.GetCurrentDirectory()+"\\yedek\\"+kasaAdi;

            // path klasör mü diye kontrol yapılıyor.
            if ((File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory)
            {
                // tüm alt dosyaları diziye atıyoruz.
                List<string> allFiles = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).ToList();

                for (int i = 0; i < allFiles.Count; i++)
                {
                    // dosyanın uzantısını bölüp diziye atıyoruz.
                    string[] yol = allFiles[i].Split('\\');
                    string yol2 = string.Join("\\",yol);
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
                    kripto.sifreyiCoz(fileName,yol2 , x, guvenlik);
                }
            }
        }

        private void btn_kasaKitle_Click(object sender, EventArgs e)
        {
            string sifrelerYol = @"c:\sifreler";
            bool tf = false;
            Kripto kripto = new Kripto();
            string path = @"c:\" + kasaIsmi;
            string txtPath = Directory.GetCurrentDirectory() + "\\" + kasaIsmi + ".txt";


            // sifreler klasöründeki tüm eski dosyaları siliyoruz.
            DirectoryInfo dirInfo = new DirectoryInfo(sifrelerYol);
            EmptyFolder(dirInfo);
            Directory.CreateDirectory(sifrelerYol);

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
                for (int i = 0; i < allFiles.Count; i++)
                {
                    allFiles[i] = 'c' + allFiles[i].Remove(0, 1);
                }
                for (int i = 0; i < klasorunIlkHali.Count; i++)
                {
                    klasorunIlkHali[i] = 'c' + klasorunIlkHali[i].Remove(0, 1);
                }

                // önceden klasörde olan dosyaları şifrelemeye gerek yok, bunun için burada önceden dosyada olan uzantıları listeden çıkartıyoruz.
                for (int i = 0; i < allFiles.Count; i++)
                {
                    for (int j = 0; j < klasorunIlkHali.Count; j++)
                    {
                        if (allFiles[i] == klasorunIlkHali[j])
                            allFiles.Remove(allFiles[i]);
                        if (allFiles.Count == 0)
                        {
                            allFiles = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories).ToList();
                            break;
                        }
                    }
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
                    bulutaYukle();
                    MessageBox.Show("Yükleme başarılı");
                }
            }

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


        /*   public static void OnCreated(object source, FileSystemEventArgs e)
           {
               Kripto kripto = new Kripto();
               string path = e.FullPath;

               // atılan şey klasör mü yoksa dosya mı diye bakıyoruz dosya ise;
               if ((File.GetAttributes(e.FullPath) & FileAttributes.Directory) == FileAttributes.Directory)
               {
                   // tüm alt dosyaları diziye atıyoruz.
                   string[] allFiles = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);

                   for (int i = 0; i < allFiles.Length; i++)
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
                       x = x.Replace("maliv2", "sifreler");

                       // uzantı oluşturuyoruz
                       Directory.CreateDirectory(x);

                       // sifrelemek için fonksiyona veriyoruz.
                       kripto.Sifrele(fileName, x, x.Replace("sifreler", "maliv2"));
                   }
               }
               // dosya ise;
               else
               {
                   // yolu bölüyoruz.
                   string[] yol = e.FullPath.Split('\\');

                   string fileName = yol[yol.Length - 1];
                   // dosya ismini diziden çıkartıyoruz.
                   yol[yol.Length - 1] = "";

                   // diziyi string yapıyoruz.
                   string x = string.Join("\\",yol);

                   // sifreliyoruz.
                   kripto.Sifrele(fileName, x.Replace("maliv2","sifreler"),x);
               }
           }*/

        #endregion

        #region  bulut işlemleri

        private async void bulutaYukle()
        {
            string path = @"c:\sifreler";
            string[] allFiles = Directory.GetFiles(path,"*.*",SearchOption.AllDirectories);
            for (int i = 0; i < allFiles.Length; i++)
            {
                string[] yol = allFiles[i].Split('\\');

                string fileName = yol[yol.Length - 1];
                yol[yol.Length - 1] = "";
                yol[0] = "";
                string x = string.Join("\\",yol);

                x = x.Replace('\\', '/');
                x = x.Substring(0, x.Length - 1);

                // await sc.Upload(dc,"/maliv3","xx.txt");
                await sc.Upload(dc,x,fileName,kasaIsmi);
            }
        }


        private async void buluttanIndir(string kasa)
        {
            string yedekYol = Directory.GetCurrentDirectory() + "\\yedek";
            Dictionary<string,string> dosyalar = yedekIndirme("maliv4");
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
                Directory.CreateDirectory(dir);

                File.Move(Directory.GetCurrentDirectory() + "\\" + dosyaAdi, dir + dosyaAdi);
                
            }
        }
      
        private Dictionary<string,string> yedekIndirme(string kasa)
        {
            string yedekPath = Directory.GetCurrentDirectory() + "\\yedek";
            Directory.CreateDirectory(yedekPath);
            List<string> allFiles = new List<string>();

            string txtPath = Directory.GetCurrentDirectory() + "\\" + kasa + ".txt";

            if(File.Exists(txtPath) == false)
            {
                WriteTxtFile(kasa);
            }

            StreamReader reader = new StreamReader(txtPath);
           
            Dictionary<string,string> newFilePats = new Dictionary<string,string>();

            while (!reader.EndOfStream)
            {
                allFiles.Add(reader.ReadLine());
            }

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
                newFilePats.Add(string.Join("\\", path),allFiles[i]);
            }
            return newFilePats;
        }

        #endregion

    }
}
