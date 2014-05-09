using System;

namespace Question4
{
    class Program
    {
        static int FindNumber(int[] s, int n, int start, int end)
        {
            //if(start == end && s[start]!=n)
            //{
            //    return -1;
            //}

            int mid = (start + end) / 2;
            Console.WriteLine("s:{0} m:{1} e:{2}", start, mid, end);
            if (s[mid] > n)
            {
                return FindNumber(s, n, start, mid - 1);
            }
            else if (s[mid] < n)
            {
                return FindNumber(s, n, mid + 1, end);
            }
            else
            {
                return mid;
            }
        }

        static void Main(string[] args)
        {
            int[] s = new int[] { 0, 1, 2, 2, 3, 4, 5, 6, 6, 6, 7, 7, 7, 7, 8, 9 };
            for (int j = 0; j < 10; j++)
            {
                int i = FindNumber(s, j, 0, s.Length - 1);
                int i1 = i, i2 = i;
                while (i1 < s.Length && s[i1] == j)
                {
                    i1++;
                }
                while (i2 >= 0 && s[i2] == j)
                {
                    i2--;
                }

                Console.WriteLine(i.ToString() + " " + (i1 - i2 - 1).ToString());

            }
            Console.ReadKey();
        }
    }
}
