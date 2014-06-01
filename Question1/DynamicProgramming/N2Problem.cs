using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    /// <summary>
    /// N-2 Problem
    /// You are given 2 machines. There are N jobs you have to perform. 
    /// Job i takes Ai time to perform on machine A and Bi time to perform on machine B. 
    /// Each job should be done either on machine A or B. The jobs should be performed in order. 
    /// Given the arrays A and B and an integer K, find the minimum time required to complete the jobs, 
    /// given that you cannot do more than K jobs on the same machine continuously. 
    /// This can be done in O(N K)space and time. This can be improved to O(N K) time and O(N ) space and further to O(N logN ) time.
    /// 
    /// It shall use dynamic programming...
    /// 10:18
    /// </summary>
    public class N2Problem
    {

        /// <summary>
        /// Greedy solution
        /// For
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static int Solution1(int[] a, int[] b, int k)
        {
            bool[] c = new bool[a.Length];
            for (int i = 0; i < a.Length; i++)
            {

            }
            return 0;
        }

        public static void Test()
        { }
    }

}
