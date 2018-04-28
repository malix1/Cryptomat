using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace proje
{
    class VeriTabaniIslemleri
    {
        string baglanti;
        SqlConnection sqlBaglanti;
        
        public VeriTabaniIslemleri()
        {
            baglanti = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\po288\\OneDrive\\Belgeler\\Kasa.mdf;Integrated Security=True;Connect Timeout=30";
            sqlBaglanti = new SqlConnection(baglanti);
        }

        public bool veriEkleme(string isim,string sifre,string uzanti)
        {
            bool hata = false;
            if (sqlBaglanti.State == ConnectionState.Closed)
                sqlBaglanti.Open();
            string txt = "insert into Kasa(isim,sifre,uzanti)values('" + isim + "','" + sifre + "','" + uzanti + "')";
            SqlCommand cmd = new SqlCommand(txt, sqlBaglanti);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                // primary key exception
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
        public void veriSilme(string isim)
        {

        }
        public void veriGuncelleme(string isim,string sifre,string uzanti)
        {

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
            SqlCommand cmd = new SqlCommand("SELECT * FROM Kasa ",sqlBaglanti);
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
        public string sifreOkuma(string kasaIsmi)
        {
            string sifre = "";
            if (sqlBaglanti.State == ConnectionState.Closed)
                sqlBaglanti.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM Kasa WHERE isim ='"+kasaIsmi+"'",sqlBaglanti);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
                sifre = reader[1].ToString();
            if (sqlBaglanti.State == ConnectionState.Open)
                sqlBaglanti.Close();
            return sifre;
        }

    }
}
