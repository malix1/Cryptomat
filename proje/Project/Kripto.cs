﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;
namespace proje
{
    public class Kripto
    {
        private string anahtar;
        private RijndaelManaged AES;
        private CryptoStream cs;
        private FileStream fsCrypt;
        private FileStream fsIn;
        private FileStream fsOut;
        private UnicodeEncoding ue;
        public Kripto()
        {
            anahtar = "myKey123";
        }
        public byte[] GenerateRandomSalt()
        {
            byte[] data = new byte[32];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(data);
            }

            return data;
        }
        public void Sifrele(string sifrelencekDosya)
        {
            ue = new UnicodeEncoding();
            byte[] salt = GenerateRandomSalt();

            fsCrypt = new FileStream(sifrelencekDosya + ".crypto", FileMode.Create);

            byte[] sifreByte = Encoding.UTF8.GetBytes(anahtar);

            AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
         //   AES.Padding = PaddingMode.PKCS7;

            var key = new Rfc2898DeriveBytes(sifreByte, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);

            AES.Mode = CipherMode.CFB;

            fsCrypt.Write(salt, 0, salt.Length);

            cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write);

            fsIn = new FileStream(sifrelencekDosya, FileMode.Open);

            byte[] buffer = new byte[1000000];
            int read;
            try
            {
                while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                {
                    cs.Write(buffer, 0, read);
                }
                fsIn.Close();
            }
            catch
            {

            }
            finally
            {
                cs.Close();
                fsCrypt.Close();
            }
        }
        public void sifreyiCoz(string sifresiCozulecekDosya, string dosyaKayitYeri)
        {
            byte[] sifreByte = Encoding.UTF8.GetBytes(anahtar);
            byte[] salt = new byte[32];

            fsCrypt = new FileStream(sifresiCozulecekDosya, FileMode.Open);
            fsCrypt.Read(salt, 0, salt.Length);

            AES = new RijndaelManaged();
            AES.KeySize = 256;
            AES.BlockSize = 128;
            var key = new Rfc2898DeriveBytes(sifreByte, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
       //     AES.Padding = PaddingMode.PKCS7;
            AES.Mode = CipherMode.CFB;

            cs = new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);

            fsOut = new FileStream(dosyaKayitYeri, FileMode.Create);

            int read;
            byte[] buffer = new byte[1000000];
            try
            {
                while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fsOut.Write(buffer, 0, read);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            try
            {
                cs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fsOut.Close();
                fsCrypt.Close();
            }
        }
        public string kasaSifreHashleme(string sifre)
        {
            StringBuilder sb = new StringBuilder();
            SHA512 s512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(sifre);
            byte[] hash = s512.ComputeHash(bytes);
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
