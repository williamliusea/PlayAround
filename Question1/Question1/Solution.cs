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

                Solution2(new int[n], 0);
                output.WriteLine(possible.Count);
            }

        }

        static int Solution1()
        {
            var t = new List<Tuple<int, int>>(total);
            var s = new int[n];
            var h = new HashSet<int>();
            for (var i = 0; i < n; i++)
            {
                t.AddRange(inputs[i].Select(x => new Tuple<int, int>(i, x)));
                s[i] = inputs[i].Count;
            }

            t = t.OrderBy(x => x.Item2).ToList();

            int j = 0;
            do
            {
                h.Add(t[j].Item1);
                s[t[j].Item1]--;
                j++;
            } while (h.Count < k);
            j--;

            int j2 = j;
            while (h.Count < n)
            {
                if (s[t[j2].Item1] > 0)
                {
                    h.Add(t[j2].Item1);
                    s[t[j2].Item1]--;
                }
                j2++;
            }

            var h1 = new HashSet<int>();
            int j1 = t.Count;
            while (h1.Count < (n - k))
            {
                j1--;
                if (s[t[j1].Item1] > 0)
                {
                    h1.Add(t[j1].Item1);
                    s[t[j1].Item1]--;
                }
            }

            return j1 - j;
        }

        static HashSet<int> possible = new HashSet<int>();
        static void Solution2(int[] choices, int person)
        {
            if (person >= n)
            {
                int[] temp = (int[])choices.Clone();
                temp = temp.OrderBy(x => x).ToArray();
                possible.Add(temp[k - 1]);
                return;
            }

            for (int i = 0; i < inputs[person].Count; i++)
            {
                choices[person] = inputs[person][i];
                Solution2(choices, person + 1);
            }
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
