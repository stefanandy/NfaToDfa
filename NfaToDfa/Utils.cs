using System;
using System.Collections.Generic;
using System.Linq;

namespace NfaToDfa
{
    public static class Utils
    {
        private static readonly Random random = new Random();
        
        public static void AddNotExists(this IList<string> list, IEnumerable<string> input)
        {
            foreach (string item in input)
            {
                if (list.Contains(item))
                {
                    continue;
                }
                list.Add(item);
            }
        }
        public static State RandomState(this IEnumerable<State> source)
        {
            int index = random.Next(0, source.Count());
            return source.ToArray()[index];
        }
    }
}