using _4Gewinnt.Model;
using FluentAssertions;
using System;
using TechTalk.SpecFlow;

namespace _4Gewinnt.Features
{
    [Binding]
    public class GewinnBerechnungSteps
    {
        Spieler _spieler;
        Spielfeld _spielfeld;
        [Given(@"It's Spieler(.*) turn")]
        public void GivenItSSpielerTurn(int p0)
        {
            _spieler = new Spieler();
            _spielfeld = new Spielfeld(6, 7);
            _spieler.player1 = true;
        }


        [When(@"(.*) Spielsteine of Spieler (.*) are side by side")]
        public void WhenSpielsteineOfSpielerAreSideBySide(int p0, int p1)
        {
            //diagonal
            _spielfeld.feld[0, 0] = 1;
            _spielfeld.feld[1, 1] = 1;
            _spielfeld.feld[2, 2] = 1;
            _spielfeld.feld[0, 3] = 1;
            _spielfeld.feld[1, 3] = 2;
            _spielfeld.feld[2, 3] = 2;
            _spielfeld.FeldBesetzen(3);
        }


        [Then(@"Spieler (.*) hat gewonnen")]
        public void ThenSpielerHatGewonnen(int p0)
        {
            _spielfeld.spieler1Won.Should().BeTrue();
        }

        [Given(@"All fields are occupied except one")]
        public void GivenAllFieldsAreOccupiedExceptOne()
        {
            _spielfeld = new Spielfeld(6, 7);
            _spieler = new Spieler();
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 7; x++)
                {
                    if (x != 0 && x != 3 && x != 6)
                    {
                        _spielfeld.feld[y, x] = 1;
                    }                    
                }
            }

            _spielfeld.feld[3, 3] = 1;
            _spielfeld.feld[4, 3] = 1;

            _spielfeld.feld[3, 6] = 1;
            _spielfeld.feld[4, 6] = 1;
            _spielfeld.feld[5, 6] = 1;

            _spielfeld.feld[3, 0] = 1;
            _spielfeld.feld[4, 0] = 1;
            _spielfeld.feld[5, 0] = 1;

            for (int y = 3; y < 6; y++)
            {
                for (int x = 0; x < 7; x++)
                {
                    if (x != 0 && x != 3 && x != 6)
                    {
                        _spielfeld.feld[y, x] = 2;
                    }
                }
            }


            _spielfeld.feld[0, 3] = 2;
            _spielfeld.feld[1, 3] = 2;
            _spielfeld.feld[2, 3] = 2;

            _spielfeld.feld[0, 0] = 2;
            _spielfeld.feld[1, 0] = 2;
            _spielfeld.feld[2, 0] = 2;

            _spielfeld.feld[0, 6] = 2;
            _spielfeld.feld[1, 6] = 2;
            _spielfeld.feld[2, 6] = 2;

        }

        [When(@"next Player sets Spielstein without winning")]
        public void WhenNextPlayerSetsSpielsteinWithoutWinning()
        {
            _spieler.player1 = true;
            _spielfeld.FeldBesetzen(3);
            _spielfeld.unentschieden.Should().BeTrue();
        }

    }
}
