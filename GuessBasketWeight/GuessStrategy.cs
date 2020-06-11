using System;
using System.Collections.Generic;
using System.Text;

namespace GuessBasketWeight
{
    interface IGuessStrategy
    {
        int GetNewGuess(Tuple<int, int> range, IEnumerable<int> existingItems = null);
    }

    public class RandomGuessStrategy : IGuessStrategy
    {
        public int GetNewGuess(Tuple<int, int> range, IEnumerable<int> existingItems = null)
        {
            return Common.GetRandomNew(range);
        }
    }
}
