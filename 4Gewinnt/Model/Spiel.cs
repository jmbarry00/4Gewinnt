using System;
using System.Collections.Generic;
using System.Text;

namespace _4Gewinnt.Model
{
    class Spiel
    {

        public Spiel(int Spalte, int Zeile, string Farbe)
        {
            Spieler player1 = new Spieler("blau");
            Spieler player2 = new Spieler("rot");
            Spielstein spielstein = new Spielstein(Spalte, Zeile, Farbe);
        }
    }
}
