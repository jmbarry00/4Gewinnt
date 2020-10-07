using FluentAssertions;
using TechTalk.SpecFlow;

namespace _4Gewinnt
{
    [Binding]
    public class SpielfeldSteps
    {
        Spielfeld _spielfeld;


        [When(@"I create a Spielfeld with (.*) columns and (.*) rows,")]
        public void WhenICreateASpielfeldWithColumnsAndRows(int p0, int p1)
        {
            _spielfeld = new Spielfeld(p1, p0);
        }


        [Then(@"Spielfeld has (.*) columns and (.*) rows")]
        public void ThenSpielfeldHasColumnsAndRows(int p0, int p1)
        {
            _spielfeld.SpaltenX.Should().Be(p0);
            _spielfeld.ZeilenY.Should().Be(p1);
        }
    }
}
