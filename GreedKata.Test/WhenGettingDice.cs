using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreedKata.Interface;
using GreedKata;
using FluentAssertions;

namespace GreedKata.Test
{
    [TestClass]
    public class WhenGettingDice
    {
        private IDiceCreator _diceCreator;

        [TestInitialize]
        public void SetUp()
        {
            _diceCreator = new DiceCreator();
        }

        [TestMethod]
        public void TheNumberOfDiceCreatedIsDictatedByTheInput()
        {
            var numberOfDice = 5;
            var dice = _diceCreator.Create(numberOfDice);

            dice.Count()
                .Should()
                .Be(numberOfDice);
        }

    }
}
