using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace proje
{
    /// <summary>
    /// dosyayı kitleme yok
    /// </summary>
    public partial class icerikForm : Form
    {
        string kasaIsmi;
        string path = "";
        Klasor klasor = new Klasor();
        Kripto sifrele = new Kripto();
        FileSystemWatcher systemWatcher = new FileSystemWatcher();
        FileSystemWatcher systemWatcher2 = new FileSystemWatcher();
        VeriTabaniIslemleri vb = new VeriTabaniIslemleri();
        public icerikForm()
        {
            InitializeComponent();
        }
        private void icerikForm_Load(object sender, EventArgs e)
        {
            listViewGoruntuleme();
            btn_kasaKitle.Enabled = false;
            btn_kasaSil.Enabled = false;
            btn_kasaKitle.Enabled = false;
            Path.Combine(@"c:\sifreler");
            Directory.CreateDirectory(@"C:\sifreler");

        }
        #region yardımcıMetotlar

        public void listViewGoruntuleme()
        {
            listv_Kasalar.Clear();
            listv_Kasalar.View = View.Details;
            listv_Kasalar.Columns.Add("Kasalar",245);
            listViewVeriEkleme();
        }
        private void listViewVeriEkleme()
        {
            List<string> kasaIsimleri = new List<string>();
            ImageList iList = new ImageList();

            // herbir resmin boyutu belirleniyor
            iList.ImageSize = new Size(20,20);
            
            // sabit birşey olsun...... FIXXXXXXXXXXXXX
            string path = @"C:\Users\po288\OneDrive\Masaüstü\Crypto\Cryptomat\proje\Project\icons\folder.png";

            // dbdeki isimleri listeye atıyoruz.
            kasaIsimleri = vb.diziyeVeriOkuma();

            for (int i = 0; i < kasaIsimleri.Count; i++)
            {
                iList.Images.Add(Image.FromFile(path));
                listv_Kasalar.Items.Add(kasaIsimleri[i],i);
            }
            listv_Kasalar.SmallImageList = iList;
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
            if(MessageBox.Show("Bu kasayı silmek istediğinizden emin misiniz ?","Onay",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                fileName = listv_Kasalar.SelectedItems[0].Text;
                klasor.Sil(@"c:\"+fileName);
                vb.veriSilme(fileName);
            }
        }

        private void listv_Kasalar_DoubleClick(object sender, EventArgs e)
        {
            lbl_sifre.Visible = true;
            txtBox_kasaSifre.Visible = true;
            btn_onay.Visible = true;

        }

        private void btn_onay_Click(object sender, EventArgs e)
        {
            string hashliSifre = "";
            kasaIsmi = listv_Kasalar.SelectedItems[0].SubItems[0].Text;
            string girilenSifre = txtBox_kasaSifre.Text;
            
            // girilen şifreyi hash fonksiyonu ile hashliyoruz
            girilenSifre = sifrele.kasaSifreHashleme(girilenSifre);
            // daha önceden hashlenmiş şifreyi okuyoruz
            hashliSifre = vb.sifreOkuma(kasaIsmi);

            // eğer hashler uyuşmuyorsa şifre yanlış demektir.
            if(girilenSifre == hashliSifre)
            {
                klasor.Ac(kasaIsmi);
                path = @"C:\" + kasaIsmi;
                btn_kasaKitle.Enabled = true;
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

        private void listv_Kasalar_MouseClick(object sender, MouseEventArgs e)
        {
            btn_kasaKitle.Enabled = true;
            btn_kasaSil.Enabled = true;
        }

        private void listv_Kasalar_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            btn_kasaKitle.Enabled = false;
            btn_kasaSil.Enabled = false;
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            systemWatcher.EnableRaisingEvents = false;
            Kripto kripto = new Kripto();
            string path = @"c:\sifreler";

            // path klasör mü diye kontrol yapılıyor.
            if ((File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory)
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

                    //şifreleri sakladığımız klasörün ismini klasör ismi ile değiştiriyoruz.
                    x = x.Replace("sifreler", "maliv2");

                    // uzantı oluşturuyoruz
                    Directory.CreateDirectory(x);

                    // şifreyi çözmek için fonksiyonu çağırıyoruz.
                    kripto.sifreyiCoz(fileName, x.Replace("maliv2", "sifreler"),x);
                }
            }
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

        private void btn_kasaKitle_Click(object sender, EventArgs e)
        {
            Kripto kripto = new Kripto();
            string path = @"c:\"+kasaIsmi;

            // atılan şey klasör mü yoksa dosya mı diye bakıyoruz dosya ise;
            if ((File.GetAttributes(path) & FileAttributes.Directory) == FileAttributes.Directory)
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
            
        }
    }
}
