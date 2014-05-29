
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace ArrayAndStrings
{
    /// <summary>
    /// There are two sorted arrays A and B of size m and n respectively. 
    /// Find the median of the two sorted arrays. The overall run time complexity should be O(log (m+n)).
    /// </summary>
    public class MedianTwoSortedArrays
    {
        public static double Solution(int[] A, int[] B)
        {
            if ((A.Length + B.Length) % 2 == 0)
                return (FindKth(A, B, (A.Length + B.Length) / 2, 0, A.Length - 1, 0, B.Length - 1) + FindKth(A, B, (A.Length + B.Length) / 2 - 1, 0, A.Length - 1, 0, B.Length - 1)) / 2;
            else
                return FindKth(A, B, (A.Length + B.Length) / 2, 0, A.Length - 1, 0, B.Length - 1);

        }

        private static double FindKth(int[] A, int[] B, int k, int aStart, int aEnd, int bStart, int bEnd)
        {
            int aLen = aEnd - aStart + 1;
            int bLen = bEnd - bStart + 1;

            if (aLen == 0)
            {
                return B[bStart + k];
            }
            if (bLen == 0)
            {
                return A[aStart + k];
            }

            if (k == 0)
                return A[aStart] < B[bStart] ? A[aStart] : B[bStart];

            int aMid = aLen * k / (aLen + bLen);
            int bMid = k - aMid - 1 + bStart;
            aMid += aStart;

            if (A[aMid] > B[bMid])
            {
                k -= bMid - bStart + 1;
                bStart = bMid + 1;
                aEnd = aMid;
            }
            else
            {
                k -= aMid - aStart + 1;
                aStart = aMid + 1;
                bEnd = bMid;
            }

            return FindKth(A, B, k, aStart, aEnd, bStart, bEnd);
        }

        public static void Test()
        {
            Assert.AreEqual(2, Solution(new int[] { 1, 2 }, new int[] { 3 }));
            Assert.AreEqual(4.5, Solution(new int[] { 1, 2, 3, 4, 5 }, new int[] { 2, 6, 7, 8, 9 }));
            Assert.AreEqual(3, Solution(new int[] { }, new int[] { 3 }));
            Assert.AreEqual(1.5, Solution(new int[] { 1, 2 }, new int[] { }));
        }
    }
}
