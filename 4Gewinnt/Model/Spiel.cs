using System;
using System.Collections.Generic;
using System.Text;

namespace _4Gewinnt.Model
{
    public class Spiel
    {
        public Spieler player1;
        public Spieler player2;
        public Spielstein spielstein;

        public Spiel(Spieler Player1, Spieler Player2)
        {
            player1 = Player1 = new Spieler("blau");
            player2 = Player2 = new Spieler("rot");
            //spielstein = new Spielstein(Spalte, Zeile, Farbe);
        }
    }
}
