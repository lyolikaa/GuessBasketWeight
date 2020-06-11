using System;
using System.Collections.Generic;
using System.Linq;

namespace GuessBasketWeight
{
    class Program
    {
        static void Main(string[] args)
        {
            //set initials
            int PlayersAmount = 0;
            //how to calculate amounts: per player or overall
            //I suggest summary of all players attempts
            bool amountsPerPlayer = false;
            int AttemptsMaxAmount = 100;
            int BasketMinWeiht = 40;
            int BasketMaxWeight = 140;
            //optinal - read initials from app arguments

            Console.WriteLine("Please specify the amount of participating players – 2 through 8");
            CheckInputParameter(2, 8, ref PlayersAmount);

            Console.WriteLine("Please set for every player his Name and Type");
            Console.WriteLine("Types are: Random - 1, Memory - 2, Thorough - 3, Cheater - 4, ThoroughCheater - 5 ");
            var Players = new List<Player>();
            for (byte p = 1; p <= PlayersAmount; p++)
            {
                Console.WriteLine($"Please set player # {p}");
                var playerName = Console.ReadLine();
                var playerType = 0;
                CheckInputParameter(1, 5, ref playerType);

                var player = new Player(playerName, (PlayerType)playerType, Common.GetRandomNew(Tuple.Create(1, PlayersAmount), Players.Select(p => p.OrderInRound)) );

                Players.Add(player);
            }

            Console.WriteLine("Let's start");
            int round = 0;
            int attempts = 0;
            var bingo = false;
            int weight2guess = Common.GetRandomNew(Tuple.Create(BasketMinWeiht, BasketMaxWeight));
            Console.WriteLine($"weight2guess {weight2guess}");
            do
            {
                round++;
                Console.WriteLine($"round {round}");
                foreach(var pl in Players)
                {
                    if (pl.RoundsToSkip > 0)
                    {
                        pl.RoundsToSkip--;
                    }
                    else
                    {
                        var guess = pl.GetNewGuess(Tuple.Create(BasketMinWeiht, BasketMaxWeight), Players.SelectMany(p => p.GuessHistory, (a, b) => b));
                        attempts++;
                        pl.GuessHistory.Add(guess);
                        Console.WriteLine($"player {pl.Name};guess {guess}");
                        if (guess != weight2guess) 
                            pl.RoundsToSkip += Math.Abs(weight2guess - guess)/10 - 1;
                        //if we quite close to answer wit rounds to -1
                        if (pl.RoundsToSkip < 0) pl.RoundsToSkip = 0;
                    }
                }
                bingo = Players.SelectMany(p => p.GuessHistory, (a, b) => b).Contains(weight2guess);
                if (bingo)
                {
                    Console.WriteLine("!");
                }
            }
            while ((!amountsPerPlayer && attempts < AttemptsMaxAmount) && !bingo);//todo per player
           
            if (bingo)
            {
                var winner = Players.Where(p => p.GuessHistory.Contains(weight2guess)).OrderBy(p => p.OrderInRound).FirstOrDefault();
                Console.WriteLine($"Here's the winner: {winner.Name}, guess: {weight2guess}");
            }
            else
            {
                var closest = Players.OrderBy(p => p.GuessHistory.Min(a => Math.Abs(a - weight2guess))).OrderBy(p => p.OrderInRound).FirstOrDefault();
                Console.WriteLine($"Here's the closest: {closest.Name}, guess: {closest.GuessHistory.OrderBy(a => Math.Abs(a - weight2guess)).FirstOrDefault()}");
            }
        }



        static void CheckInputParameter(int rangeStart, int rangeEnd, ref int value) {
            while (value < rangeStart || value > rangeEnd)
            {

                try
                {
                    value = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Wrong input, pleas try again");
                }

            }
        }

        static void ReadArgument(string[] args, string name, ref string value)
        {
            if (!args.Any()) return;
        }
    }
}
