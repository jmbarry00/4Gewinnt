using _4Gewinnt.Controller;
using _4Gewinnt.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4Gewinnt.View
{
    public partial class GameGUI : Form
    {
        int Y;
        int X;
        GameController Ctr;
        Spielfeld spielfeld;
        Spieler spieler;
        bool player1;
        bool player2;
        int[,] feld;
        Panel[,] panel;
        Button[] button;
        int gewSpalte;

        bool spieler1Won;
        bool spieler2Won;
        bool unentschieden;
        bool outOfBounds;
        bool spalteVoll;

        //private static GameGUI gameGUI;

        public GameGUI(GameController ctr)
        {
            InitializeComponent();
            this.Ctr = ctr;
            Ctr.AnzZeilenSpaltenGUI();
            Y = Ctr.anzZeilen;
            X = Ctr.anzSpalten;
            spieler = Ctr.spieler;
            spielfeld = Ctr.spielfeld;
        }

        /*
        public static GameGUI getGUI()
        {
            if (gameGUI == null)
            {
                gameGUI = new GameGUI(Ctr);
            }
            return gameGUI;
        }
        */

        private void GameClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        public void Playing()
        {
            getControllerData();
            Game();
        }

        private void getControllerData()
        {
            feld = Ctr.getFeld();
            spieler1Won = Ctr.getSpieler1Won();
            spieler2Won = Ctr.getSpieler2Won();
            unentschieden = Ctr.getUnentschieden();
            player1 = Ctr.getPlayer1();
            player2 = Ctr.getPlayer2();
            spalteVoll = Ctr.getSpalteVoll();
        }

        private void GameGUI_Load(object sender, EventArgs e)
        {
            panel = new Panel[Y, X];    //Spielfeld besteht aus Panels
            button = new Button[X];     //Buttons über jeder Spalte

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

        //Spalte an Programm übergeben
        private void ButtonClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            gewSpalte = Convert.ToInt32(btn.Name);
            Playing();
        }

        //Spieler 1 => Roter Spielstein, Spieler 2 => Blauer Spielstein
        private void Spielsteine()
        {
            for (int s = 0; s < X; s++)
            {
                for (int z = 0; z < Y; z++)
                {
                    //lb[z, s].Text = Convert.ToString(feld[z, s]);
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
        private void Neustart()
        {
            String endStatus;
            Spielsteine();
            if (spieler1Won)
            {
                label1.Text = "Spieler 1 hat gewonnen!";
            }
            else if (spieler2Won)
            {
                label1.Text = "Spieler 2 hat gewonnen!";
            }
            else
            {
                label1.Text = "unentschieden!";
            }

            if (label1.Text == "unentschieden!")
            {
                endStatus = "Draw!";
            }
            else
            {
                endStatus = "Victory!";
            }

            DialogResult neustart = MessageBox.Show("Neustart?", endStatus, MessageBoxButtons.YesNo);

            if (neustart == DialogResult.Yes)
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
            else if (neustart == DialogResult.No)
            {
                this.Hide();
            }

            //neustart = null;
            Ctr.setViewData(feld, spieler1Won, spieler2Won, unentschieden, player1, player2, outOfBounds, spalteVoll);
            Ctr.updateModelData();
        }

        private void Game()
        {
            Ctr.Spielen(gewSpalte);
            getControllerData();

            if (spalteVoll == true)
            {
                MessageBox.Show("Diese Spalte ist schon voll!");
                spalteVoll = false;
            }

            Ctr.setViewData(feld, spieler1Won, spieler2Won, unentschieden, player1, player2, outOfBounds, spalteVoll);
            Ctr.updateModelData();

            if (spieler1Won || spieler2Won || unentschieden)
            {
                Neustart();
            }

            Spielsteine();

            if (player1 == true)
            {
                label1.Text = "Spieler 1: wähle eine Spalte!";
            }
            else
            {
                label1.Text = "Spieler 2: wähle eine Spalte!";
            }
        }

    }
}
