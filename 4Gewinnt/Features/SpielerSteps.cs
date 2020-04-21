using _4Gewinnt.Model;
using FluentAssertions;
using System;
using TechTalk.SpecFlow;

namespace _4Gewinnt.Features
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
            _spieler.player1 = true;
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


        [Given(@"It Spieler (.*) turn")]
        public void GivenItSpielerTurn(int p0)
        {
            _spieler.player1 = true;
        }

        [When(@"I switch the player")]
        public void WhenISwitchThePlayer()
        {
            _spieler.SwitchPlayer();
        }

        [Then(@"It should be Player (.*) turn")]
        public void ThenItShouldBePlayerTurn(int p0)
        {
            _spieler.player2.Should().BeTrue();
        }

    }
}
