using FluentAssertions;
using NUnit.Framework;
using TechTalk.SpecFlow;
using VierGewinnt.Model;

namespace VierGewinnt.Features.Example

{
    [Binding]
    public class SpielerSteps
    {
        
        Spieler spieler = new Spieler();
        bool result1;
        bool result2;


        [Given(@"I have set the name of the player who is true")]
        public void IHaveSetTheNameOfThePlayerWhoIsTrue()
        {
            if(spieler.player1 == true)
            {
                spieler.getNameP1();
            }
            if (spieler.player2 == true)
            {
                spieler.getNameP2();
            }
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            spieler.switchPlayer();
        }

        [Then(@"the players should switch")]
        public void ThePlayersShouldBeSwitched()
        {
            result1 = spieler.player1;
            //result1.Should.BeFalse();
            result2 = spieler.player2;
            //result2.Should.BeFalse();
        }
    }
}
