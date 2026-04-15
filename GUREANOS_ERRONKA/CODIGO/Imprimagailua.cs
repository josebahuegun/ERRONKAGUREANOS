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
        public Inprimagailua(int ida, DateTime eData, string koka, string mark, int idmint, bool aktiboa, bool kolor, string tek)
            : base(ida, eData, koka, mark, aktiboa, idmint)
        {
            koloretakoa = kolor;
            teknologia = tek;
        }
    }
}
