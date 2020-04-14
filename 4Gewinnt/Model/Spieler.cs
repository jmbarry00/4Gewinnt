using _4Gewinnt.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace VierGewinnt.Model
{
    public class Spieler
    {
        public string name;
        public string farbe;
        public bool player1 = false;
        public bool player2 = false;
        public int inARowP1 = 0;
        public int inARowP2 = 0;

        public Spieler(String Name, String Farbe)
        {
            name = GetNameP1(Name);
            farbe = GetFarbe(Farbe);
            player1 = true;
        }

        public string GetNameP1(String n)
        {
            return n;
        }

        public string GetFarbe(String f)
        {
            return f;
        }

        public void SwitchPlayer()
        {
            if (player1 == true)
            {
                player1 = false;
                player2 = true;

            }
            else
            {
                player1 = true;
                player2 = false;
            }
        }

        public void SetSpielstein(int Spalte, int Zeile, string Farbe)
        {
            Spielstein spielstein = new Spielstein(Spalte, Zeile, Farbe);
        }

    }
}