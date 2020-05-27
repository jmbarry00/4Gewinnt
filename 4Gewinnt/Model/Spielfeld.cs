using _4Gewinnt.Features;
using _4Gewinnt.Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace _4Gewinnt
{
    public class Spielfeld
    {        
        public int ZeilenY;
        public int SpaltenX;
        public int[,] feld;
        public int posX;
        public int posY;
        int spalteP1 = 0;
        int zeileP1 = 0;
        int spalteP2 = 0;
        int zeileP2 = 0;

        public bool spieler1Won = false;
        public bool spieler2Won = false;
        public bool unentschieden = false;
        public bool outOfBounds = false;
        public bool spalteVoll = false;


        public Spielfeld(int zeilenY, int spaltenX)
        {
            
            ZeilenY = zeilenY;
            SpaltenX = spaltenX;
            feld = new int[ZeilenY, SpaltenX];
        }

        public void FeldBesetzen(int x, Spieler spieler)
        {
            int y = 0;

            if (x < SpaltenX)
            {
                while (IstFeldBesetzt(y, x) == true)
                {
                    if (y < ZeilenY - 1)
                    {
                        y++;
                    }
                    else
                    {
                        spalteVoll = true;
                        SpalteVoll();
                        return;
                    }

                }
            } else
            {
                outOfBounds = true;
                OutOfBounds();
                return;
            }

            
            if (spieler.player1 == true)
            {
                feld[y, x] = 1;
                GewinnBerechnung();
                spieler.SwitchPlayer();
            }
            else if (spieler.player2 == true)
            {
                feld[y, x] = 2;
                GewinnBerechnung();
                spieler.SwitchPlayer();

            }                      
                
            
        }

        private void OutOfBounds()
        {          
           Console.WriteLine("Diese Spalte gibt es nicht, bitte wähle eine Spalte auf dem Feld!");           
        }

        private void SpalteVoll()
        {
            Console.WriteLine("Diese Spalte ist ausgefüllt, bitte wähle eine andere!");
        }

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
                            HatGewonnen(1);
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
                            HatGewonnen(1);
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
                    if ((s < SpaltenX - 3) && (z < ZeilenY - 3) && (feld[z, s] == 1) && (feld[z+1,s+1] == 1) && (feld[z + 2, s+ 2] == 1)  && (feld[z+3, s+3] == 1))
                        {   
                            HatGewonnen(1);
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
                    if ((s > 2) && (z < ZeilenY - 3) && (feld[z, s] == 1) && (feld[z + 1, s - 1] == 1) && (feld[z + 2, s -2] == 1) && (feld[z + 3, s - 3] == 1))
                    {
                        HatGewonnen(1);
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
                            HatGewonnen(2);
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
                            HatGewonnen(2);
                            spieler2Won = true;
                            return;
                        }
                    } else
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
                        HatGewonnen(2);
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
                        HatGewonnen(1);
                        spieler2Won = true;
                        return;
                    }
                }
            }

            if (spieler1Won == false && spieler2Won == false)
            {
                Console.WriteLine("Unentschieden");
                unentschieden = true;
            }

        }

        public bool IstFeldBesetzt(int y, int x)
        {
           if(feld[y, x] == 1 || feld[y, x] == 2)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public void HatGewonnen(int spieler)
        {
            Console.WriteLine("Spieler"+spieler+"hat gewonnen");
        }
    }
}