using System;
using System.Collections.Generic;
using System.Text;

namespace _4Gewinnt.Model
{
    public class Spielstein
    {
        public int spalte;
        public int zeile;
        public String farbe;
        public Spielstein(int Spalte, int Zeile, string Farbe)
        {
            spalte = Spalte;
            zeile = Zeile;
            farbe = Farbe;
        }
    }
}
