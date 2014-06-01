using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAndStrings
{
    /// <summary>
    /// Merge Intervals
    /// Given a collection of intervals, merge all overlapping intervals.
    /// For example,
    /// Given [1,3],[2,6],[8,10],[15,18],
    /// return [1,6],[8,10],[15,18].
    /// </summary>
    public class MergeIntervals
    {
        public class Foo
        {
            public Foo(int a, int b)
            {
                this.start = a;
                this.end = b;
            }
            public int start;
            public int end;
        }
        public static List<Foo> Solution(List<Foo> s)
        {
            var r = new List<Foo>();
            var t = new List<int>();
            for (int i = 0; i < s.Count; i++)
            {
                t.Add(i);
            }
            t=t.OrderBy(x => s[x].start).ToList();
            var pre = s[t[0]];
            for (int i = 1; i < t.Count; i++)
            {
                var cur = s[t[i]];
                if (cur.start<=pre.end)
                {
                    if(cur.end>pre.end) pre.end = cur.end;                    
                }
                else
                {
                    r.Add(pre);
                    pre = cur;
                }                
            }

            r.Add(pre);
            return r;
        }

        public static void Test()
        {
            var a= Solution(new List<Foo>{new Foo(1,6),new Foo(4,5),new Foo(2,7)});
            Assert.AreEqual(1, a.Count);
            a = Solution(new List<Foo> { new Foo(1, 2), new Foo(4, 5), new Foo(3, 7) });
            Assert.AreEqual(2, a.Count);
        }
    }
}
