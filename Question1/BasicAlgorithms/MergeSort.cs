using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicAlgorithms
{
    public class MergeSort
    {

        public static int[] Sort(int[] s)
        {
            return Sort(s, 0, s.Length - 1);
        }

        private static int[] Sort(int[] s, int b, int e)
        {
            if (b == e) return new int[] { s[b] };
            int mid = (b + e) / 2;
            var l = Sort(s, b, mid);
            var r = Sort(s, mid + 1, e);
            int[] ret = new int[l.Length + r.Length];
            int i = 0, j = 0;
            while (i < l.Length && j < r.Length)
                if (l[i] < r[j]) ret[i + j] = l[i++];
                else ret[i + j] = r[j++];
            if (i < l.Length)
                for (; i < l.Length; i++) ret[i + j] = l[i];
            if (j < r.Length)
                for (; j < r.Length; j++) ret[i + j] = r[j];
            return ret;
        }

        public static void Test()
        {
            Assert.IsTrue(Verify(Sort(new int[] { 8, 1, 6, 2, 7, 4 })));
            Assert.IsTrue(Verify(Sort(new int[] { 8, 1, 6, 2, 7 })));
            Assert.IsTrue(Verify(Sort(new int[] { 1, 6 })));

        }

        private static bool Verify(int[]s)
        {
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i - 1] > s[i]) return false;
            }
            return true;
        }
    }
}
