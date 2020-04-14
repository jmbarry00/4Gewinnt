using _4Gewinnt.Model;
using FluentAssertions;
using System;
using TechTalk.SpecFlow;

namespace _4Gewinnt.Features
{
    [Binding]
    public class SpielfeldSteps
    {
        Spielfeld _spielfeld;
        Spieler _spieler;
        [When(@"I create a Spielfeld with (.*) columns and (.*) rows,")]
        public void WhenICreateASpielfeldWithColumnsAndRows(int p0, int p1)
        {
            _spielfeld = new Spielfeld(p0,p1);
        }


        [Then(@"Spielfeld has (.*) columns and (.*) rows")]
        public void ThenSpielfeldHasColumnsAndRows(int p0, int p1)
        {
            _spielfeld.SpaltenX.Equals(p0);
            _spielfeld.SpaltenX.Equals(p1);
        }


        [Given(@"(.*) in a row of Spieler (.*)")]
        public void GivenInARowOfSpieler(int p0, int p1)
        {
            _spieler.inARowP2.Equals(p0);
        }
        
        [Given(@"Its Spieler (.*) turn")]
        public void GivenItsSpielerTurn(int p0)
        {

            _spieler.player2.Should().BeTrue();
        }
                
        
        [When(@"he chooses the right coloumn to make it (.*) in a row,")]
        public void WhenHeChoosesTheRightColoumnToMakeItInARow(int p0)
        {
            _spieler.inARowP2++;
        }
        
        
        [Then(@"Spieler (.*) won")]
        public void ThenSpielerWon(int p0)
        {
            _spielfeld.HatGewonnen(p0);
        }
    }
}
