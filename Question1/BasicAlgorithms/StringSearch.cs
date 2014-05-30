using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicAlgorithms
{

    /// <summary>
    /// using KMP algorithm. 
    /// Compare with other algorithm, although it require a preprocessing to constructure a lookup table,
    /// it achieve O(n) search time.
    /// But if size of the pattern string is big, say k<n. it may be a big problem to store another long string.
    /// 
    /// </summary>
    public class StringSearch
    {
        int[] lookup;
        string pattern;
        public StringSearch(string pattern)
        {
            this.pattern=pattern;
            lookup = new int[pattern.Length];
            if (pattern.Length > 1)
            {
                int p = 2;
                int current = 0;
                while(p<pattern.Length)
                {
                    // Use p-1 is to shift the lookup one to the right. so when mismatch happens
                    // we don't need to look back one item.
                    if(pattern[p-1]==pattern[current])
                    {
                        current++;
                        lookup[p] = current;
                        p++;
                    }
                    else if(current>0)
                    {
                        current = lookup[current];
                    }
                    else
                    {
                        p++;
                    }
                }
            }
        }

        public int Search(string input)
        {
            int p = 0;
            int current = 0;
            while(p+current<input.Length)
            {
                if(this.pattern[current]==input[p+current])
                {
                    current++;
                }
                else if(current>0)
                {
                    current = lookup[current];
                    p += current - lookup[current];
                }
                else
                {
                    p++;
                }
                if(current==this.pattern.Length)
                {
                    return p;
                }
            }

            return -1;
        }

        public static void Test()
        {
            var s = new StringSearch("abc");
            string toSearch="abcde";
            Assert.AreEqual(toSearch.IndexOf("abc"), s.Search(toSearch));
            s = new StringSearch("ababab");
            toSearch = "abcdeababcababab";
            Assert.AreEqual(toSearch.IndexOf("ababab"), s.Search(toSearch));

        }
    }
}
