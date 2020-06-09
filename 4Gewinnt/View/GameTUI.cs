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
            spielfeld = spiel.spielfeld;
            spieler = spiel.spieler;
            FeldBesetzen(spielfeld, spieler);
        }

        private void SpielfeldZeichnen()
        {
            for (int row = Y-1; row >= 0; row--)
            {
                for (int col = 0; col < X; col++)
                {
                    Console.Write("- - ");
                }
                Console.Write("-\n");
                for (int col = 0; col < X; col++)
                {
                    if (row == Y-1)
                    {
                        Console.Write("| " + col + " ");
                    } else
                    {
                        Console.Write("| " + spielfeld.feld[row, col] + " ");
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


      
        private void FeldBesetzen(Spielfeld spielfeld, Spieler spieler)
        {
            while (spielfeld.spieler1Won != true || spielfeld.spieler2Won != true || spielfeld.unentschieden != true)
            {
                SpielfeldZeichnen();
                if(spieler.player1 == true)
                {
                    Console.WriteLine("Spieler 1, wähle eine Spalte: ");
                } else
                {
                    Console.WriteLine("Spieler 2, wähle eine Spalte: ");
                }
                
                gewaehlteSpalte = Console.ReadLine();
                spielfeld.FeldBesetzen(Convert.ToInt32(gewaehlteSpalte), spieler);
            }            
        }
        
    }
}
