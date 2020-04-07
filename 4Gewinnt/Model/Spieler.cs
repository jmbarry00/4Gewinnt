using _4Gewinnt.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace VierGewinnt.Model
{
    public class Spieler
    {
        public string nameP1;
        public string nameP2;
        public bool player1 = false;
        public bool player2 = false;

        public Spieler(String Name1, String Name2)
        {
            nameP1 = getNameP1(Name1);
            nameP2 = getNameP1(Name2);
        }

        public string getNameP1(String n)
        {
            return n;
        }

        public string getNameP2(String n)
        {
            return n;
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

        public void setSpielstein(int Spalte, string Farbe)
        {
            Spielstein spielstein = new Spielstein(Spalte, Farbe);
        }

    }
}