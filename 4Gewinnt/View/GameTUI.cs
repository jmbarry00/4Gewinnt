﻿using _4Gewinnt.Model;
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
        string gewaehlteSpalte;
        string neustart;
        public int anzSpalten = 0;
        public int anzZeilen = 0;
        public GameTUI()
        {
            AnzZeilenSpalten();
            int y = anzZeilen;
            int x = anzSpalten;
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
            for (int row = Y; row >= 0; row--)
            {
                for (int col = 0; col < X; col++)
                {
                    Console.Write("- - ");
                }
                Console.Write("-\n");
                for (int col = 0; col < X; col++)
                {
                    if (row == Y)
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
        private void AnzZeilenSpalten()
        {            

            while (anzSpalten < 5)
            {

                Console.WriteLine("Wähle Anzahl Spalten für Spielfeld(min 5): ");
                string anzahlSpalte = Console.ReadLine();
                try
                {
                    anzSpalten = Int32.Parse(anzahlSpalte);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            while (anzZeilen < 5)
            {
                Console.WriteLine("Wähle Anzahl Zeilen für Spielfeld(min 5): ");
                string anzahlZeilen = Console.ReadLine();
                try
                {
                    anzZeilen = Int32.Parse(anzahlZeilen);
                }

                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }


        private void FeldBesetzen(Spielfeld spielfeld, Spieler spieler)
        {
            int gewSpalte = 0;
            SpielfeldZeichnen();

            while (true)
            {
                if (spieler.player1 == true)
                {
                    Console.WriteLine("Spieler 1, wähle eine Spalte: ");
                }
                else
                {
                    Console.WriteLine("Spieler 2, wähle eine Spalte: ");
                }

                gewaehlteSpalte = Console.ReadLine();
                try
                {
                    gewSpalte = Int32.Parse(gewaehlteSpalte);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                spielfeld.FeldBesetzen(gewSpalte, spieler);
                SpielfeldZeichnen();

                if (spielfeld.outOfBounds == true)
                {
                    Console.WriteLine("Diese Spalte gibt es nicht!");
                    spielfeld.outOfBounds = false;
                }
                if (spielfeld.spalteVoll == true)
                {
                    Console.WriteLine("Diese Spalte ist schon voll!");
                    spielfeld.spalteVoll = false;
                }

                if (spielfeld.spieler1Won == true)
                {
                    Console.WriteLine("Spieler 1 hat gewonnen!");
                    Console.WriteLine("Spiel neustarten? y/n:");

                    while (neustart != "y" && neustart != "n")
                    {
                        try
                        {
                            neustart = Console.ReadLine();
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        if (neustart == "y")
                        {
                            for (int row = Y - 1; row >= 0; row--)
                            {
                                for (int col = 0; col < X; col++)
                                {
                                    spielfeld.feld[row, col] = 0;
                                }
                            }
                            spielfeld.spieler1Won = false;
                            spieler.player1 = true;
                        }
                        else if (neustart == "n")
                        {
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Falscher Wert!");
                        }
                    }

                }

                if (spielfeld.spieler2Won == true)
                {
                    Console.WriteLine("Spieler 2 hat gewonnen!");
                    Console.WriteLine("Spiel neustarten? y/n:");

                    while (neustart != "y" && neustart != "n")
                    {
                        try
                        {
                            neustart = Console.ReadLine();
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        if (neustart == "y")
                        {
                            for (int row = Y - 1; row >= 0; row--)
                            {
                                for (int col = 0; col < X; col++)
                                {
                                    spielfeld.feld[row, col] = 0;
                                }
                            }
                            spielfeld.spieler2Won = false;
                            spieler.player1 = true;
                        }
                        else if (neustart == "n")
                        {
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Falscher Wert!");
                        }
                    }
                }
                if (spielfeld.unentschieden == true)
                {
                    Console.WriteLine("unentschieden!");
                    Console.WriteLine("Spiel neustarten? y/n:");

                    while (neustart != "y" && neustart != "n")
                    {
                        try
                        {
                            neustart = Console.ReadLine();
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine(e.Message);
                        }

                        if (neustart == "y")
                        {
                            for (int row = Y - 1; row >= 0; row--)
                            {
                                for (int col = 0; col < X; col++)
                                {
                                    spielfeld.feld[row, col] = 0;
                                }
                            }
                            spielfeld.unentschieden = false;
                            spieler.player1 = true;
                        }
                        else if (neustart == "n")
                        {
                            return;
                        }
                        else
                        {
                            Console.WriteLine("Falscher Wert!");
                        }
                    }
                }
            }
                
                
            }
            
        }
        
    
}
