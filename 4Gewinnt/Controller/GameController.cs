using _4Gewinnt.Model;
using _4Gewinnt.View;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _4Gewinnt.Controller
{
    public class GameController : IObservable
    {
        public GameTUI tui;
        public GameGUI gui;
        public Spiel spiel;
        public Spielfeld spielfeld;
        public Spieler spieler;
        public int[,] feld;
        bool spieler1Won;
        bool spieler2Won;
        bool unentschieden;
        bool player1;
        bool player2;
        bool outOfBounds;
        bool spalteVoll;
        public bool neustart = false;
        String labelText;

        public int zeilenY;
        public int spaltenX;
        public int gewaehlteSpalte = -1;

        readonly List<IObserver> observers = new List<IObserver>();
        readonly List<IDisplay> displays = new List<IDisplay>();

        private static GameController _instance;

        private GameController(int Zeilen, int Spalten)
        {
            int anzZeilen = Zeilen;
            int anzSpalten = Spalten;
            spiel = new Spiel(anzZeilen, anzSpalten);
            spiel.SpielStarten();
            spieler = spiel.spieler;
            spielfeld = spiel.spielfeld;

            this.gui = GameGUI.GetInstance(this);
            this.tui = GameTUI.GetInstance(this);

            this.Add(gui);
            this.Add(tui);
            this.AddDisplay(gui);
            this.AddDisplay(tui);
                
            feld = this.Feld;
            spieler1Won = this.Spieler1Won;
            spieler2Won = this.Spieler2Won;
            unentschieden = this.Unentschieden;
            player1 = this.Spieler1;
            player2 = this.Spieler2;
            outOfBounds = this.OutOfBounds;
            spalteVoll = this.SpalteVoll;
            this.ZeilenY = Zeilen;
            this.SpaltenX = Spalten;

            ControllerGetModelData();

            Parallel.Invoke(
            () =>
            {
                tui.Playing();
            },
            () =>
            {
                gui.ShowDialog();
            }
        );
        }

        public static GameController GetInstance(int anzZeilen, int anzSpalten)
        {
            if (_instance == null)
            {
                _instance = new GameController(anzZeilen, anzSpalten);
            }
            return _instance;
        }

        private void ControllerGetModelData()
        {
            feld = spielfeld.feld;
            spieler1Won = spielfeld.spieler1Won;
            spieler2Won = spielfeld.spieler2Won;
            unentschieden = spielfeld.unentschieden;
            player1 = spieler.player1;
            player2 = spieler.player2;
            outOfBounds = spielfeld.outOfBounds;
            spalteVoll = spielfeld.spalteVoll;
        }

        public void UpdateModelData()
        {
            spielfeld.feld = feld;
            spielfeld.spieler1Won = spieler1Won;
            spielfeld.spieler2Won = spieler2Won;
            spielfeld.unentschieden = unentschieden;
            spieler.player1 = player1;
            spieler.player2 = player2;
            spielfeld.outOfBounds = outOfBounds;
            spielfeld.spalteVoll = spalteVoll;
        }

        public int[,] GetFeld()
        {
            return feld;
        }

        public bool GetPlayer1()
        {
            return player1;
        }

        public bool GetPlayer2()
        {
            return player2;
        }

        public bool GetOutOfBounds()
        {
            return outOfBounds;
        }

        public bool GetSpalteVoll()
        {
            return spalteVoll;
        }

        public bool GetUnentschieden()
        {
            return unentschieden;
        }

        public bool GetSpieler1Won()
        {
            return spieler1Won;
        }

        public bool GetSpieler2Won()
        {
            return spieler2Won;
        }



        public void SetViewData(int[,] feld, bool spieler1Won, bool spieler2Won, bool unentschieden, bool player1, bool player2, bool outOfBounds, bool spalteVoll)
        {
            this.feld = feld;
            this.spieler1Won = spieler1Won;
            this.spieler2Won = spieler2Won;
            this.unentschieden = unentschieden;
            this.player1 = player1;
            this.player2 = player2;
            this.outOfBounds = outOfBounds;
            this.spalteVoll = spalteVoll;
        }


        public void Spielen(int gewSpalte)
        {
            spielfeld.FeldBesetzen(gewSpalte, spieler);
            ControllerGetModelData();
        }

        public int GewSpalte
        {
            get { return gewaehlteSpalte; }
            set
            {
                gewaehlteSpalte = value;
                Notify();
            }
        }

        public bool Spieler1Won
        {
            get { return spieler1Won; }
            set
            {
                spieler1Won = value;
                Notify();
            }
        }

        public bool Spieler2Won
        {
            get { return spieler2Won; }
            set
            {
                spieler2Won = value;
                Notify();
            }
        }

        public bool Unentschieden
        {
            get { return unentschieden; }
            set
            {
                unentschieden = value;
                Notify();
            }
        }

        public bool OutOfBounds
        {
            get { return outOfBounds; }
            set
            {
                outOfBounds = value;
                Notify();
            }
        }

        public bool SpalteVoll
        {
            get { return spalteVoll; }
            set
            {
                spalteVoll = value;
                Notify();
            }
        }

        public String Text
        {
            get { return labelText; }
            set
            {
                labelText = value;
                Notify();
            }
        }

        public bool Neustart
        {
            get { return neustart; }
            set
            {
                neustart = value;
                Notify();
            }
        }
       
        public int ZeilenY
        {
            get { return zeilenY; }
            set
            {
                zeilenY = value;
                Notify();
            }
        }

        public int SpaltenX
        {
            get { return spaltenX; }
            set
            {
                spaltenX = value;
                Notify();
            }
        }

        public int[,] Feld
        {
            get { return feld; }
            set
            {
                feld = value;
                Notify();
            }
        }

        public bool Spieler1
        {
            get { return player1; }
            set
            {
                player1 = value;
                Notify();
            }
        }

        public bool Spieler2
        {
            get { return player2; }
            set
            {
                player2 = value;
                Notify();
            }
        }

        public void Add(IObserver observer)
        {
            this.observers.Add(observer);
        }

        public void AddDisplay(IDisplay display)
        {
            this.displays.Add(display);
        }

        public void Remove(IObserver observer)
        {
            this.observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (IObserver observer in this.observers)
            {
                observer.Update();
            }
        }
        public void NotifyDisplays()
        {
            foreach (IDisplay display in this.displays)
            {
                display.Spielfeld();
            }
        }
    }
}
