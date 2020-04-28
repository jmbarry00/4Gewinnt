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
            _spieler = new Spieler("blau");
            _spielfeld = new Spielfeld(7, 6);
            _spieler.player1 = true;
        }


        [When(@"(.*) Spielsteine of Spieler (.*) are side by side")]
        public void WhenSpielsteineOfSpielerAreSideBySide(int p0, int p1)
        {
            _spielfeld.feld[0, 0] = 1;
            _spielfeld.feld[1, 0] = 1;
            _spielfeld.feld[2, 0] = 1;
            _spielfeld.FeldBesetzen(3);
        }


        [Then(@"Spieler (.*) hat gewonnen")]
        public void ThenSpielerHatGewonnen(int p0)
        {
            _spielfeld.spieler1Won.Should().BeTrue();
        }
    }
}
