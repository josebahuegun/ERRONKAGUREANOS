using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUREANOS_ERRONKA.CODIGO
{
    /// <summary>
    /// : Gailua jarriz gero herentzia aplikatzen da eta Gailuaren propietateak jasotzen dira
    /// </summary>
    public class Ordenagailua : Gailua
    {
        private string RAM;
        private string ROM;
        private string CPU;

        public string RAM1 { get => RAM; set => RAM = value; }
        public string ROM1 { get => ROM; set => ROM = value; }
        public string CPU1 { get => CPU; set => CPU = value; }

        /// <summary>
        /// Konstruktorea: Gailuaren datuak + Ordenagailuaren datu espezifikoak
        /// </summary>
        /// <param name="markk"></param>
        /// <param name="kokaa"></param>
        /// <param name="eDataa"></param>
        /// <param name="egoo"></param>
        /// <param name="mintt"></param>
        /// <param name="ram"></param>
        /// <param name="rom"></param>
        /// <param name="cpu"></param>
        public Ordenagailua(string markk, string kokaa, DateTime eDataa, string egoo, string mintt, string ram, string rom, string cpu)
            : base("Ordenagailua", markk, kokaa, eDataa, egoo, mintt) // Aitaren konstruktoreari deitzen dio
        {
            RAM = ram;
            ROM = rom;
            CPU = cpu;
        }
    }
}
