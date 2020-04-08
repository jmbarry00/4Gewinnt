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

        public Spieler(String Name, String Farbe)
        {
            name = getNameP1(Name);
            farbe = getFarbe(Farbe);
            player1 = true;
        }

        public string getNameP1(String n)
        {
            return n;
        }

        public string getFarbe(String f)
        {
            return f;
        }

        public void switchPlayer()
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

        public void setSpielstein(int Spalte, int Zeile, string Farbe)
        {
            Spielstein spielstein = new Spielstein(Spalte, Zeile, Farbe);
        }

    }
}