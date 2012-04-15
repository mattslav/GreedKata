using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreedKata
{
    public class Result
    {
        public IEnumerable<Die> Dice { get; private set; }
        public int Score { get; private set; }

        public Result(IEnumerable<Die> dice, int score)
        {
            Dice = dice;
            Score = score;
        }

        public override string ToString()
        {
            return "Dice: " + string.Join(", ", Dice) + "; score: " + Score;
        }

    }
}
