using System.Collections.Generic;
using System.Linq;

namespace GreedKata.Rules
{
    public abstract class Rule : IRule
    {
        public abstract IEnumerable<Die> DiceToMatch { get; }

        public int Value { get; private set; }

        public Rule(int valueIfMatched)
        {
            Value = valueIfMatched;
        }

        public bool IsMatched(IEnumerable<Die> dice)
        {
            var diceAsList = dice.ToList();
            var diceMatched = true;

            foreach (var die in DiceToMatch)
            {
                diceMatched = diceAsList.Remove(die);
            }

            return diceMatched;
        }

        public IEnumerable<Die> RemoveDiceUsed(IEnumerable<Die> dice)
        {
            var diceAsList = dice.ToList();

            foreach (var die in DiceToMatch)
            {
                diceAsList.Remove(die);
            }

            return diceAsList;
        }
    }
}
