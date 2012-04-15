using System.Collections.Generic;

namespace GreedKata.Interface
{
    public interface IDiceCreator
    {
        IEnumerable<Die> Create(int numberOfDice);
    }
}
