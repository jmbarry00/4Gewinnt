using System;
using System.Collections.Generic;
using System.Text;
using VierGewinnt;

namespace _4Gewinnt.Model
{
    public class Spielstein
    {
        int spalte;
        string farbe;
        public Spielstein(int Spalte, string Farbe)
        {
            spalte = Spalte;
            farbe = Farbe;
        }
    }
}
