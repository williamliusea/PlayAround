using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Question1
{
    class Solution
    {
        static List<List<int>> inputs;
        static int n, k;
        static int nCase;
        static int total;

        class Node
        {
            public int person;
            public int min;
            public int max;
            public List<Node> nexts;
            public HashSet<int> nextPersons;

            public Node()
            {
                this.nexts = new List<Node>();
                this.nextPersons = new HashSet<int>();
            }

            public override string ToString()
            {
                return string.Format("{0} {1} {2}", person, min, max);
            }
        }
        static void Solve(TextReader input, TextWriter output)
        {
            nCase = int.Parse(input.ReadLine());
            for (int i = 0; i < nCase; i++)
            {
                string[] temp = input.ReadLine().Split(' ');
                n = int.Parse(temp[0]);
                k = int.Parse(temp[1]);
                inputs = new List<List<int>>(n);
                total = 0;
                if (k > n)
                {
                    output.WriteLine(0);
                    continue;
                }

                for (int j = 0; j < n; j++)
                {
                    temp = input.ReadLine().Split(' ');
                    List<int> l = temp.Select(x => int.Parse(x)).ToList();
                    int temp1 = l[0];
                    l.RemoveAt(0);
                    inputs.Add(l);
                    if (l.Count != temp1)
                    {
                        int aa = 0;
                    }
                    total += l.Count;
                }

                //Solution2(new int[n], 0);
                solution3();
                //output.WriteLine(possible.Count);
            }

        }
        static void solution3()
        {
            var t = new List<Tuple<int, int>>(total);
            var s = new List<Tuple<int, int>>();
            var h = new List<int>();
            var p2n = new List<List<Node>>();
            for (var i = 0; i < n; i++)
            {
                var input = inputs[i];
                input.Sort();
                s.Add(new Tuple<int, int>(input[0], input[input.Count - 1]));
                t.AddRange(inputs[i].Select(x => new Tuple<int, int>(i, x)));
            }

            for (var j = 0; j < t.Count; j++)
            {
                int bc = 0;
                int ac = 0;
                for (var i = 0; i < n; i++)
                {
                    if (t[j].Item1 == i)
                        continue;
                    if (s[i].Item1 < t[j].Item2)
                        bc++;
                    if (s[i].Item2 > t[j].Item2)
                        ac++;
                }
                if (bc >= k - 1 && ac >= n - k)
                {
                    h.Add(t[j].Item2);
                }
            }

            Console.Write(h.Count);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                Solve(sr, Console.Out);
            }

            Console.ReadKey();
        }
    }
}
