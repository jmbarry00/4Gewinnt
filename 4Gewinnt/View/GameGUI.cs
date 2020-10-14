﻿using _4Gewinnt.Controller;
using _4Gewinnt.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace _4Gewinnt.View
{
    public partial class GameGUI : Form, IObserver, IDisplay
    {
        int Y;
        int X;
        int[,] feld;
        int gewSpalte;
        readonly GameController Ctr;
        readonly Spieler spieler;
        Label label1;
        Panel[,] panel;
        Button[] button;
        DialogResult neustart;
        String labelText;
        String endStatus;

        public delegate void UpdateTextCallback(string text);

        bool lastActionAtGUI = false;
        bool player1;
        bool player2;
        bool spieler1Won;
        bool spieler2Won;
        bool unentschieden;
        bool outOfBounds;
        bool spalteVoll;

        private static GameGUI _instance;

        private GameGUI(GameController ctr)
        {
            InitializeComponent();
            this.Ctr = ctr;
            spieler = Ctr.spieler;
        }

        public static GameGUI GetInstance(GameController ctr)
        {
            if (_instance == null)
            {
                _instance = new GameGUI(ctr);
            }
            return _instance;
        }

        private void GameClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        public void Playing()
        {
            GetControllerData();
            Game();
        }

        private void GetControllerData()
        {
            spieler1Won = Ctr.GetSpieler1Won();
            spieler2Won = Ctr.GetSpieler2Won();
            unentschieden = Ctr.GetUnentschieden();
            player1 = Ctr.GetPlayer1();
            player2 = Ctr.GetPlayer2();
            spalteVoll = Ctr.GetSpalteVoll();
        }

        private void GameGUI_Load(object sender, EventArgs e)
        {
            panel = new Panel[Y, X];    //Spielfeld besteht aus Panels
            button = new Button[X];     //Buttons über jeder Spalte
            label1 = new Label();

            this.Controls.Add(label1);
            label1.Location = new Point(15, 15);
            label1.Font = new Font("Arial", 15);
            label1.Text = "Spieler 1, wähle eine Spalte!";
            label1.Width = 300;
            int bottom = 30;
            int panelHeight = 60;
            int panelWidth = 60;
            int panelLeft = 30;
            this.Height = Y * panelHeight + 200;
            this.Width = X * panelWidth + 100;
            int s;
            int z;

            for (s = 0; s < X; s++)
            {
                z = 0;
                panel[z, s] = new Panel();
                button[s] = new Button();
                this.Controls.Add(button[s]);
                button[s].Left = panelLeft;
                button[s].Width = panelWidth;
                button[s].Text = "V";
                button[s].Name = Convert.ToString(s);
                button[s].Top = 100;
                button[s].Click += new EventHandler(ButtonClick);

                for (z = 0; z < Y; z++)
                {
                    panel[z, s] = new Panel();

                    this.Controls.Add(panel[z, s]);
                    panel[z, s].Left = panelLeft;
                    panel[z, s].Width = panelWidth;
                    panel[z, s].Height = panelHeight;
                    panel[z, s].Top = this.ClientSize.Height - panel[z, s].Height - bottom;
                    panel[z, s].BorderStyle = BorderStyle.FixedSingle;
                    bottom += 60;
                }
                panelLeft += panelWidth;
                bottom = 30;
            }
        }

        private void SetLabel1Text(string lb1Text)
        {
            label1.Text = lb1Text;
        }

        //Spalte an Programm übergeben
        private void ButtonClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Ctr.GewSpalte = Convert.ToInt32(btn.Name);
            Console.WriteLine(btn.Name);
            Playing();
        }

        //Spieler 1 => Roter Spielstein, Spieler 2 => Blauer Spielstein
        public void Spielsteine()
        {
            for (int s = 0; s < X; s++)
            {
                for (int z = 0; z < Y; z++)
                {
                    if (feld[z, s] == 1)
                    {
                        panel[z, s].BackColor = Color.Red;
                    }
                    else if (feld[z, s] == 2)
                    {
                        panel[z, s].BackColor = Color.Blue;
                    }
                    else
                    {
                        panel[z, s].BackColor = Color.Transparent;
                    }
                }
            }
        }

        //User-Input: Neustart ja/nein
        public void Neustart()
        {
            if (lastActionAtGUI)
            {
                Ctr.tui.EndOutput();
                lastActionAtGUI = false;
            }
            Spielsteine();
            
            label1.Text = Ctr.Text;
            endStatus = (label1.Text == "unentschieden!") ? "Draw!" : "Victory!";
            neustart = MessageBox.Show("Neustart?", endStatus, MessageBoxButtons.YesNo);

            if (neustart == DialogResult.Yes)
            {
                for (int row = Y - 1; row >= 0; row--)
                {
                    for (int col = 0; col < X; col++)
                    {
                        feld[row, col] = 0;
                    }
                }

                spieler1Won = spieler1Won ? false : spieler2Won ? spieler2Won = false : unentschieden = false;
                spieler.SwitchPlayer();
            }
            else if (neustart == DialogResult.No)
            {
                Environment.Exit(0);
            }

            Ctr.SetViewData(feld, spieler1Won, spieler2Won, unentschieden, player1, player2, outOfBounds, spalteVoll);
            Ctr.UpdateModelData();
        }

        public void Game()
        {
            Ctr.Spielzug(gewSpalte);
            GetControllerData();

            if (spalteVoll)
            {
                Console.WriteLine("Diese Spalte ist schon voll!");
                MessageBox.Show("Diese Spalte ist schon voll!");
                Ctr.SpalteVoll = false;
            }

            Ctr.SetViewData(feld, spieler1Won, spieler2Won, unentschieden, player1, player2, outOfBounds, spalteVoll);
            Ctr.UpdateModelData();

            if (spieler1Won || spieler2Won || unentschieden)
            {
                lastActionAtGUI = true;
                Neustart();
            }

            Ctr.NotifyDisplays();

            Ctr.Text = player1 ? "Spieler 1, wähle eine Spalte:" : "Spieler 2, wähle eine Spalte:";
            label1.Text = Ctr.Text;
            Console.WriteLine(Ctr.Text);
        }

        public new void Update()
        {
            X = Ctr.SpaltenX;
            Y = Ctr.ZeilenY;
            gewSpalte = Ctr.GewSpalte;
            feld = Ctr.Feld;
            spieler1Won = Ctr.Spieler1Won;
            spieler2Won = Ctr.Spieler2Won;
            unentschieden = Ctr.Unentschieden;
            player1 = Ctr.Spieler1;
            player2 = Ctr.Spieler2;
            outOfBounds = Ctr.OutOfBounds;
            spalteVoll = Ctr.SpalteVoll;
            labelText = Ctr.Text;

            if (Ctr.GewSpalte >= 0)
            {
                Invoke(new UpdateTextCallback(SetLabel1Text), labelText);
            }

            if (Ctr.Neustart == true)
            {
                Ctr.Neustart = false;
                Neustart();
                Ctr.NotifyDisplays();
            }
        }

        public void SpielfeldUpdate()
        {
            Spielsteine();
        }
    }
}
