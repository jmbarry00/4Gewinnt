using _4Gewinnt.Model;
using FluentAssertions;
using System;
using TechTalk.SpecFlow;

namespace _4Gewinnt.Features
{
    [Binding]
    public class SpielerSteps
    {
        Spieler _spieler;
        [When(@"I create a Spieler")]
        public void WhenICreateASpieler()
        {
            _spieler = new Spieler("blau");
        }

        [Then(@"It's Spieler (.*) turn")]
        public void ThenItSSpielerTurn(int p0)
        {
            _spieler.player1 = true;
        }

        [Then(@"The color is on blau")]
        public void ThenTheColorIsOnBlau()
        {
            _spieler.farbe.Should().Be("blau");
        }

        [Given(@"It's Spieler (.*) turn")]
        public void GivenItSpielerTurn(int p0)
        {
            _spieler = new Spieler("blau");
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
