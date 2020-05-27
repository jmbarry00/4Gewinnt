using System;
using System.Collections.Generic;
using System.Text;

namespace _4Gewinnt.Model
{
    public class Spiel
    {


        public Spiel(int y, int x)
        {
            Spieler player = new Spieler();
            Spielfeld spielfeld = new Spielfeld(y,x);
        }

        public void spielStarten(Spieler spieler, Spielfeld spielfeld, int x, int y)
        {
            spieler.player1 = true;
            spieler = new Spieler();
            spielfeld = new Spielfeld(x, y);
            
        }
    }
}
