using _4Gewinnt.Model;
using FluentAssertions;
using System;
using TechTalk.SpecFlow;

namespace _4Gewinnt.Features
{
    [Binding]
    public class Spieler2Steps
    {
        Spielfeld _spielfeld;
        Spieler _spieler;
        Spielstein _spielstein;
        [Given(@"It is Spieler (.*) turn")]
        public void GivenItIsSpielerTurn(int p0)
        {
            _spieler = new Spieler("blau");
            _spielfeld = new Spielfeld(5, 6);
            int x = _spielfeld.posX;
            int y = _spielfeld.posY;
            _spielstein = new Spielstein(x, y, "blau");
            _spieler.player2 = true;
        }

        [Given(@"field (.*) on column (.*) is occupied")]
        public void GivenFieldOnColumnIsOccupied(int p0, int p1)
        {
            _spielfeld.posX = p1;
            _spielfeld.posY = p0;
            _spielfeld.IstFeldBesetzt(p1, p0).Should().BeTrue();
        }


        [When(@"he chooses the coloumn (.*) on Spielfeld")]
        public void WhenHeChoosesTheColoumnOnSpielfeld(int p0)
        {
            _spielfeld.IstFeldBesetzt(4, 0).Should().BeTrue();
            _spielfeld.FeldBesetzen(p0);
        }
        
        [Then(@"the Spielstein should land on row (.*)")]
        public void ThenTheSpielsteinShouldLandOnRow(int p0)
        {
            _spielfeld.posY.Should().Be(p0);
        }
        
    }
}
