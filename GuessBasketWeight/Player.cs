using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuessBasketWeight
{
    //public class Player 
    public abstract class Player
    {
        public Player() { }
        public Player(string name, int order)
        {
            Name = name;
            OrderInRound = order;
            GuessHistory = new List<int>();
        }
        public string Name { get; }
        //public PlayerType Type { get; internal set; }

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

        public abstract int GetNewGuess(Tuple<int, int> range, IEnumerable<int> existingItems = null);

        public static Player GetNewPlayer(PlayerType type, string name, int order)
        {
            switch (type)
            {
                case PlayerType.Random: return new RandomPlayer(name, order);
                case PlayerType.Memory: return new MemoryPlayer(name, order);
                case PlayerType.Thorough: return new ThoroughPlayer(name, order);
                case PlayerType.Cheater: return new CheaterPlayer(name, order);
                case PlayerType.ThoroughCheater: return new ThoroughCheaterPlayer(name, order);
                default: return null;
            }
        }
        //public int GetNewGuess(Tuple<int, int> range, IEnumerable<int> existingItems = null)
        //{
        //    switch (this.Type)
        //    {
        //        case PlayerType.Random: return Common.GetRandomNew(range);
        //        case PlayerType.Memory: return Common.GetRandomNew(range, GuessHistory);
        //        case PlayerType.Thorough: return MaxGuess == 0 ? range.Item1 : MaxGuess + 1;
        //        case PlayerType.Cheater: return Common.GetRandomNew(range, existingItems);
        //        case PlayerType.ThoroughCheater: var newvalue = MaxGuess; do { newvalue++; } while (existingItems.Contains(newvalue)); return newvalue;
        //        default: return Common.GetRandomNew(range, GuessHistory);

        //    }
        //}
    }

    public class RandomPlayer : Player
    {
        public RandomPlayer(string name, int order) : base(name, order) { }
        public override int GetNewGuess(Tuple<int, int> range, IEnumerable<int> existingItems = null)
        {
            return Common.GetRandomNew(range);
        }
    }

    public class MemoryPlayer : Player
    {
        public MemoryPlayer(string name, int order) : base(name, order) { }
        public override int GetNewGuess(Tuple<int, int> range, IEnumerable<int> existingItems = null)
        {
            return Common.GetRandomNew(range, GuessHistory);
        }
    }

    public class ThoroughPlayer : Player
    {
        public ThoroughPlayer(string name, int order) : base(name, order) { }
        public override int GetNewGuess(Tuple<int, int> range, IEnumerable<int> existingItems = null)
        {
            return MaxGuess == 0 ? range.Item1 : MaxGuess + 1;
        }
    }
    public class CheaterPlayer : Player
    {
        public CheaterPlayer(string name, int order) : base(name, order) { }
        public override int GetNewGuess(Tuple<int, int> range, IEnumerable<int> existingItems = null)
        {
            return Common.GetRandomNew(range, existingItems);
        }
    }
    public class ThoroughCheaterPlayer : Player
    {
        public ThoroughCheaterPlayer(string name, int order) : base(name, order) { }
        public override int GetNewGuess(Tuple<int, int> range, IEnumerable<int> existingItems = null)
        {
            var newvalue = MaxGuess; do { newvalue++; } while (existingItems.Contains(newvalue)); return newvalue;
        }
    }
}
