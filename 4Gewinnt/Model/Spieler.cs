using _4Gewinnt.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4Gewinnt.Model
{
    public class Spieler
    {
        public string name;
        public string farbe;
        public bool player1 = true;
        public bool player2 = false;
        public int inARowP1 = 0;
        public int inARowP2 = 0;

        public Spieler(String Farbe)
        {
            farbe = Farbe;
        }


        public void SwitchPlayer()
        {
            player1 = (player1 == true) ? false : true;
            player2 = (player2 == true) ? false : true;
        }

    }
}