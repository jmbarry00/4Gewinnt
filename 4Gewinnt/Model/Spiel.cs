using System;
using System.Collections.Generic;
using System.Text;

namespace _4Gewinnt.Model
{
    public class Spiel
    {
        Spieler spieler;
        Spielfeld spielfeld;
        int Y;
        int X;


        public Spiel(int y, int x)
        {
            Y = y;
            X = x;
        }

        public void spielStarten()
        {
            spieler.player1 = true;
            spielfeld.ZeilenY = Y;
            spielfeld.SpaltenX = X;

        }
    }
}
