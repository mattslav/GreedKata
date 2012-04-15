using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using FluentAssertions;
using GreedKata.Interface;
using GreedKata;

namespace GreedKata.Test
{
    [TestClass]
    public class WhenRollingDice
    {
        #region Fields

        private Mock<IDiceCreator> _mockDiceCreator;
        private Mock<ICalculator> _mockCalculator;
        private IGame _game;

        #endregion

        [TestInitialize]
        public void TestInitialize()
        {
            _mockDiceCreator = new Mock<IDiceCreator>();
            _mockCalculator = new Mock<ICalculator>();
            _game = new GreedKata.Game(_mockDiceCreator.Object, _mockCalculator.Object);
        }

        [TestMethod]
        public void RandomDiceAreRetrieved()
        {
            _game.Roll();

            _mockDiceCreator.Verify(x => x
                .Create(Game.NumberOfDice));
        }

        [TestMethod]
        public void TheRandomDiceArePassedToTheCalculateMethod()
        {
            var dice = RandomDice();
            _mockDiceCreator.Setup(x => x
                .Create(It.IsAny<int>()))
                .Returns(dice);

            _game.Roll();

            _mockCalculator.Verify(x => x
                .Calculate(dice));
        }

        [TestMethod]
        public void TheScoreIsCalculatedAndReturned()
        {
            var expectedResult = new Result(RandomDice(), RandomScore());
            _mockCalculator.Setup(x => x
                .Calculate(It.IsAny<IEnumerable<Die>>()))
                .Returns(expectedResult);

            _game.Roll()
                .Should()
                .Be(expectedResult);
        }

        #region Helpers

        private static List<Die> RandomDice()
        {
            return new List<Die> { new Die(1) };
        }

        private static int RandomScore()
        {
            return 5;
        }

        #endregion
    }
}
