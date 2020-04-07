using FluentAssertions;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace VierGewinnt.Features.Example

{
    [Binding]
    public class SpielfeldSteps
    {
        
        private Spielfeld feld = new Spielfeld(4,7);
        private bool result;

        [Given(@"I have entered 4 into the x-position(spalte) setter")]
        public void GivenIHaveEnteredPosition()
        {
            //feld.feldBesetzen(4);
        }

        [When(@"I call the function IstBesetzt on this position")]
        public void ICallFeldIstBesetzt()
        {
            result = feld.IstFeldBesetzt(4, 0);
        }

        [Then(@"result should be true")]
        public void ThePlayersShouldBeSwitched()
        {
            result.Should().BeTrue();
        }
    }
}
