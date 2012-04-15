using System.Collections.Generic;

namespace GreedKata.Rules
{
    public interface IRule
    {
        bool IsMatched(IEnumerable<Die> dice);
        IEnumerable<Die> RemoveDiceUsed(IEnumerable<Die> dice);
        int Value{ get; }
    }
}
