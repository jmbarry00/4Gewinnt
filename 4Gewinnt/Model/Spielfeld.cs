﻿using _4Gewinnt.Features;
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
        public bool spielerSteps = false;
        Spiel spiel;

        public Spielfeld(int zeilenY, int spaltenX)
        {            
            ZeilenY = zeilenY;
            SpaltenX = spaltenX;
            feld = new int[ZeilenY, SpaltenX];
        }

        public void FeldBesetzen(int x)
        {
            string farbe = "";
            Spieler player = new Spieler(farbe);

            int y = 0;

            while(IstFeldBesetzt(y,x) == true)
            {
                y++;
            }

            if (player.player1 == true)
            {                
                farbe = "blau";
                //player.SetSpielstein(x, y, farbe);
                feld[x, y] = 1;
            } else if (player.player2 == true)
            {
                farbe = "rot";
                //player.SetSpielstein(x, y, farbe);
                feld[x, y] = 2;
            }            
            
            GewinnBerechnung();
            
            

            player.SwitchPlayer();
        }

        private void GewinnBerechnung()
        {            
            //Gewinnberechnung waagrecht Spieler 1
            for (int z = 0; z < ZeilenY; z++)
            {
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
                    if ((feld[z, s] == 1) && (feld[z+1,s+1] == 1) && (feld[z + 2, s+ 2] == 1)  && (feld[z+3, s+3] == 1) && s < SpaltenX - 3 && z < ZeilenY - 3)
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
                    if ((feld[z, s] == 1) && (feld[z + 1, s - 1] == 1) && (feld[z + 2, s -2] == 1) && (feld[z + 3, s - 3] == 1) && s > 3 && z > 3)
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
                    if ((feld[z, s] == 2) && (feld[s + 1, z + 1] == 2) && (feld[s + 2, z + 2] == 2) && (feld[s + 3, z + 3] == 2) && s < SpaltenX - 3 && z < ZeilenY - 3)
                    {
                        HatGewonnen(2);
                        spieler1Won = true;
                        return;
                    }

                }
            }

            //Gewinnberechnung diagonal rückwärts Spieler 2
            for (int z = 0; z < ZeilenY; z++)
            {
                for (int s = 0; s < SpaltenX; s++)
                {
                    if ((feld[z, s] == 2) && (feld[z + 1, s - 1] == 2) && (feld[z + 2, s - 2] == 2) && (feld[z + 3, s - 3] == 2) && s > 3 && z > 3)
                    {
                        HatGewonnen(1);
                        spieler1Won = true;
                        return;
                    }

                }
            }

        }

        public bool IstFeldBesetzt(int x, int y)
        {
           if(feld[x, y] == 1 || feld[x, y] == 2)
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