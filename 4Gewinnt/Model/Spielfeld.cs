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
        public int[,] feld;
        public int posX;
        public int posY;

        public Spielfeld(int spaltenX, int zeilenY)
        {
            SpaltenX = spaltenX;
            ZeilenY = zeilenY;
            feld = new int[SpaltenX, ZeilenY];
        }

        public void FeldBesetzen(int x)
        {
            string farbe = "";
            Spieler player = new Spieler(farbe);

            int y = 0;

            while(IstFeldBesetzt(x,y) == true)
            {
                y++;
            }

            if (player.player1 == true)
            {
                farbe = "blau";
                player.SetSpielstein(x, y, farbe);
            } else if (player.player2 == true)
            {
                farbe = "rot";
                player.SetSpielstein(x, y, farbe);
            }
        
            player.SwitchPlayer();
            feld[x, y] = 1;
        }

        public bool IstFeldBesetzt(int x, int y)
        {
           if(feld[x, y] == 1)
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