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
        private string mapa;
        private bool aktibo;

        public int Id { get => id; set => id = value; }
        public DateTime ErosteData { get => erosteData; set => erosteData = value; }
        public string Kokalekua { get => kokalekua; set => kokalekua = value; }
        public string Mapa { get => mapa; set => mapa = value; }
        public bool Aktibo { get => aktibo; set => aktibo = value; }

        public Gailua(int ida, DateTime eData, string koka, string map, bool aktiboa)
        {

            id = ida;
            erosteData = eData;
            kokalekua = koka;
            mapa = map;
            aktibo = aktiboa;
        }
        public Gailua(DateTime eDataa, string kokaa, string mapp, bool aktiboaa)
        {
            erosteData = eDataa;
            kokalekua = kokaa;
            mapa = mapp;
            aktibo = aktiboaa;
        }
    }
}
