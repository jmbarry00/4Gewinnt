using System;
using System.Collections.Generic;
using System.Text;

namespace VierGewinnt.Model
{
    class Spieler
    {
        public bool player1 = false;
        public bool player2 = false;

        public string getNameP1()
        {
            return "Spieler1";
        }

        public string getNameP2()
        {
            return "Spieler2";
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

    }
}