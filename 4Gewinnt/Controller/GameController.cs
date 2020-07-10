using _4Gewinnt.Model;
using _4Gewinnt.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace _4Gewinnt.Controller
{
    public class GameController
    {
        public int Y;
        public int X;
        public Spielfeld spielfeld;
        public Spieler spieler;
        public Spiel spiel;
        public GameController game;
        public GameTUI tui;
        string gewaehlteSpalte;
        string neustart;
        public int anzSpalten = 0;
        public int anzZeilen = 0;

        //Game Konstruktor: User-Input Anzahl Zeilen und Spalten, X und Y setzen und Spiel starten
        public GameController()
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
            tui = spiel.tui;
            tui.spielfeld = spielfeld;
            tui.Y = Y;
            tui.X = X;
            FeldBesetzen(spielfeld, spieler);
        }

        //User-Input: Anzahl Zeilen und Spalten
        private void AnzZeilenSpalten()
        {
            //min 5 Spalten
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

            //min 5 Zeilen
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

        private void Neustart()
        {
            tui.SpielfeldZeichnen();
            if (spielfeld.spieler1Won)
            {
                Console.WriteLine("Spieler 1 hat gewonnen!");
            }
            else if (spielfeld.spieler2Won)
            {
                Console.WriteLine("Spieler 2 hat gewonnen!");
            }
            else
            {
                Console.WriteLine("unentschieden!");
            }

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
                    if (spielfeld.spieler1Won)
                    {
                        spielfeld.spieler1Won = false;
                    }
                    else if (spielfeld.spieler2Won)
                    {
                        spielfeld.spieler2Won = false;
                    }
                    else
                    {
                        spielfeld.unentschieden = false;
                    }

                    spieler.SwitchPlayer();

                }
                else if (neustart == "n")
                {
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Falscher Wert!");
                }
            }
            neustart = null;
        }

        private int SpalteWaehlen()
        {
            int gewSpalte = 0;
            if (spieler.player1 == true)
            {
                Console.WriteLine("Spieler 1, wähle eine Spalte: ");
            }
            else
            {
                Console.WriteLine("Spieler 2, wähle eine Spalte: ");
            }

            //User-Input: Spalte wählen
            gewaehlteSpalte = Console.ReadLine();
            try
            {
                gewSpalte = Int32.Parse(gewaehlteSpalte);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
            }

            return gewSpalte;
        }

        public void FeldBesetzen(Spielfeld spielfeld, Spieler spieler)
        {
            int gewSpalte = 0;
            tui.SpielfeldZeichnen();

            while (true)
            {
                gewSpalte = SpalteWaehlen();

                //wenn gewählte Spalte positiv, dann Feld besetzen
                if (gewSpalte >= 0)
                {
                    spielfeld.FeldBesetzen(gewSpalte, spieler);
                }
                else
                {
                    spielfeld.outOfBounds = true;
                }


                //Warnung bei Out of Bounds und vollen Spalten
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

                //jemand gewinnt o. unentschieden -> message und neustart Abfrage
                if (spielfeld.spieler1Won || spielfeld.spieler2Won || spielfeld.unentschieden)
                {
                    Neustart();
                }

                tui.SpielfeldZeichnen();
            }


        }

    }
}
