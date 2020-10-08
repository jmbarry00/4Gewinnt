using System.Collections.Generic;

namespace _4Gewinnt.Model
{
    public class Spieler
    {
        public bool player1 = true;
        public bool player2 = false;

        public void SwitchPlayer()
        {
            player1 = (player1 == true) ? false : true;
            player2 = (player2 == true) ? false : true;
        }


    }
}