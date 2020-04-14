using _4Gewinnt.Model;
using FluentAssertions;
using System;
using TechTalk.SpecFlow;

namespace _4Gewinnt
{
    [Binding]
    public class SpielerSteps
    {
        Spielfeld _spielfeld;
        Spieler _spieler;
        Spielstein _spielstein;
        [Given(@"It's Spieler (.*) turn")]
        public void GivenItSSpielerTurn(int p0)
        {
            _spieler.player1.Should().BeTrue();
        }
        
        [When(@"he chooses coloumn (.*) on Spielfeld")]
        public void WhenHeChoosesAColoumnOnSpielfeld(int p0)
        {
            _spielfeld.FeldBesetzen(p0);
        }
        
        [Then(@"the Spielstein should land on the lowest field")]
        public void ThenTheSpielsteinShouldLandOnTheLowestField()
        {
            _spielstein.zeile.Should().Be(0);
        }
        
        


    }
}
