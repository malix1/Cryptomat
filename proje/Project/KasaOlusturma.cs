using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
namespace proje
{
    public partial class KasaOlusturma : Form
    {
        public KasaOlusturma()
        {
            InitializeComponent();
        }

        private void KasaOlusturma_Load(object sender, EventArgs e)
        {
        }
        private void btn_olustur_Click(object sender, EventArgs e)
        {
            txtbox_kasaAdi.Text = txtbox_kasaAdi.Text.Trim();
            txtbox_kasaSifre.Text = txtbox_kasaSifre.Text.Trim();
            // textboxların içi boş ise hata mesajı döndürtüyoruz.
            if (txtbox_kasaAdi.Text == string.Empty || txtbox_kasaSifre.Text == string.Empty)
            { 
                MessageBox.Show("Lütfen geçerli bir kasa adı veya şifre giriniz.");
            }
            else
            {
                bool hata = false;
                Kripto kr = new Kripto();
                Dosya dosya = new Dosya();
                VeriTabaniIslemleri vb = new VeriTabaniIslemleri();
                string sifre = "";

                //eğer textboxlrın içi boş değilse kasanın şifresini hashlemek için hashsifreleme fonksiyonunu çagırıyoruz.
                sifre = kr.kasaSifreHashleme(txtbox_kasaSifre.Text);

                // db ye ekleme yapılıyor.
                string uzanti = @"c\" + txtbox_kasaAdi.Text;

                // verileri veri tabanı işlemleri sınıfından fonk ile ekliyoruz, eğer hata değeri false gelirse yani herhangi hata oluşmamışsa aşağıdaki işlemleri yapıyoruz.
                hata = vb.veriEkleme(txtbox_kasaAdi.Text, sifre, uzanti);
                if (hata == false)
                {
                    // eğer herhangi bir hata alınmamışsa kasa oluşturulup açılıyor.
                    dosya.Olustur(txtbox_kasaAdi.Text);
                    dosya.Ac(txtbox_kasaAdi.Text);
                    MessageBox.Show("Kasa oluşturuldu.");
                    this.Close();
                }
            }
        }
    }
}
