using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreedKata.Test.Rules
{
    [TestClass]
    public class DiceTestBase
    {
        private const int NonExistentDieNumber = 0;

        protected IEnumerable<Die> BuildDiceCollectionWithout(int valueToMatch)
        {
            return CreateDice
                (
                GetDieNumberThatIsNot(valueToMatch),
                GetDieNumberThatIsNot(valueToMatch),
                GetDieNumberThatIsNot(valueToMatch),
                GetDieNumberThatIsNot(valueToMatch),
                GetDieNumberThatIsNot(valueToMatch)
                );
        }

        protected IEnumerable<Die> BuildDiceCollectionWithOneOf(int valueToMatch)
        {
            return CreateDice
                (
                valueToMatch, 
                NonExistentDieNumber, 
                NonExistentDieNumber, 
                NonExistentDieNumber, 
                NonExistentDieNumber
                );
        }

        protected IEnumerable<Die> BuildDiceCollectionWithThreeOf(int valueToMatch)
        {
            return CreateDice
                (
                valueToMatch, 
                valueToMatch, 
                valueToMatch, 
                NonExistentDieNumber, 
                NonExistentDieNumber
                );
        }

        protected IEnumerable<Die> BuildDiceCollectionWithFourOf(int valueToMatch)
        {
            return CreateDice
                (
                valueToMatch, 
                valueToMatch, 
                valueToMatch, 
                valueToMatch, 
                NonExistentDieNumber
                );
        }

        protected IEnumerable<Die> CreateDice(int die1, int die2, int die3, int die4, int die5)
        {
            var Dice = new List<Die>
            {
                new Die(die1),
                new Die(die2),
                new Die(die3),
                new Die(die4),
                new Die(die5)
            };
            return Dice;
        }

        private static int GetDieNumberThatIsNot(int dieNumber)
        {
            return PossibleDieNumbers
                .Where(n => n != dieNumber)
                .OrderBy(n => Guid.NewGuid())
                .First();
        }

        protected static int RandomDieNumber
        {
            get { return GetDieNumberThatIsNot(NonExistentDieNumber); }
        }

        protected static int RandomRuleValue
        {
            get { return new Random().Next(); }
        }

        private static IEnumerable<int> PossibleDieNumbers
        {
            get { return new List<int> { 1, 2, 3, 4, 5, 6 }; }
        }

    }
}
