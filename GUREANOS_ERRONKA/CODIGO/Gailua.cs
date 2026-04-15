using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUREANOS_ERRONKA.CODIGO
{
    public class Gailua
    {
        private int id;
        private DateTime erosteData;
        private string kokalekua;
        private string marka;
        private bool aktibo;
        private int idmintegia;
        public int Id { get => id; set => id = value; }
        public DateTime ErosteData { get => erosteData; set => erosteData = value; }
        public string Kokalekua { get => kokalekua; set => kokalekua = value; }
        public string Marka { get => marka; set => marka = value; }
        public bool Aktibo { get => aktibo; set => aktibo = value; }
        public int Idmintegia { get => idmintegia; set => idmintegia = value; }

        public Gailua(int ida, DateTime eData, string koka, string mark, bool aktiboa, int idmint)
        {

            id = ida;
            marka = mark;
            kokalekua = koka;
            erosteData = eData;
            aktibo = aktiboa;
            idmintegia = idmint;
        }
        public Gailua(DateTime eDataa, string kokaa, string markk, bool aktiboaa)
        {
            erosteData = eDataa;
            kokalekua = kokaa;
            marka = markk;
            aktibo = aktiboaa;
        }
    }
}
