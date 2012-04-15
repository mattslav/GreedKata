using System.Collections.Generic;

namespace GreedKata.Rules
{
	public class MatchOnOneDieRule : Rule
	{
		private Die DieToMatch { get; set; }

		public override IEnumerable<Die> DiceToMatch
		{
			get
			{
				return new List<Die> { DieToMatch };
			}
		}

		public MatchOnOneDieRule(Die dieToMatch, int valueIfMatched) : base(valueIfMatched)
		{
			DieToMatch = dieToMatch;
		}

	}
}
