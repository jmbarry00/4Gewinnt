using System;
using System.Collections.Generic;
using System.Text;
using VierGewinnt.Model;

namespace VierGewinnt
{
    public class Spielfeld
    {
        public int SpaltenX;
        public int ZeilenY;
        public int posX;
        public int posY;

        Spieler player = new Spieler("Spieler1", "Spieler2");

        public Spielfeld(int spaltenX, int zeilenY)
        {
            SpaltenX = spaltenX;
            ZeilenY = zeilenY;
            int[,] feld = new int[SpaltenX, ZeilenY];
            
            player.player1 = true;            
        }

        public void feldBesetzen(int x, int y)
        {
            if (player.player1 == true)
            {
                player.setSpielstein(x, "blau");
            } else
            {
                player.setSpielstein(x, "rot");
            }
            
            posX = x;
            posY = y;
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