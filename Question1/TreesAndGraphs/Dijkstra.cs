using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphs
{
    /// <summary>
    ///  Find the shortest path betweent two nodes in the non-negative edge path cost graph.
    ///  O(|E|+|V|)
    ///  
    /// </summary>
    public class Dijkstra
    {
        public static int Solution(int[,] s, int n, int from, int to)
        {
            var visited = new HashSet<int>();
            var p = new int[n];
            for (int i = 0; i < n; i++)
            {
                p[i] = int.MaxValue;
            }

            p[from] = 0;
            Queue<int> q = new Queue<int>();
            q.Enqueue(from);
            while (q.Count>0)
            {
                var t = q.Dequeue();
                if (!visited.Contains(t))
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (i != t && s[t,i]!=int.MaxValue)
                        {
                            if (p[t]+s[t,i]<p[i])
                            {
                                p[i] = p[t] + s[t, i];
                            }

                            q.Enqueue(i);
                        }
                    }

                    visited.Add(t);
                }
            }

            return p[to];
        }

        public static void Test()
        {
            int[,] s = new int[,] { 
            { int.MaxValue, 7, 9, int.MaxValue, int.MaxValue, 5 }, 
            { 7, int.MaxValue, 10, 15, int.MaxValue, int.MaxValue },
            {9,10, int.MaxValue,11,int.MaxValue,2},
            {int.MaxValue,15,11,int.MaxValue,6,int.MaxValue},
            {int.MaxValue,int.MaxValue,int.MaxValue,6,int.MaxValue,9},
            {5,int.MaxValue,2,int.MaxValue,9,int.MaxValue}};
            Assert.AreEqual(14, Solution(s, 6, 0, 4));//0->5->4
            Assert.AreEqual(7, Solution(s, 6, 0, 2));//0->5->2
            Assert.AreEqual(11, Solution(s, 6, 4, 2));//4->5->2
        }
    }
}
