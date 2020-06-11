using System;
using System.Collections.Generic;
using System.Linq;

namespace GuessBasketWeight
{
    public static class Common
    {
        public static int GetRandomNew(Tuple<int,int> range, IEnumerable<int> existingItems = null)
        {
            var r = new Random();
            var value = 0;
            do
            {
                value = r.Next(range.Item1, range.Item2 + 1);
            }
            while (existingItems != null && existingItems.Contains(value));
            return value;

        }
    }
}
