using _4Gewinnt.Controller;
using _4Gewinnt.Model;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace _4Gewinnt.View
{
    public class GameTUI : IObserver, IDisplay
    {

        int Y;
        int X;
        int anzSpalten = 0;
        int anzZeilen = 0;
        GameController Ctr;
        Spielfeld spielfeld;
        Spieler spieler;
        bool player1;
        bool player2;
        int[,] feld;
        string gewaehlteSpalte;
        int gewSpalte;
        int Spalte = -1;
        DialogResult neustartGUI;
        string neustart;
        string text;
        
        bool spieler1Won;
        bool spieler2Won;
        bool unentschieden;
        bool outOfBounds;
        bool spalteVoll;


        //Game Konstruktor: User-Input Anzahl Zeilen und Spalten, X und Y setzen und Spiel starten
        public GameTUI(GameController ctr)
        {
            this.Ctr = ctr;
            spieler = Ctr.spieler;
            spielfeld = Ctr.spielfeld;
        }

        private void getControllerData()
        {
            feld = Ctr.getFeld();
            spieler1Won = Ctr.getSpieler1Won();
            spieler2Won = Ctr.getSpieler2Won();
            unentschieden = Ctr.getUnentschieden();
            player1 = Ctr.getPlayer1();
            player2 = Ctr.getPlayer2();
            outOfBounds = Ctr.getOutOfBounds();
            spalteVoll = Ctr.getSpalteVoll();
        }

        public void Playing()
        {
            getControllerData();
            Game(spielfeld, spieler);
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
                    }
                    else
                    //die anderen Felder werden mit den Werten von feld[,] verknüpft
                    {
                        string value = Convert.ToString(feld[row, col]);
                        if (feld[row, col] == 0)
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

        //User-Input: Neustart ja/nein
        private void Neustart()
        {
            spielfeld.notifyDisplays();
            if (spieler1Won)
            {
                Console.WriteLine("Spieler 1 hat gewonnen!");
                spielfeld.Text = "Spieler 1 hat gewonnen!";
                //Ctr.gui.setLabel1Text("Spieler 1 hat gewonnen!");
            }
            else if (spieler2Won)
            {
                Console.WriteLine("Spieler 2 hat gewonnen!");
                //Ctr.gui.label1.Text = "Spieler 2 hat gewonnen!";
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
                            feld[row, col] = 0;
                        }
                    }
                    if (spieler1Won)
                    {
                        spieler1Won = false;
                    }
                    else if (spieler2Won)
                    {
                        spieler2Won = false;
                    }
                    else
                    {
                        unentschieden = false;
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
            Ctr.setViewData(feld, spieler1Won, spieler2Won, unentschieden, player1, player2, outOfBounds, spalteVoll);
            Ctr.updateModelData();
        }

        public int SpalteWaehlen()
        {

            while (true)
            {
                if (player1 == true)
                {
                    Console.WriteLine("Spieler 1, wähle eine Spalte: ");
                }
                else
                {
                    Console.WriteLine("Spieler 2, wähle eine Spalte: ");
                }

                //...

                //User-Input: Spalte wählen
                gewaehlteSpalte = Console.ReadLine();

                try
                {
                    Spalte = Int32.Parse(gewaehlteSpalte);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }

                if (gewaehlteSpalte != "")
                {
                    return Spalte;
                }
                
            }
        }

        public void Game(Spielfeld spielfeld, Spieler spieler)
        {
            //int gewSpalte = 0;
            //spielfeld.notifyDisplays();
            SpielfeldZeichnen();
            while (true)
            {
                spielfeld.gewSpalte = SpalteWaehlen();

                if (gewSpalte >= 0)
                {
                    Ctr.Spielen(gewSpalte);
                    getControllerData();
                }
                else
                {
                    outOfBounds = true;
                }


                //Warnung bei Out of Bounds und vollen Spalten
                if (outOfBounds == true)
                {
                    Console.WriteLine("Diese Spalte gibt es nicht!");
                    outOfBounds = false;
                }
                if (spalteVoll == true)
                {
                    Console.WriteLine("Diese Spalte ist schon voll!");
                    spalteVoll = false;
                }

                //update Data of GameTui
                Ctr.setViewData(feld, spieler1Won, spieler2Won, unentschieden, player1, player2, outOfBounds, spalteVoll);
                //update Model Data
                Ctr.updateModelData();

                //jemand gewinnt o. unentschieden -> message und neustart Abfrage
                if (spieler1Won || spieler2Won || unentschieden)
                {
                    Neustart();
                }

                spielfeld.notifyDisplays();
            }


        }

        public void update()
        {
            X = spielfeld.spaltenX;
            Y = spielfeld.zeilenY;
            gewSpalte = spielfeld.gewSpalte;
            feld = spielfeld.Feld;
            spieler1Won = spielfeld.Spieler1Won;
            spieler2Won = spielfeld.Spieler2Won;
            unentschieden = spielfeld.Unentschieden;
            player1 = spieler.Spieler1;
            player2 = spieler.Spieler2;
            outOfBounds = spielfeld.OutOfBounds;
            spalteVoll = spielfeld.SpalteVoll;
            text = spielfeld.Text;

            if (true)
            {

            }
        }

        public void Spielfeld()
        {
            SpielfeldZeichnen();
        }

        public void SpalteVollText()
        {
            
        }
    }




}



