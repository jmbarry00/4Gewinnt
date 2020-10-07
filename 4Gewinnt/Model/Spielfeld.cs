using _4Gewinnt.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace _4Gewinnt
{
    public class Spielfeld : IObservable
    {
        public int ZeilenY;
        public int SpaltenX;
        public int[,] feld;
        public int posX;
        public int posY;
        public int gewaehlteSpalte;
        int spalteP1 = 0;
        int zeileP1 = 0;
        int spalteP2 = 0;
        int zeileP2 = 0;
        

        public bool spieler1Won = false;
        public bool spieler2Won = false;
        public bool unentschieden = false;
        public bool outOfBounds = false;
        public bool spalteVoll = false;
        public String text = "Wassisch los hier?";

        List<IObserver> observers = new List<IObserver>();
        List<IDisplay> displays = new List<IDisplay>();
        //Konstruktor für das Spielfeld
        public Spielfeld(int zeilenY, int spaltenX)
        {
            ZeilenY = zeilenY;
            SpaltenX = spaltenX;
            feld = new int[ZeilenY, SpaltenX];
        }

        //Hier wird in gewählter Spalte x das nächste freie Feld auf 1 gesetzt
        public void FeldBesetzen(int x, Spieler spieler)
        {
            int y = 0;

            //gewählte Spalte darf nicht höher als Anzahl Spalten sein
            if (x < SpaltenX)
            {
                //bei besetzem Feld das nächst freie wählen
                while (IstFeldBesetzt(y, x) == true)
                {
                    //darf nicht weiter als Anzahl Zeilen gehen
                    if (y < ZeilenY - 1)
                    {
                        y++;
                    }
                    else
                    {
                        spalteVoll = true;
                        return;
                    }

                }
            }
            else
            {
                outOfBounds = true;
                return;
            }

            //wenn Spieler 1 an der Reihe, dann Feld auf 1 setzen, schauen ob es Gewinner gibt und Spieler wechseln
            if (spieler.player1 == true)
            {
                feld[y, x] = 1;
                GewinnBerechnung();
                spieler.SwitchPlayer();
            }

            //wenn Spieler 2 an der Reihe, dann Feld auf 2 setzen, schauen ob es Gewinner gibt und Spieler wechseln
            else if (spieler.player2 == true)
            {
                feld[y, x] = 2;
                GewinnBerechnung();
                spieler.SwitchPlayer();

            }


        }

        //Nach jedem Zug wird geprüft, ob ein Sieger vorhanden ist
        private void GewinnBerechnung()
        {
            //Gewinnberechnung waagrecht Spieler 1
            for (int z = 0; z < ZeilenY; z++)
            {
                spalteP1 = 0;
                for (int s = 0; s < SpaltenX; s++)
                {
                    if (feld[z, s] == 1)
                    {
                        spalteP1++;
                        if (spalteP1 == 4)
                        {
                            spieler1Won = true;
                            return;
                        }
                    }
                    else
                    {
                        spalteP1 = 0;
                    }
                }
            }

            //Gewinnberechnung senkrecht Spieler 1
            for (int s = 0; s < SpaltenX; s++)
            {
                zeileP1 = 0;
                for (int z = 0; z < ZeilenY; z++)
                {
                    if (feld[z, s] == 1)
                    {
                        zeileP1++;
                        if (zeileP1 == 4)
                        {
                            spieler1Won = true;
                            return;
                        }
                    }
                    else
                    {
                        zeileP1 = 0;
                    }
                }
            }

            //Gewinnberechnung diagonal Spieler 1
            for (int z = 0; z < ZeilenY; z++)
            {
                for (int s = 0; s < SpaltenX; s++)
                {
                    if ((s < SpaltenX - 3) && (z < ZeilenY - 3) && (feld[z, s] == 1) && (feld[z + 1, s + 1] == 1) && (feld[z + 2, s + 2] == 1) && (feld[z + 3, s + 3] == 1))
                    {
                        spieler1Won = true;
                        return;
                    }

                }
            }

            //Gewinnberechnung diagonal rückwärts Spieler 1
            for (int z = 0; z < ZeilenY; z++)
            {
                for (int s = 0; s < SpaltenX; s++)
                {
                    if ((s > 2) && (z < ZeilenY - 3) && (feld[z, s] == 1) && (feld[z + 1, s - 1] == 1) && (feld[z + 2, s - 2] == 1) && (feld[z + 3, s - 3] == 1))
                    {
                        spieler1Won = true;
                        return;
                    }

                }
            }




            //Gewinnberechnung waagrecht Spieler 2
            for (int z = 0; z < ZeilenY; z++)
            {
                spalteP2 = 0;
                for (int s = 0; s < SpaltenX; s++)
                {
                    if (feld[z, s] == 2)
                    {
                        spalteP2++;
                        if (spalteP2 == 4)
                        {
                            spieler2Won = true;
                            return;
                        }
                    }
                    else
                    {
                        spalteP2 = 0;
                    }
                }
            }

            //Gewinnberechnung senkrecht Spieler 2
            for (int s = 0; s < SpaltenX; s++)
            {
                zeileP2 = 0;
                for (int z = 0; z < ZeilenY; z++)
                {
                    if (feld[z, s] == 2)
                    {
                        zeileP2++;
                        if (zeileP2 == 4)
                        {
                            spieler2Won = true;
                            return;
                        }
                    }
                    else
                    {
                        zeileP2 = 0;
                    }
                }
            }

            //Gewinnberechnung diagonal Spieler 2
            for (int z = 0; z < ZeilenY; z++)
            {
                for (int s = 0; s < SpaltenX; s++)
                {
                    if ((s < SpaltenX - 3) && (z < ZeilenY - 3) && (feld[z, s] == 2) && (feld[z + 1, s + 1] == 2) && (feld[z + 2, s + 2] == 2) && (feld[z + 3, s + 3] == 2))
                    {
                        spieler2Won = true;
                        return;
                    }

                }
            }

            //Gewinnberechnung diagonal rückwärts Spieler 2
            for (int z = 0; z < ZeilenY; z++)
            {
                for (int s = 0; s < SpaltenX; s++)
                {
                    if ((s > 2) && (z < ZeilenY - 3) && (feld[z, s] == 2) && (feld[z + 1, s - 1] == 2) && (feld[z + 2, s - 2] == 2) && (feld[z + 3, s - 3] == 2))
                    {
                        spieler2Won = true;
                        return;
                    }
                }
            }

            for (int z = 0; z < ZeilenY; z++)
            {
                for (int s = 0; s < SpaltenX; s++)
                {
                    if (IstFeldBesetzt(z, s) == false)
                    {
                        return;
                    }
                }
            }
            unentschieden = true;

        }

        public bool IstFeldBesetzt(int y, int x)
        {
            if (feld[y, x] == 1 || feld[y, x] == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
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
            get { return spieler1Won; }
            set
            {
                spieler1Won = value;
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
            get { return text; }
            set
            {
                text = value;
                notify();
            }
        }

        public int zeilenY
        {
            get { return ZeilenY; }
            set
            {
                ZeilenY = value;
                notify();
            }
        }

        public int spaltenX
        {
            get { return SpaltenX; }
            set
            {
                SpaltenX = value;
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
            foreach(IObserver observer in this.observers)
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