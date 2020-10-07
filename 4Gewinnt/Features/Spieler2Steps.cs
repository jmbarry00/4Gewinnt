using _4Gewinnt.Model;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace _4Gewinnt.Features
{
    [Binding]
    public class Spieler2Steps
    {
        Spielfeld _spielfeld;
        Spieler _spieler;
        [Given(@"It is Spieler (.*) turn")]
        public void GivenItIsSpielerTurn(int p0)
        {
            _spieler = new Spieler();
            _spielfeld = new Spielfeld(7, 6);
            _spieler.player2 = true;
        }

        [Given(@"field (.*) on column (.*) is occupied")]
        public void GivenFieldOnColumnIsOccupied(int p0, int p1)
        {
            _spielfeld.feld[p0, p1] = 1;
            _spielfeld.IstFeldBesetzt(p0, p1).Should().BeTrue();
        }


        [When(@"he chooses the coloumn (.*) on Spielfeld")]
        public void WhenHeChoosesTheColoumnOnSpielfeld(int p0)
        {
            _spielfeld.FeldBesetzen(p0, _spieler);
        }

        [Then(@"the Spielstein should land on row (.*)")]
        public void ThenTheSpielsteinShouldLandOnRow(int p0)
        {
            _spielfeld.feld[p0, 4].Should().Be(1);
        }

    }
}
