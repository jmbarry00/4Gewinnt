using _4Gewinnt.Controller;
using FluentAssertions;
using System;

namespace _4Gewinnt.View
{
    public class GameTUI : IObserver, IDisplay
    {

        int Y;
        int X;
        readonly GameController Ctr;        
        int[,] feld;
        int gewSpalte;
        int Spalte = -1;
        string gewaehlteSpalte;

        bool player1;
        bool player2;
        bool spieler1Won;
        bool spieler2Won;
        bool unentschieden;
        bool outOfBounds;
        bool spalteVoll;

        private static GameTUI _instance;

        //Game Konstruktor: User-Input Anzahl Zeilen und Spalten, X und Y setzen und Spiel starten
        private GameTUI(GameController ctr)
        {
            this.Ctr = ctr;
        }

        public static GameTUI GetInstance(GameController ctr)
        {
            if (_instance == null)
            {
                _instance = new GameTUI(ctr);
            }
            return _instance;
        }

        private void GetControllerData()
        {
            feld = Ctr.GetFeld();
            spieler1Won = Ctr.GetSpieler1Won();
            spieler2Won = Ctr.GetSpieler2Won();
            unentschieden = Ctr.GetUnentschieden();
            player1 = Ctr.GetPlayer1();
            player2 = Ctr.GetPlayer2();
            outOfBounds = Ctr.GetOutOfBounds();
            spalteVoll = Ctr.GetSpalteVoll();
        }

        public void Playing()
        {
            GetControllerData();
            Game();
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

        public void EndOutput()
        {
            string endOutput;
            SpielfeldZeichnen();

            endOutput = Ctr.Spieler1Won ? "Spieler 1 hat gewonnen!" : Ctr.Spieler2Won ? "Spieler 2 hat gewonnen!" : "unentschieden!";
            Console.WriteLine(endOutput);
            Ctr.Text = endOutput;

            Console.WriteLine("Spiel neustarten? y/n:");
        }

        //User-Input: Neustart ja/nein
        private void Neustart()
        {
            EndOutput();
            Ctr.Neustart = true;
            //update Data of GameTui
            Ctr.SetViewData(feld, spieler1Won, spieler2Won, unentschieden, player1, player2, outOfBounds, spalteVoll);
            //update Model Data
            Ctr.UpdateModelData();
        }

        public int SpalteWaehlen()
        {
            while (true)
            {
                string gameOutput;
                gameOutput = player1 ? "Spieler 1, wähle eine Spalte: " : "Spieler 2, wähle eine Spalte: ";
                Console.WriteLine(gameOutput);
                Ctr.Text = gameOutput;

                //User-Input: Spalte wählen
                gewaehlteSpalte = Console.ReadLine();

                try
                {
                    Spalte = Int32.Parse(gewaehlteSpalte);
                    return Spalte;
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void Game()
        {
            SpielfeldZeichnen();
            while (true)
            {
                Ctr.GewSpalte = SpalteWaehlen();

                if (gewSpalte >= 0)
                {
                    Ctr.Spielzug(gewSpalte);
                    GetControllerData();
                }
                else
                {
                    outOfBounds = true;
                }

                //Warnung bei Out of Bounds und vollen Spalten
                if (outOfBounds)
                {
                    Console.WriteLine("Diese Spalte gibt es nicht!");
                    outOfBounds = false;
                }
                if (spalteVoll)
                {
                    Console.WriteLine("Diese Spalte ist schon voll!");
                    Ctr.SpalteVoll = false;
                }

                //update Data of GameTui
                Ctr.SetViewData(feld, spieler1Won, spieler2Won, unentschieden, player1, player2, outOfBounds, spalteVoll);
                //update Model Data
                Ctr.UpdateModelData();

                //jemand gewinnt o. unentschieden -> message und neustart Abfrage
                if (spieler1Won || spieler2Won || unentschieden)
                {
                    Neustart();
                }
                else
                {
                    Ctr.NotifyDisplays();
                }
            }
        }

        public void Update()
        {
            X = Ctr.spaltenX;
            Y = Ctr.zeilenY;
            gewSpalte = Ctr.GewSpalte;
            feld = Ctr.Feld;
            spieler1Won = Ctr.Spieler1Won;
            spieler2Won = Ctr.Spieler2Won;
            unentschieden = Ctr.Unentschieden;
            player1 = Ctr.Spieler1;
            player2 = Ctr.Spieler2;
            outOfBounds = Ctr.OutOfBounds;
            spalteVoll = Ctr.SpalteVoll;
        }

        public void SpielfeldUpdate()
        {
            SpielfeldZeichnen();
        }
    }
}



