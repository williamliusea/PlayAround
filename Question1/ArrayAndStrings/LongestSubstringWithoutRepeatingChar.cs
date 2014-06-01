using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAndStrings
{
    /// <summary>
    /// Given a string, find the length of the longest substring without repeating characters. 
    /// For example, the longest substring without repeating letters for "abcabcbb" is "abc", 
    /// which the length is 3. For "bbbbb" the longest substring is "b", with the length of 1.
    /// 
    /// 
    /// </summary>
    public class LongestSubstringWithoutRepeatingChar
    {

        public static string Solution(string s)
        {
            string r = string.Empty;
            var m = new Dictionary<char, int>();
            var b = 0;
            int i = 0;
            string t;
            for (; i < s.Length; i++)
            {
                if (m.ContainsKey(s[i]))
                {
                    t= s.Substring(b, i - b);
                    if (t.Length > r.Length) r = t;
                    int nb = m[s[i]] + 1;
                    for (int j = b; j < nb; j++)
                    {
                        m.Remove(s[j]);
                    }

                    b = nb;
                }

                m[s[i]] = i;
            }

            t = s.Substring(b, i - b);
            if (t.Length > r.Length) r = t;

            return r;
        }

        public static void Test()
        {
            Assert.AreEqual("b", Solution("bbbbb"));
            Assert.AreEqual("abc", Solution("abcabcbb"));
            Assert.AreEqual("cbad",Solution("abcbad"));
        }
    }
}
