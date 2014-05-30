using System.Collections.Generic;

namespace ArrayAndStrings
{
    /// <summary>
    /// Given an array of integers, find two numbers such that they add up to a specific target number.
    /// 
    /// Solution is to build a dictionary of all integers. Then iterate through all items and find if there is another one matching
    /// time :O(n)
    /// space: O(n)
    /// 10:18
    /// 10:21
    /// </summary>
    public class TwoSum
    {
        public static int[] Solution(int[] s, int n)
        {
            var d = new HashSet<int>();

            foreach (var item in s)
            {
                int r = n - item;
                if (d.Contains(r)) return new int[] { item, r };
                else d.Add(item);
            }

            return null;
        }

        public static void Test()
        {
        }

    }
}
