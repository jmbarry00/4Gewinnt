using _4Gewinnt.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4Gewinnt.View
{
    class GameTUI
    {

        int Y;
        int X;
        Spielfeld spielfeld;
        Spieler spieler;
        string gewaehlteSpalte;
        public GameTUI(int y, int x)
        {

            Y = y;
            X = x;

            spielfeld = new Spielfeld(Y, X);
            spieler = new Spieler();
            SpielfeldZeichnen();
            FeldBesetzen();
        }

        private void SpielfeldZeichnen()
        {
            Spieler spieler = new Spieler();

            //spielfeld.feld.GetValue(1);
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
            Console.Write("-\n\n");
        }

        private void FeldBesetzen()
        {
            Console.WriteLine("Wähle eine Spalte: ");
            gewaehlteSpalte = Console.ReadLine();
            spielfeld.FeldBesetzen(Convert.ToInt32(gewaehlteSpalte), spieler);
        }
        
    }
}
