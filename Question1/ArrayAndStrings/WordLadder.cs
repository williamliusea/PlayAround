using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace ArrayAndStrings
{
    /// <summary>
    /// Given two words (start and end), and a dictionary, find the length of shortest transformation sequence from start to end, such that:
    /// Only one letter can be changed at a time
    /// Each intermediate word must exist in the dictionary
    /// For example,
    /// 
    /// Given:
    /// start = "hit"
    /// end = "cog"
    /// dict = ["hot","dot","dog","lot","log"]
    /// As one shortest transformation is "hit" -> "hot" -> "dot" -> "dog" -> "cog",
    /// return its length 5.
    /// 
    /// Note:
    /// Return 0 if there is no such transformation sequence.
    /// All words have the same length.
    /// All words contain only lowercase alphabetic characters.
    /// </summary>
    public class WordLadder
    {
        /// <summary>
        /// Breath first search
        /// </summary>
        /// <returns></returns>
        public static int Solution1(string start, string end, HashSet<string> dict)
        {
            var q = new Queue<string>();
            var dq = new Queue<int>();
            q.Enqueue(start);
            dq.Enqueue(1);
            while (q.Count > 0)
            {
                var s = q.Dequeue();
                var cd = dq.Dequeue();
                if (DistanceOne(s, end))
                {
                    return cd + 1;
                }

                var temp = new List<string>();
                foreach (var i in dict)
                {
                    if (DistanceOne(i, s))
                    {
                        q.Enqueue(i);
                        dq.Enqueue(cd + 1);
                        temp.Add(i);
                    }
                }

                foreach (var item in temp)
                {
                    dict.Remove(item);
                }
            }

            return 0;
        }

        private static bool DistanceOne(string a, string b)
        {
            var r = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                {
                    r++;
                }
                if (r > 1)
                {
                    return false;
                }
            }

            return r == 1;
        }

        public static void Test()
        {
            var dict = new HashSet<string> { "hot", "dot", "dog", "lot", "log" };
            Assert.AreEqual(5, Solution1("hit", "cog", dict));
        }
    }
}
