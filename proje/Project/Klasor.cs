using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
    }
}
