using _4Gewinnt.Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace _4Gewinnt
{
    public class Spielfeld
    {
        public int SpaltenX;
        public int ZeilenY;
        private int[,] feld;
        private int posX;
        private int posY;

        Spieler player;
        Spielstein spielstein;
        public Spielfeld(int spaltenX, int zeilenY)
        {
            SpaltenX = spaltenX;
            ZeilenY = zeilenY;
            feld = new int[SpaltenX, ZeilenY];
            player = new Spieler("Spieler1", "blau");
        }

        public void FeldBesetzen(int x)
        {
            string farbe;
            int y = 0;

            while(IstFeldBesetzt(x,y) == true)
            {
                y++;
            }

            if (player.player1 == true)
            {
                farbe = "blau";
                player.SetSpielstein(x, y, farbe);
            } else
            {
                farbe = "rot";
                player.SetSpielstein(x, y, farbe);
            }

            player.SwitchPlayer();
            posX = x;
            posY = y;
            spielstein.spalte = x;
            spielstein.zeile = y;
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

        public void HatGewonnen(int spieler)
        {
            Console.WriteLine("Spieler"+spieler+"hat gewonnen");
        }
    }
}