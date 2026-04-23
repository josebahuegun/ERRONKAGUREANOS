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
        private string mota;
        private int id;
        private DateTime erosteData;
        private string kokalekua;
        private string marka;
        private string egoera;
        private string mintegia;
        private int mintegiaid;
        public int Id { get => id; set => id = value; }
        public DateTime ErosteData { get => erosteData; set => erosteData = value; }
        public string Kokalekua { get => kokalekua; set => kokalekua = value; }
        public string Marka { get => marka; set => marka = value; }
        public string Egoera { get => egoera; set => egoera = value; }
        public string Mintegia { get => mintegia; set => mintegia = value; }
        public string Mota { get => mota; set => mota = value; }
        public int MintegiaId { get; set; }

        public Gailua(int ida, DateTime eData, string koka, string mark, string ego, string mint)
        {

            id = ida;
            marka = mark;
            kokalekua = koka;
            erosteData = eData;
            egoera = ego;
        }
        public Gailua(string mott, string markk, string kokaa, DateTime eDataa, string egoo, string mintt)
        {
            mota = mott;
            marka = markk;
            kokalekua = kokaa;
            erosteData = eDataa;
            egoera = egoo;
            mintegia = mintt;
        }
        public Gailua(int idd)
        {
            id = idd;
        }
    }
}
