using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreedKata.Test.Rules;
using GreedKata.Interface;

namespace GreedKata.Test.ScoreCalculation
{
    [TestClass]
    public class WhenCalculatingTheScore : DiceTestBase
    {
        private ICalculator _calculator;

        [TestInitialize]
        public void Initialize()
        {
            _calculator = new Calculator();
        }

        [TestMethod]
        public void AndNoRulesAreMatched()
        {
            var dice = CreateDice(2,3,4,6,2);
            _calculator.Calculate(dice).Score
                .Should()
                .Be(0);
        }

        [TestMethod]
        public void AndTheOneOneRuleIsMatched()
        {
            var dice = BuildDiceCollectionWithOneOf(1);
            _calculator.Calculate(dice).Score
                .Should()
                .Be(100);
        }

        [TestMethod]
        public void AndTheOneFiveRuleIsMatched()
        {
            var dice = BuildDiceCollectionWithOneOf(5);
            _calculator.Calculate(dice).Score
                .Should()
                .Be(50);
        }

        [TestMethod]
        public void AndTheThreeOnesRuleIsMatched()
        {
            var dice = BuildDiceCollectionWithThreeOf(1);
            _calculator.Calculate(dice).Score
                .Should()
                .Be(1000);
        }

        [TestMethod]
        public void AndTheThreeTwosRuleIsMatched()
        {
            var dice = BuildDiceCollectionWithThreeOf(2);
            _calculator.Calculate(dice).Score
                .Should()
                .Be(200);
        }

        [TestMethod]
        public void AndTheThreeThreesRuleIsMatched()
        {
            var dice = BuildDiceCollectionWithThreeOf(3);
            _calculator.Calculate(dice).Score
                .Should()
                .Be(300);
        }

        [TestMethod]
        public void AndTheThreeFoursRuleIsMatched()
        {
            var dice = BuildDiceCollectionWithThreeOf(4);
            _calculator.Calculate(dice).Score
                .Should()
                .Be(400);
        }

        [TestMethod]
        public void AndTheThreeFivesRuleIsMatched()
        {
            var dice = BuildDiceCollectionWithThreeOf(5);
            _calculator.Calculate(dice).Score
                .Should()
                .Be(500);
        }

        [TestMethod]
        public void AndTheThreeSixesRuleIsMatched()
        {
            var dice = BuildDiceCollectionWithThreeOf(6);
            _calculator.Calculate(dice).Score
                .Should()
                .Be(600);
        }

        [TestMethod]
        public void AndBothFiveRulesAreMatched()
        {
            var dice = CreateDice(5, 5, 5, 5, 2);
            _calculator.Calculate(dice).Score
                .Should()
                .Be(550);
        }

        [TestMethod]
        public void AndTheThreeOnesAndOneFiveRulesAreMatched()
        {
            var dice = CreateDice(1, 1, 1, 5, 1);
            _calculator.Calculate(dice).Score
                .Should()
                .Be(1150);
        }

        [TestMethod]
        public void AndTheThreeThreesAndOneFiveRulesAreMatched()
        {
            var dice = CreateDice(3, 4, 5, 3, 3);
            _calculator.Calculate(dice).Score
                .Should()
                .Be(350);
        }

        [TestMethod]
        public void AndTheOneOneIsMatchedTwice()
        {
            var dice = CreateDice(1, 3, 1, 2, 4);
            _calculator.Calculate(dice).Score
                .Should()
                .Be(200);
        }

        [TestMethod]
        public void AndTheOneFiveRuleIsMatchedTheOneOneIsMatchedTwice()
        {
            var dice = CreateDice(1, 5, 1, 2, 4);
            _calculator.Calculate(dice).Score
                .Should()
                .Be(250);
        }

        [TestMethod]
        public void AndTheThreeFivesRuleIsMatchedTheOneFiveIsMatchedTwice()
        {
            var dice = CreateDice(5, 5, 5, 5, 5);
            _calculator.Calculate(dice).Score
                .Should()
                .Be(600);
        }

    }
}
