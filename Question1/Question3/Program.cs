
using System;
namespace Question3
{
    class Program
    {
        static void Solution(int m, int n, int[,] s)
        {
            // buffer the array one row and one column for convenience. 
            // can optimize to use n*2 (if n is smaller) or m*2 (if m is smaller)
            int[,] t = new int[m + 1, n + 1];

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (s[i - 1, j - 1] == 0 || (!(j == 1 && i == 1) && t[i - 1, j] == 0 && t[i, j - 1] == 0))
                    {
                        continue;
                    }

                    t[i, j] = t[i - 1, j] > t[i, j - 1] ? t[i - 1, j] + s[i - 1, j - 1] : t[i, j - 1] + s[i - 1, j - 1];
                }
            }

            int max = 0;
            int x = 0, y = 0;
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (t[i, j] > max)
                    {
                        max = t[i, j];
                        x = j - 1;
                        y = i - 1;
                    }

                    Console.Write(t[i, j] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine("{0} {1} {2}", max, x, y);
        }
        static void Main(string[] args)
        {
            int m = 3, n = 4;
            int[,] s = new int[m, n];
            var input = "1 1 0 1 0 1 1 1 1 0 0 1";
            string[] items = input.Split(' ');
            for (int i = 0; i < items.Length; i++)
            {
                s[i / n, i % n] = int.Parse(items[i]);
            }
            Solution(m, n, s);
            Console.ReadKey();
        }
    }
}
