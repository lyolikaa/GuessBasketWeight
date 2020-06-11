using System;
using System.Collections.Generic;
using System.Text;

namespace GuessBasketWeight
{
    public abstract class GuessStrategy
    {
        public PlayerType PlayerType { get; set; }
        public static IGuessStrategy GetStrategy (PlayerType type)
        {
            switch (type)
            {
                case PlayerType.Random: return new RandomGuessStrategy();
                default: return null;
            }
        }
    }
    public interface IGuessStrategy
    {
        int GetNewGuess(Tuple<int, int> range, IEnumerable<int> existingItems = null);
    }

    public class RandomGuessStrategy : GuessStrategy, IGuessStrategy
    {
        public int GetNewGuess(Tuple<int, int> range, IEnumerable<int> existingItems = null)
        {
            return Common.GetRandomNew(range);
        }
    }

}
