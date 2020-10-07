using _4Gewinnt.Model;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace _4Gewinnt.Features
{
    [Binding]
    public class SpielerSteps
    {
        Spieler _spieler;
        Spielfeld _spielfeld;

        [When(@"I create a Spieler")]
        public void WhenICreateASpieler()
        {
            _spieler = new Spieler();
            _spielfeld = new Spielfeld(6, 7);
            _spieler.player1 = true;
        }

        [Then(@"It's Spieler (.*) turn")]
        public void ThenItSSpielerTurn(int p0)
        {
            _spieler.player1.Should().BeTrue();
        }

        [When(@"Spieler (.*) chooses the coloumn (.*) on Spielfeld")]
        public void WhenSpielerChoosesTheColoumnOnSpielfeld(int p0, int p1)
        {
            _spielfeld.FeldBesetzen(p1, _spieler);
        }

        [Then(@"Spielstein should land on row (.*)")]
        public void ThenSpielsteinShouldLandOnRow(int p0)
        {

            _spielfeld.feld[p0, 4].Should().Be(1);
        }

        [Given(@"Spieler (.*) turn")]
        public void GivenSpielerTurn(int p0)
        {
            _spieler = new Spieler();
            _spieler.player1 = true;
        }


        [When(@"I switch the player")]
        public void WhenISwitchThePlayer()
        {
            _spieler.player1.Should().BeTrue();
            _spieler.SwitchPlayer();
        }

        [Then(@"It should be Player (.*) turn")]
        public void ThenItShouldBePlayerTurn(int p0)
        {
            _spieler.player2.Should().BeTrue();
        }

    }
}
