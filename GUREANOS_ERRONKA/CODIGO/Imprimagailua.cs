using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUREANOS_ERRONKA.CODIGO
{
    // : Gailua jarriz herentzia aplikatzen da eta Gailuaren propietateak jasotzen dira, gailua + inpresora kasu hontan
    public class Inprimagailua : Gailua
    {
        private bool koloretakoa;
        private string teknologia;

        public bool Koloretakoa { get => koloretakoa; set => koloretakoa = value; }
        public string Teknologia { get => teknologia; set => teknologia = value; }
        public Inprimagailua(string mark, string koka, DateTime eData, string ego, string mintt, bool kolor, string tek)
            : base("Inprimagailua", mark, koka, eData, ego, mintt)
        {
            koloretakoa = kolor;
            teknologia = tek;
        }
    }
}
