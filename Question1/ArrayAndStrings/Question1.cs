
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ArrayAndStrings
{
    /// <summary>
    /// Implement an algorithm to determine if a string has all unique characters. What if you cannot use additional data structures
    /// </summary>
    public static class Question1
    {
        static bool Solution1(string input)
        {
            /*
             *  Start 10:18
             *  Ask: is it only ASCII?
             *  Answer: Yes
             *  Have an array of 256 (we can optimize this if only readable chars)
             *  End 10:26
             */

            bool[] s = new bool[256];
            foreach (var i in input)
            {
                if (s[i])
                {
                    return false;
                }
                s[i] = true;
            }

            return true;
        }

        static bool Heapify(char[] s, int root)
        {
            int l = root * 2 + 1;
            int r = root * 2 + 1;

            if ((l < s.Length && s[l] == s[root]) || (r < s.Length && s[r] == s[root]))
                return false;
            int m = root;
            if (l < s.Length && s[l] > s[m]) m = l;
            if (r < s.Length && s[r] > s[m]) m = r;
            if (m != root)
            {
                char temp = s[root];
                s[root] = s[m];
                s[m] = temp;
                return Heapify(s, m);
            }

            return true;
        }

        static bool Solution2(string input)
        {
            /*
             *  Start 10:26
             *  What if you cannot use additional data structures.
             *  Use max heap. constructing will know .
             *  This is a wrong solution. Because the heap does not guarantee to compare each pair.
             *  
             *  The only solution is to sort the array and compare it. 
             */
            char[] s = input.ToCharArray();
            for (int i = (s.Length - 1) / 2; i >= 0; i--)
            {
                if (!Heapify(s, i))
                    return false;
            }
            return true;
        }

        public static void Test()
        {
            string s = "123456";
            string t = "23452ased";
            Assert.IsTrue(Solution1(s));
            Assert.IsFalse(Solution1(t));
            Assert.IsTrue(Solution2(s));
            Assert.IsFalse(Solution2(t));
        }
    }
}
