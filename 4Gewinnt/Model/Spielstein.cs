using System;
using System.Collections.Generic;
using System.Text;

namespace _4Gewinnt.Model
{
    public class Spielstein
    {        
        public int zeile;
        public int spalte;
        public String farbe;
        public Spielstein(int Zeile, int Spalte, string Farbe)
        {       
            zeile = Zeile;
            spalte = Spalte;
            farbe = Farbe;
        }
        
    }
}
