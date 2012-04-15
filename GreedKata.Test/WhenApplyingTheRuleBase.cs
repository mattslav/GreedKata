using System.Collections.Generic;
using FluentAssertions;
using GreedKata.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreedKata.Test.Rules
{
    [TestClass]
    public class WhenApplyingTheRuleBase : DiceTestBase
    {
        protected IRule Rule;

        protected void VerifyRuleIsMatched(IEnumerable<Die> dice)
        {
            Rule.IsMatched(dice)
                .Should()
                .Be(true);
        }

        protected void VerifyRuleIsNotMatched(IEnumerable<Die> dice)
        {
            Rule.IsMatched(dice)
                .Should()
                .Be(false);
        }

    }
}
