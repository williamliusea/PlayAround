
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace ArrayAndStrings
{
    public class RegexMatch
    {
        public class Item
        {
            public char sym;
            public bool star;
        }

        public static bool Solution(string r, string s)
        {
            var reg = new List<Item>();
            for (int i = 0; i < r.Length; i++)
            {
                switch(r[i])
                {
                    case '*':
                        reg[reg.Count - 1].star = true;
                        break;
                    default:
                        var t = new Item();
                        t.sym = r[i];
                        reg.Add(t);
                        break;
                }
            }
            if (reg.Count == 0) return false;
            return IsMatch(s, 0, reg, 0);            
        }

        private static bool IsMatch(string s, int i, List<Item> reg, int j)
        {
            if (string.IsNullOrEmpty(s)) return false;
            if (j==reg.Count)
                return s.Length==i;
            bool ret = false;
            if (reg[j].star)
            {
                // match 0 char
                ret = IsMatch(s, i, reg, j + 1);
                if (ret) return true;
                int k=i;
                // match 0+ char
                while (k < s.Length && (s[k] == reg[j].sym || reg[j].sym == '.'))
                {
                    ret = IsMatch(s, k+1, reg, j+1);
                    if (ret) return true;
                    k++;
                }
                if (k == s.Length)
                    return j == reg.Count - 1;
            }
            else
            {
                if (i == s.Length) return false;
                if (s[i]==reg[j].sym || reg[j].sym=='.')
                {
                    ret = IsMatch(s, i + 1, reg, j + 1);
                }
            }

            return ret;
        }

        public static void Test()
        {
            Assert.IsFalse(Solution("a", ""));
            Assert.IsTrue(Solution("a", "a"));
            Assert.IsTrue(Solution("ab*", "a"));
            Assert.IsTrue(Solution("ab*", "ab"));
            Assert.IsTrue(Solution("ab*", "abbb"));
            Assert.IsFalse(Solution("ab*", "abbbc"));
            Assert.IsFalse(Solution("ab*", "bbbc"));
            Assert.IsTrue(Solution("ab*.", "ac"));
            Assert.IsTrue(Solution("ab*.", "abc"));
            Assert.IsFalse(Solution("ab*.", "acd"));
            Assert.IsTrue(Solution("a.*bc*", "abc"));
            Assert.IsTrue(Solution("a.*bc*", "adfabccc"));
            Assert.IsTrue(Solution("a.*bc*", "adafbc"));
            Assert.IsFalse(Solution("a.*bc*", "afdabcd"));
        }
    }

}
