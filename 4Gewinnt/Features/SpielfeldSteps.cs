﻿using _4Gewinnt.Model;
using FluentAssertions;
using System;
using TechTalk.SpecFlow;

namespace _4Gewinnt
{
    [Binding]
    public class SpielfeldSteps
    {
        Spielfeld _spielfeld;
        Spieler _spieler;
        [When(@"I create a Spielfeld with (.*) columns an d (.*) rows,")]
        public void WhenICreateASpielfeldWithColumnsAndRows(int p0, int p1)
        {
            _spielfeld = new Spielfeld(p0, p1);
        }
        
        [Then(@"Spielfeld has (.*) columns and (.*) rows")]
        public void ThenSpielfeldHasColumnsAndRows(int p0, int p1)
        {
            _spielfeld.SpaltenX.Should().Be(p0);
            _spielfeld.ZeilenY.Should().Be(p1);
        }
    }
}
