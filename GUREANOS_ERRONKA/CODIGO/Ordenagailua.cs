using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUREANOS_ERRONKA.CODIGO
{
    // : Gailua jarriz gero herentzia aplikatzen da eta Gailuaren propietateak jasotzen dira
    public class Ordenagailua : Gailua
    {
        private string RAM;
        private string ROM;
        private string CPU;

        public string RAM1 { get => RAM; set => RAM = value; }
        public string ROM1 { get => ROM; set => ROM = value; }
        public string CPU1 { get => CPU; set => CPU = value; }

        // Konstruktorea: Gailuaren datuak + Ordenagailuaren datu espezifikoak
        public Ordenagailua(string markk, string kokaa, DateTime eDataa, bool aktiboaa, string mintt, string ram, string rom, string cpu)
            : base("Ordenagailua", markk, kokaa, eDataa, aktiboaa, mintt) // Aitaren konstruktoreari deitzen dio
        {
            RAM = ram;
            ROM = rom;
            CPU = cpu;
        }
    }
}
