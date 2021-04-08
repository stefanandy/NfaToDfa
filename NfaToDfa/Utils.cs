using System.Collections.Generic;

namespace NfaToDfa
{
    public static class Utils
    {
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
    }
}