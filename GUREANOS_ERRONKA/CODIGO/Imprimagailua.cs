using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUREANOS_ERRONKA.CODIGO
{
    public class Inprimagailua : Gailua
    {
        private bool koloretakoa;
        private string teknologia;

        public bool Koloretakoa { get => koloretakoa; set => koloretakoa = value; }
        public string Teknologia { get => teknologia; set => teknologia = value; }
        public Inprimagailua(string mark, string koka, DateTime eData, bool aktiboa, string mintt, bool kolor, string tek)
            : base("Inprimagailua", mark, koka, eData, aktiboa, mintt)
        {
            koloretakoa = kolor;
            teknologia = tek;
        }
    }
}
