using System;
using System.Collections.Generic;
using System.Text;
using VierGewinnt.Model;

namespace VierGewinnt
{
    public class Spielfeld
    {
        private int SpaltenX;
        private int ZeilenY;
        private int[,] feld;
        private int posX;
        private int posY;

        Spieler player = new Spieler("Spieler1", "blau");

        public Spielfeld(int spaltenX, int zeilenY)
        {
            SpaltenX = spaltenX;
            ZeilenY = zeilenY;
            feld = new int[SpaltenX, ZeilenY];
        }

        public void feldBesetzen(int x, int y)
        {
            string farbe;
            y = 0;

            while(IstFeldBesetzt(x,y) == true)
            {
                y++;
            }

            if (player.player1 == true)
            {
                farbe = "blau";
                player.setSpielstein(x, y, farbe);
            } else
            {
                farbe = "rot";
                player.setSpielstein(x, y, farbe);
            }

            player.switchPlayer();
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