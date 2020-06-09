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
                        string value = Convert.ToString(spielfeld.feld[row, col]);
                        if (spielfeld.feld[row, col] == 0)
                        {
                            value = " ";
                        }
                        Console.Write("| " + value + " ");
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

        //public bool spieler1Won = false;
        //public bool spieler2Won = false;
        //public bool unentschieden = false;
        //public bool outOfBounds = false;
        //public bool spalteVoll = false;

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
                
                if (spielfeld.outOfBounds == true)
                {
                    Console.WriteLine("Diese Spalte gibt es nicht!");
                    spieler.SwitchPlayer();
                }
                if (spielfeld.spalteVoll == true)
                {
                    Console.WriteLine("Diese Spalte ist schon voll!");
                    spieler.SwitchPlayer();
                }

            }
            if (spielfeld.spieler1Won == true)
            {
                Console.WriteLine("Spieler 1 hat gewonnen!");
                return;
            }
            if (spielfeld.spieler2Won == true)
            {
                Console.WriteLine("Spieler 2 hat gewonnen!");
                return;
            }
            if (spielfeld.unentschieden == true)
            {
                Console.WriteLine("unentschieden!");
                return;
            }
        }
        
    }
}
