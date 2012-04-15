using GreedKata.Interface;

namespace GreedKata
{
    public class Game : IGame
    {
        public const int NumberOfDice = 5;
        private IDiceCreator _diceCreator;
        private ICalculator _calculator;

        public Game(IDiceCreator diceCreator, ICalculator calculator)
        {
            _diceCreator = diceCreator;
            _calculator = calculator;
        }

        public Result Roll()
        {
            var dice = _diceCreator.Create(NumberOfDice);
            return _calculator.Calculate(dice);
        }
    }
}
