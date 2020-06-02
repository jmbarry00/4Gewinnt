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
        Spiel spiel;
        string gewaehlteSpalte;
        public GameTUI(int y, int x)
        {

            Y = y;
            X = x;

            spiel = new Spiel(Y, X);
            spiel.spielStarten();
        }

        private void SpielfeldZeichnen()
        {
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


        //wo aufrufen?
        private void FeldBesetzen()
        {
            SpielfeldZeichnen();
            Console.WriteLine("Wähle eine Spalte: ");
            gewaehlteSpalte = Console.ReadLine();
            spielfeld.FeldBesetzen(Convert.ToInt32(gewaehlteSpalte), spieler);
        }
        
    }
}
