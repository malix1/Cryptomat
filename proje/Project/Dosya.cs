using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace proje
{
    public class Dosya
    {
        public string ad;
        public string uzanti;
        public Dosya()
        {
            ad = "";
            uzanti = "";
        }
        public void Olustur(string _ad)
        {
            ad = _ad;
            uzanti = @"c:\" + _ad;
            Path.Combine(uzanti);
            Directory.CreateDirectory(uzanti);
        }
        public void Ac(string _ad)
        {
            uzanti = @"c:\" + _ad;
            System.Diagnostics.Process.Start(@"c:\" + _ad);
        }
        public void Sil(string _uzanti)
        {
            Directory.Delete(_uzanti);
        }
    }
}
