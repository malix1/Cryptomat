using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.IO;
namespace proje
{
    class VeriTabaniIslemleri
    {
        string baglanti;
        SqlConnection sqlBaglanti;
        
        public VeriTabaniIslemleri()
        {
            DirectoryInfo dbInfo = Directory.GetParent(Path.Combine(Directory.GetCurrentDirectory(),".."));
            baglanti = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = "+dbInfo.FullName+"\\CryptoKasalar.mdf; Integrated Security = True";

            sqlBaglanti = new SqlConnection(baglanti);
        }

        public bool veriEkleme(string isim,string sifre,string uzanti,string guvenlik,string macAdd)
        {
            bool hata = false;
            // bağlantı kapalı ise aç
            if (sqlBaglanti.State == ConnectionState.Closed)
                sqlBaglanti.Open();
            // sql ekleme komutu
            string komut = "insert into Kasalar(isim,sifre,uzanti,guvenlik,mac)values('" + isim + "','" + sifre + "','" + uzanti + "','" + guvenlik +"','"+macAdd+ "')";
            SqlCommand cmd = new SqlCommand(komut, sqlBaglanti);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                // primary key hatası, eğer birden fazla aynı kasa ismi var ise hata mesajı gönderiyoruz
                if (ex.Number == 2627)
                    MessageBox.Show("Aynı kasa ismi birden fazla kullanılamaz.");
                hata = true;
            }
            finally
            {
                // bağlantıyı kapatıyoruz.
                if (sqlBaglanti.State == ConnectionState.Open)
                    sqlBaglanti.Close();
            }
            return hata;
        }
        public void veriSilme(string _isim)
        {
            if (sqlBaglanti.State == ConnectionState.Closed)
                sqlBaglanti.Open();

            string komut = "DELETE FROM Kasalar WHERE isim='"+_isim+"'";
            SqlCommand cmd = new SqlCommand(komut, sqlBaglanti);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (sqlBaglanti.State == ConnectionState.Closed)
                    sqlBaglanti.Close();
            }
        }
        public bool veriKontrol()
        {
            bool tf = false;

            return tf;
        }
        public List<string> diziyeVeriOkuma()
        {
            List<string> kasaIsimleri = new List<string>();
            if (sqlBaglanti.State == ConnectionState.Closed)
                sqlBaglanti.Open();

            // sql komutu ile tüm veriyi alıyoruz.
            SqlCommand cmd = new SqlCommand("SELECT * FROM Kasalar ",sqlBaglanti);
            SqlDataReader reader = cmd.ExecuteReader();
            // verileri okuyup sadece ilk sütundaki değerleri alıyoruz.
            while(reader.Read())
            {
                kasaIsimleri.Add(reader[0].ToString());
            }
            if (sqlBaglanti.State == ConnectionState.Open)
                sqlBaglanti.Close();
            // listeyi geri döndürüyoruz.
            return kasaIsimleri;
        }
        public string[] sifre_guvenlikOkuma(string kasaIsmi)
        {
            string[] sifre_guvenlik = new string[3];
            if (sqlBaglanti.State == ConnectionState.Closed)
                sqlBaglanti.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Kasalar WHERE isim ='"+kasaIsmi+"'",sqlBaglanti);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                sifre_guvenlik[0] = reader[1].ToString();
                sifre_guvenlik[1] = reader[3].ToString();
                sifre_guvenlik[2] = reader[4].ToString();
            }
            if (sqlBaglanti.State == ConnectionState.Open)
                sqlBaglanti.Close();
            return sifre_guvenlik;
        }

    }
}
