using System;
using System.Collections.Generic;
using System.Text;

namespace _4Gewinnt.Model
{
    public class Spiel
    {
        public Spieler spieler;
        public Spielfeld spielfeld;
        int Y;
        int X;


        public Spiel(int y, int x)
        {
            Y = y;
            X = x;
            spieler = new Spieler();
        }

        public void spielStarten()
        {
            spieler.player1 = true;
            spielfeld = new Spielfeld(Y, X);
        }
    }
}
