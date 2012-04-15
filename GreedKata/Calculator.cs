using System.Collections.Generic;
using System.Linq;
using GreedKata.Rules;
using GreedKata.Interface;

namespace GreedKata
{
    public class Calculator : ICalculator
    {
        private IEnumerable<IRule> _rules;

        public Result Calculate(IEnumerable<Die> dice)
        {
            var score = 0;
            var diceLeft = dice;
            foreach (var rule in Rules.OrderByDescending(r => r.Value))
            {
                while (rule.IsMatched(diceLeft))
                {
                    score += rule.Value;
                    diceLeft = rule.RemoveDiceUsed(diceLeft);
                }

            }
            return new Result(dice, score);
        }

        private IEnumerable<IRule> Rules
        {
            get
            {
                return _rules ??
                    (_rules = new List<IRule>
                        {
                            new MatchOnOneDieRule(new Die(1), 100),
                            new MatchOnOneDieRule(new Die(5), 50),
                            new MatchOnThreeDiceRule(new Die(1), 1000),
                            new MatchOnThreeDiceRule(new Die(2), 200),
                            new MatchOnThreeDiceRule(new Die(3), 300),
                            new MatchOnThreeDiceRule(new Die(4), 400),
                            new MatchOnThreeDiceRule(new Die(5), 500),
                            new MatchOnThreeDiceRule(new Die(6), 600)

                        }
                    );
            }
        }

    }
}
