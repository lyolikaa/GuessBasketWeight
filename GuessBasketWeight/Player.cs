using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuessBasketWeight
{
    public class Player : IGuessStrategy
    {
        public Player(string name, PlayerType type, int order)
        {
            Name = name;
            Type = type;
            OrderInRound = order;
            GuessHistory = new List<int>();
        }
        public string Name { get; }
        public PlayerType Type { get; }

        public int RoundsToSkip { get; set; }
        public int OrderInRound { get;}
        public int MaxGuess
        { 
            get {
                if (GuessHistory.Any())
                    return GuessHistory.Max();
                return 0;
                } 
        }
        public List<int> GuessHistory { get; set; }
        public int GetNewGuess(Tuple<int, int> range, IEnumerable<int> existingItems = null)
        {
            switch (this.Type)
            {
                case PlayerType.Random: return Common.GetRandomNew(range);
                case PlayerType.Memory: return Common.GetRandomNew(range, GuessHistory); 
                case PlayerType.Thorough: return MaxGuess == 0 ? range.Item1 : MaxGuess + 1;
                case PlayerType.Cheater: return Common.GetRandomNew(range, existingItems);
                case PlayerType.ThoroughCheater: var newvalue = MaxGuess;  do { newvalue++; } while (existingItems.Contains(newvalue)); return newvalue;
                default: return Common.GetRandomNew(range, GuessHistory);

            }
        }
    }
}
