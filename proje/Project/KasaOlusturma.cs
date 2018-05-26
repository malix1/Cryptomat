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
using System.Net.NetworkInformation;

namespace proje
{
    public partial class KasaOlusturma : Form
    {
        public delegate void  KasaOlusturulduEventHandler();
        public event KasaOlusturulduEventHandler kasaOlustu;
        public KasaOlusturma()
        {
            InitializeComponent();
        }

        private void KasaOlusturma_Load(object sender, EventArgs e)
        {
        }
        private void btn_olustur_Click(object sender, EventArgs e)
        {
            bool hata = false;
            icerikForm iForm = new icerikForm();
            txtbox_kasaAdi.Text = txtbox_kasaAdi.Text.Trim();
            txtbox_kasaSifre.Text = txtbox_kasaSifre.Text.Trim();
            // textboxların içi boş ise hata mesajı gönderiyoruz.
            if (txtbox_kasaAdi.Text == string.Empty || txtbox_kasaSifre.Text == string.Empty)
            { 
                MessageBox.Show("Lütfen geçerli bir kasa adı veya şifre giriniz.");
            }
            // eğer herhangi bir güvenlik değeri seçilmemişse hata mesajı gönderiyoruz
            else if (rbDusuk.Checked == false && rbYuksek.Checked == false && rbOrta.Checked == false)
            {
                MessageBox.Show("Güvenlik seviyesi boş olamaz");
            }
            else
            {
                string guvenlik = "";
                var macAdd =
                (from nic in NetworkInterface.GetAllNetworkInterfaces()
                    where nic.OperationalStatus == OperationalStatus.Up
                    select nic.GetPhysicalAddress().ToString()
                    ).FirstOrDefault();
                Kripto kr = new Kripto();
                Klasor dosya = new Klasor();
                VeriTabaniIslemleri vb = new VeriTabaniIslemleri();
                string sifre = "";

                // radiobutton lar kontrol edilip checkli olan hangisi ise onu güvenlik değişkenine atıyoruz.
                if (rbDusuk.Checked == true)
                    guvenlik = "dusuk";
                else if (rbOrta.Checked == true)
                    guvenlik = "orta";
                else
                    guvenlik = "yuksek";

                //eğer textboxlrın içi boş değilse kasanın şifresini hashlemek için hashsifreleme fonksiyonunu çagırıyoruz.
                sifre = kr.kasaSifreHashleme(txtbox_kasaSifre.Text);

                // db ye ekleme yapılıyor.
                string yol = @"c\" + txtbox_kasaAdi.Text;

                // verileri veri tabanı işlemleri sınıfından fonk ile ekliyoruz, eğer hata değeri false gelirse yani herhangi hata oluşmamışsa aşağıdaki işlemleri yapıyoruz.
                hata = vb.veriEkleme(txtbox_kasaAdi.Text, sifre, yol,guvenlik,macAdd.ToString());
                if (hata == false)
                {
                    // eğer herhangi bir hata alınmamışsa kasa oluşturulup açılıyor.
                    dosya.Olustur(txtbox_kasaAdi.Text, guvenlik);
                    MessageBox.Show("Kasa oluşturuldu.");
                    kasaOlustu?.Invoke();
                    dosya.Ac(txtbox_kasaAdi.Text);
                    this.Close();
                }
            }
        }
    }
}
