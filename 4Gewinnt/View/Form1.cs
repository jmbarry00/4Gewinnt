using _4Gewinnt.Controller;
using System;
using System.Windows.Forms;

namespace _4Gewinnt.View
{
    public partial class Form1 : Form
    {
        int anzZeilen = 0;
        int anzSpalten = 0;
        GameController Ctr;

        public Form1()
        {
            InitializeComponent();
        }

        private void GameClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        //Anzahl Zeilen und Spalten dem Programm übergeben
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                anzZeilen = Convert.ToInt32(tbZeilen.Text);
                anzSpalten = Convert.ToInt32(tbSpalten.Text);
                if (anzZeilen >= 5 && anzSpalten >= 5)
                {
                    this.Hide();
                    Ctr = new GameController(anzZeilen, anzSpalten);
                }
                else
                {
                    tbSpalten.Text = "";
                    tbZeilen.Text = "";
                    MessageBox.Show("Wähle mindestens 5 Zeilen und Spalten!");
                }
            }
            catch (FormatException fe)
            {
                MessageBox.Show(fe.Message);
            }
        }

    }
}
