using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayAndStrings
{
    /// <summary>
    /// Custom Sort
    /// You have a set of numbers. a1, a2, a3, a4.....an. numbers are random and may repeat.
    /// Arrange the number in order such that x1 > x2 < x3 > x4 < x5 > x6.......
    /// x1 has no relation ship with x3, x4, x5... x2 has no relation ship with x4, x5... x3 has no relation ship with x1, x5, x6... and so on.
    /// There maybe many feasible solution to this problem see that the final answer reaches any one of them. 
    /// If the input is like 22,22,22 then it should output a message as no feasible solution but for an input like this 7 7 7 3 3 it should print out a solution like : 7 3 7 3 7.
    /// </summary>
    public class CustomSort
    {
        public static int[] solution(int[] a)
        {
            var s = a.ToList().OrderBy(x => x).ToList();
            int mid = s.Count / 2;
            int i = mid + 1;
            int j = mid - 1;
            int[] r = new int[a.Length];
            int k = 1;
            r[0] = s[mid];
            while(i<a.Length)
            {
                if (s[i] == s[j]) return null;// no solution
                r[k++] = s[j];
                r[k++] = s[i];
                i++; j--;
            }

            if (s.Count%2==0)
            {
                r[s.Count - 1] = s[0];
            }

            return r;
        }

        public static void Test()
        {
            string s = string.Join(" ", solution(new int[] { 7, 7, 7, 3, 3, 3 }));
            Assert.AreEqual("7 3 7 3 7 3", s);
            Assert.AreEqual("7 3 7 3 7", string.Join(" ", solution(new int[] { 7, 7, 7, 3, 3 })));
            Assert.AreEqual("5 4 6 3 7 2 8 1 9 0", string.Join(" ", solution(new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 })));
            Assert.IsNull(solution(new int[] { 7, 7, 7,7,3,3 }));
        }

    }
}
