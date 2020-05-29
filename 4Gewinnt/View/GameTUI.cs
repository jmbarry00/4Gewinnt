using _4Gewinnt.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4Gewinnt.View
{
    class GameTUI
    {
        int X;
        int Y;
        public GameTUI(int y, int x)
        {
            X = x;
            Y = y;
            Spiel spiel = new Spiel(X, Y);
            SpielfeldZeichnen();
        }

        private void SpielfeldZeichnen()
        {
            Spielfeld spielfeld = new Spielfeld(Y, X);
            for (int row = 0; row < Y+1; row++)
            {
                for (int col = 0; col < X; col++)
                {
                    Console.Write("- - ");
                }
                Console.Write("-\n");
                for (int col = 0; col < X; col++)
                {
                    if (row == 0)
                    {
                        Console.Write("| " + col + " ");
                    } else
                    {
                        Console.Write("| {0} ",col);
                    }
                    
                }
                Console.Write("|");
                Console.Write("\n");
            }
            for (int col = 0; col < X; col++)
            {
                Console.Write("- - ");
            }
            Console.Write("-\n");
        }

        
    }
}
