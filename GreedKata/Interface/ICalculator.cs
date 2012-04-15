using System.Collections.Generic;

namespace GreedKata.Interface
{
   public interface ICalculator
    {
        Result Calculate(IEnumerable<Die> dice);
    }
}
