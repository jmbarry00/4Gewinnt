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


        public Spielfeld(int spaltenX, int zeilenY)
        {
            SpaltenX = spaltenX;
            ZeilenY = zeilenY;
            int[,] feld = new int[SpaltenX, ZeilenY];
            Spieler player = new Spieler();
            player.player1 = true;

        }

        public void feldBesetzen()
        {

        }
    }
}