using _4Gewinnt.Controller;
using _4Gewinnt.Model;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace _4Gewinnt.View
{
    class GameTUI
    {

        int Y;
        int X;
        Spielfeld spielfeld;
        Spieler spieler;
        Spiel spiel;
        public GameController game;
        string gewaehlteSpalte;
        string neustart;
        public int anzSpalten = 0;
        public int anzZeilen = 0;

        //Game Konstruktor: User-Input Anzahl Zeilen und Spalten, X und Y setzen und Spiel starten
        public GameTUI()
        {

            Y = game.Y;
            X = game.X;

            spielfeld = game.spielfeld;
            spieler = game.spieler;

            game.FeldBesetzen(spielfeld, spieler);
        }

        public void SpielfeldZeichnen()
        {
            for (int row = Y; row >= 0; row--)
            {
                for (int col = 0; col < X; col++)
                {
                    //Linie zeichnen
                    Console.Write("- - ");
                }
                Console.Write("-\n");
                for (int col = 0; col < X; col++)
                {
                    //erste Reihe Beschriftung
                    if (row == Y)
                    {
                        Console.Write("| " + col + " ");
                    } else
                    //die anderen Felder werden mit den Werten von feld[,] verknüpft
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
                //Linie zeichnen
                Console.Write("- - ");
            }
            Console.Write("-\n\n");
        }

        
            
        }
        
    
}
