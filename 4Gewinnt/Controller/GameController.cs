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
        int anzZeilen;
        int anzSpalten;
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

        List<IObserver> observers = new List<IObserver>();
        List<IDisplay> displays = new List<IDisplay>();

        public GameController(int Zeilen, int Spalten)
        {
            anzZeilen = Zeilen;
            anzSpalten = Spalten;
            spiel = new Spiel(anzZeilen, anzSpalten);
            spiel.spielStarten();
            spieler = spiel.spieler;
            spielfeld = spiel.spielfeld;

            this.gui = new GameGUI(this);
            this.tui = new GameTUI(this);

            this.add(gui);
            this.add(tui);
            this.addDisplay(gui);
            this.addDisplay(tui);

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

        public void updateModelData()
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

        public int[,] getFeld()
        {
            return feld;
        }

        public bool getPlayer1()
        {
            return player1;
        }

        public bool getPlayer2()
        {
            return player2;
        }

        public bool getOutOfBounds()
        {
            return outOfBounds;
        }

        public bool getSpalteVoll()
        {
            return spalteVoll;
        }

        public bool getUnentschieden()
        {
            return unentschieden;
        }

        public bool getSpieler1Won()
        {
            return spieler1Won;
        }

        public bool getSpieler2Won()
        {
            return spieler2Won;
        }



        public void setViewData(int[,] feld, bool spieler1Won, bool spieler2Won, bool unentschieden, bool player1, bool player2, bool outOfBounds, bool spalteVoll)
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

        public int gewSpalte
        {
            get { return gewaehlteSpalte; }
            set
            {
                gewaehlteSpalte = value;
                notify();
            }
        }

        public bool Spieler1Won
        {
            get { return spieler1Won; }
            set
            {
                spieler1Won = value;
                notify();
            }
        }

        public bool Spieler2Won
        {
            get { return spieler2Won; }
            set
            {
                spieler2Won = value;
                notify();
            }
        }

        public bool Unentschieden
        {
            get { return unentschieden; }
            set
            {
                unentschieden = value;
                notify();
            }
        }

        public bool OutOfBounds
        {
            get { return outOfBounds; }
            set
            {
                outOfBounds = value;
                notify();
            }
        }

        public bool SpalteVoll
        {
            get { return spalteVoll; }
            set
            {
                spalteVoll = value;
                notify();
            }
        }

        public String Text
        {
            get { return labelText; }
            set
            {
                labelText = value;
                notify();
            }
        }

        public bool Neustart
        {
            get { return neustart; }
            set
            {
                neustart = value;
                notify();
            }
        }
        /*
        public bool GUINeustart
        {
            get { return guiNeustart; }
            set
            {
                guiNeustart = value;
                notify();
            }
        }
        

        public bool TUINeustart
        {
            get { return tuiNeustart; }
            set
            {
                tuiNeustart = value;
                notify();
            }
        }
        */
        public int ZeilenY
        {
            get { return zeilenY; }
            set
            {
                zeilenY = value;
                notify();
            }
        }

        public int SpaltenX
        {
            get { return spaltenX; }
            set
            {
                spaltenX = value;
                notify();
            }
        }


        public int[,] Feld
        {
            get { return feld; }
            set
            {
                feld = value;
                notify();
            }
        }

        public bool Spieler1
        {
            get { return player1; }
            set
            {
                player1 = value;
                notify();
            }
        }

        public bool Spieler2
        {
            get { return player2; }
            set
            {
                player2 = value;
                notify();
            }
        }

        public void add(IObserver observer)
        {
            this.observers.Add(observer);
        }

        public void addDisplay(IDisplay display)
        {
            this.displays.Add(display);
        }

        public void remove(IObserver observer)
        {
            this.observers.Remove(observer);
        }

        public void notify()
        {
            foreach (IObserver observer in this.observers)
            {
                observer.update();
            }
        }
        public void notifyDisplays()
        {
            foreach (IDisplay display in this.displays)
            {
                display.Spielfeld();
            }
        }
    }
}
