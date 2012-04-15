using FluentAssertions;
using GreedKata.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreedKata.Test.Rules
{
    [TestClass]
    public class WhenMatchingOneDie : WhenApplyingTheRuleBase
    {
        private int valueToMatch = RandomDieNumber;
        private int valueIfMatched = RandomRuleValue;

        [TestInitialize]
        public void SetUp()
        {
            Rule = new MatchOnOneDieRule(new Die(valueToMatch), valueIfMatched);
        }

        [TestMethod]
        public void AtLeastOneDieWithTheValueToMatchReturnsTrue()
        {
            var dice = BuildDiceCollectionWithOneOf(valueToMatch);
            VerifyRuleIsMatched(dice);
        }

        [TestMethod]
        public void NoDiceWithTheValueToMatchReturnsFalse()
        {
            var dice = BuildDiceCollectionWithout(valueToMatch);
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
