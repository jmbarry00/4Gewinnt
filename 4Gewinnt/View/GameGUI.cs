using _4Gewinnt.Controller;
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
        GameController Ctr;
        Spielfeld spielfeld;
        Spieler spieler;
        bool player1;
        bool player2;
        int[,] feld;
        Panel[,] panel;
        Button[] button;
        int gewSpalte;
        String labelText;
        String endStatus;
        private Label label1;
        DialogResult neustart;
        bool lastActionAtGUI = false;
        public delegate void UpdateTextCallback(string text);

        bool spieler1Won;
        bool spieler2Won;
        bool unentschieden;
        bool outOfBounds;
        bool spalteVoll;


        public GameGUI(GameController ctr)
        {
            InitializeComponent();
            this.Ctr = ctr;
            spieler = Ctr.spieler;
            spielfeld = Ctr.spielfeld;
            label1 = new Label();
        }

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

        private void setLabel1Text(string lb1Text)
        {
            label1.Text = lb1Text;
        }

        //Spalte an Programm übergeben
        private void ButtonClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Ctr.gewSpalte = Convert.ToInt32(btn.Name);
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
        public void Neustart()
        {
            if (lastActionAtGUI)
            {
                Ctr.tui.endOutput();
                lastActionAtGUI = false;
            }
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
                Environment.Exit(0);
            }

            Ctr.setViewData(feld, spieler1Won, spieler2Won, unentschieden, player1, player2, outOfBounds, spalteVoll);
            Ctr.updateModelData();
        }

        public void Game()
        {
            Ctr.Spielen(gewSpalte);
            getControllerData();

            if (spalteVoll)
            {

                Console.WriteLine("Diese Spalte ist schon voll!");
                MessageBox.Show("Diese Spalte ist schon voll!");
                Ctr.SpalteVoll = false;
            }

            Ctr.setViewData(feld, spieler1Won, spieler2Won, unentschieden, player1, player2, outOfBounds, spalteVoll);
            Ctr.updateModelData();

            if (spieler1Won || spieler2Won || unentschieden)
            {
                lastActionAtGUI = true;
                Neustart();
            }

            Ctr.notifyDisplays();

            if (player1)
            {
                label1.Text = "Spieler 1, wähle eine Spalte:";
                Console.WriteLine("Spieler 1, wähle eine Spalte:");
            }
            else
            {
                label1.Text = "Spieler 2, wähle eine Spalte:";
                Console.WriteLine("Spieler 2, wähle eine Spalte:");
            }
        }

        public void update()
        {
            X = Ctr.SpaltenX;
            Y = spielfeld.ZeilenY;
            gewSpalte = Ctr.gewSpalte;
            feld = Ctr.Feld;
            spieler1Won = Ctr.Spieler1Won;
            spieler2Won = Ctr.Spieler2Won;
            unentschieden = Ctr.Unentschieden;
            player1 = Ctr.Spieler1;
            player2 = Ctr.Spieler2;
            outOfBounds = Ctr.OutOfBounds;
            spalteVoll = Ctr.SpalteVoll;
            labelText = Ctr.Text;

            if (Ctr.gewSpalte >= 0)
            {
                Invoke(new UpdateTextCallback(setLabel1Text), labelText);
            }

            if (Ctr.Neustart == true)
            {
                Ctr.Neustart = false;   
                Neustart();
                Ctr.notifyDisplays();
            }

        }

        public void Spielfeld()
        {
            Spielsteine();
        }
    }
}
