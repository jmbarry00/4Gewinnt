using System;
using System.Collections.Generic;
using System.Text;
using VierGewinnt;

namespace _4Gewinnt.Model
{
    public class Spielstein
    {
        int spalte;
        int zeile;
        String farbe;
        public Spielstein(int Spalte, int Zeile, string Farbe)
        {
            spalte = Spalte;
            zeile = Zeile;
            farbe = Farbe;
        }
    }
}
