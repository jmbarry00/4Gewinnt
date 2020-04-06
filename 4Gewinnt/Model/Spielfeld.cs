using System;
using System.Collections.Generic;
using System.Text;
using VierGewinnt.Model;

namespace VierGewinnt
{
    class Spielfeld
    {
        public int SpaltenX;
        public int ZeilenY;
        public int posX;
        public int posY;

        public Spielfeld(int spaltenX, int zeilenY)
        {
            SpaltenX = spaltenX;
            ZeilenY = zeilenY;
            int[,] feld = new int[SpaltenX, ZeilenY];
            Spieler player = new Spieler();
            player.player1 = true;

        }

        public void feldBesetzen(int x)
        {
            posX = x;
            posY = 0;
        }

        public bool IstFeldBesetzt(int x, int y)
        {
           if(x == posX && y == posY)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}