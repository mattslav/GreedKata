using System;
using System.Linq;
using System.Collections.Generic;
using GreedKata.Interface;

namespace GreedKata
{
    public class DiceCreator : IDiceCreator
    {
        public IEnumerable<Die> Create(int numberOfDice)
        {
            var dice = new List<Die>();
            for (int i = 0; i < numberOfDice; i++)
            {
                dice.Add(GetRandomDie());
            }

            return dice;
        }

        private static Die GetRandomDie()
        {
            return PossibleDieNumbers
                .OrderBy(n => Guid.NewGuid())
                .First();
        }

        private static IEnumerable<Die> PossibleDieNumbers
        {
            get { return new List<Die> { new Die(1), new Die(2), new Die(3), new Die(4), new Die(5), new Die(6) }; }
        }

    }
}
