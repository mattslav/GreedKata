using System.Collections.Generic;

namespace GreedKata.Rules
{
    public class MatchOnThreeDiceRule : Rule
    {
        private Die DieToMatch { get; set; }

        public override IEnumerable<Die> DiceToMatch
        {
            get
            {
                return new List<Die> { DieToMatch, DieToMatch, DieToMatch };
            }
        }

        public MatchOnThreeDiceRule(Die dieToMatch, int valueIfMatched) : base(valueIfMatched)
        {
            DieToMatch = dieToMatch;
        }
    }
}
