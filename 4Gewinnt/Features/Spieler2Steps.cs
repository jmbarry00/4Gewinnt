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
            _spieler.player2.Should().BeTrue();
        }
        
        [When(@"he chooses the coloumn (.*) on Spielfeld")]
        public void WhenHeChoosesTheColoumnOnSpielfeld(int p0)
        {
            _spielfeld.FeldBesetzen(p0);
        }
        
        [Then(@"the Spielstein should land on row (.*)")]
        public void ThenTheSpielsteinShouldLandOnRow(int p0)
        {
            _spielstein.zeile.Should().Be(1);
        }
    }
}
