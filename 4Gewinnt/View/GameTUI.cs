using System;
using System.Collections.Generic;
using System.Text;

namespace _4Gewinnt.View
{
    class GameTUI
    {
        public GameTUI()
        {

        }

        public void SpielfeldZeîchnen(int y, int x)
        {
            for (int row = 0; row <= y; row++)
            {
                for (int col = 0; col <= x; col++)
                {
                    Console.Write("- - ");
                }
                Console.Write("-\n");
                for (int col = 0; col <= x; col++)
                {
                    if (row == 0)
                    {
                        Console.Write("| " + col + " ");
                    } else
                    {
                        Console.Write("|   ");
                    }
                    
                }
                Console.Write("|");
                Console.Write("\n");
            }
            for (int col = 0; col <= x; col++)
            {
                Console.Write("- - ");
            }
            Console.Write("-\n");
        }
    }
}
