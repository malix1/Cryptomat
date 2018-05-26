using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace proje
{
    public class Klasor
    {
        public string ad;
        public string yol;
        public string guvenlik;
        public Klasor()
        {
            ad = "";
            yol = "";
            guvenlik = "";
        }
        public void Olustur(string _ad,string _guvenlik)
        {
            ad = _ad;
            yol = @"c:\" + _ad;
            guvenlik = _guvenlik;
            Path.Combine(yol);
            Directory.CreateDirectory(yol);
        }
        public void Ac(string _ad)
        {
            yol = @"c:\" + _ad;
            System.Diagnostics.Process.Start(@"c:\" + _ad);
        }
        public void Sil(string _uzanti)
        {
            Directory.Delete(_uzanti);
        }

        public void EmptyFolder(DirectoryInfo directoryInfo)
        {
            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in directoryInfo.GetDirectories())
            {
                EmptyFolder(dir);
            }
            try
            {
                Directory.Delete(directoryInfo.FullName);
            }
            catch (IOException hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        public List<string> uzantiDuzenle(List<string> files)
        {
            for (int i = 0; i < files.Count; i++)
            {
                files[i] = 'c' + files[i].Remove(0, 1);
            }
            return files;
        }

        public List<string> buluttanSilinecekDosyalar(List<string>tumDosyalar,List<string> klasorunIlkHali)
        {
            List<string> silinecekler = new List<string>();
            for (int i = 0; i < klasorunIlkHali.Count; i++)
            {
                bool varYok = false;
                for (int j = 0; j < tumDosyalar.Count; j++)
                {
                    if (klasorunIlkHali[i] == tumDosyalar[j])
                    {
                        varYok = true;
                    }
                }
                if (varYok == false)
                    silinecekler.Add(klasorunIlkHali[i]);
            }
            return silinecekler;
        }
    }
}
