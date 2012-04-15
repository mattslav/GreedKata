using GreedKata.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace GreedKata.Test.Rules
{
    [TestClass]
    public class WhenMatchingThreeDiceWithTheSameValue : WhenApplyingTheRuleBase
    {
        private int valueToMatch = RandomDieNumber;
        private int valueIfMatched = RandomRuleValue;

        [TestInitialize]
        public void SetUp()
        {
            Rule = new MatchOnThreeDiceRule(new Die(valueToMatch), valueIfMatched);
        }

        [TestMethod]
        public void ThreeDiceWithTheValueToMatchReturnsTrue()
        {
            var dice = BuildDiceCollectionWithThreeOf(valueToMatch);
            VerifyRuleIsMatched(dice);
        }

        [TestMethod]
        public void FourDiceWithTheValueToMatchReturnsTrue()
        {
            var dice = BuildDiceCollectionWithFourOf(valueToMatch);
            VerifyRuleIsMatched(dice);
        }

        [TestMethod]
        public void NoDiceWithTheValueToMatchReturnsFalse()
        {
            var dice = BuildDiceCollectionWithout(valueToMatch);
            VerifyRuleIsNotMatched(dice);
        }

        [TestMethod]
        public void OneDieWithTheValueToMatchReturnsFalse()
        {
            var dice = BuildDiceCollectionWithOneOf(valueToMatch);
            VerifyRuleIsNotMatched(dice);
        }

        [TestMethod]
        public void TheRuleValueCanBeLookedUp()
        {
            Rule.Value
                .Should()
                .Be(valueIfMatched);

        }

    }
}
