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
        Dosya dosya = new Dosya();
        Kripto sifrele = new Kripto();
        VeriTabaniIslemleri vb = new VeriTabaniIslemleri();
        public icerikForm()
        {
            InitializeComponent();
        }
        private void icerikForm_Load(object sender, EventArgs e)
        {
            listViewGoruntuleme();
            btn_kullaniciGuncelle.Enabled = false;
            btn_kasaSil.Enabled = false;
        }
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
            //    string path = Path.Combine("..","..","..","..","..","..","icons","folder.png");
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
        private void btn_kasaEkle_Click(object sender, EventArgs e)
        {
        // fixx   kasaekle butonuna basıldıktan sonra listeyi temizleyip dosya isimlerini tekrardan yazdırmamız gerekiyor.
        //    listv_Kasalar.Clear();
            KasaOlusturma kForm = new KasaOlusturma();
            kForm.Show();
     //       listViewVeriEkleme();
        }

        private void btn_kasaSil_Click(object sender, EventArgs e)
        {
            string fileName = "";
            //fixxx image list eklenecek, eklenen dosyalar orada görüntülenecek
            if(MessageBox.Show("Bu kasayı silmek istediğinizden emin misiniz ?","Onay",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                fileName = listv_Kasalar.SelectedItems[0].Text;
                dosya.Sil(@"c:\"+fileName);
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
            string kasaIsmi = listv_Kasalar.SelectedItems[0].SubItems[0].Text;
            string girilenSifre = txtBox_kasaSifre.Text;
            
            // girilen şifreyi hash fonksiyonu ile hashliyoruz
            girilenSifre = sifrele.kasaSifreHashleme(girilenSifre);
            // daha önceden hashlenmiş şifreyi okuyoruz
            hashliSifre = vb.sifreOkuma(kasaIsmi);

            // eğer hashler uyuşmuyorsa şifre yanlış demektir.
            if(girilenSifre == hashliSifre)
            {
                dosya.Ac(kasaIsmi);
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
            btn_kullaniciGuncelle.Enabled = true;
            btn_kasaSil.Enabled = true;
        }

        private void listv_Kasalar_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            btn_kullaniciGuncelle.Enabled = false;
            btn_kasaSil.Enabled = false;
        }
    }
}
