using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question2
{
    using System.IO;

    public class Node
    {
        public int x;
        public int y; 
        public Node Next;
    };

    public class Cell : Node
    {
        public Cell(int x, int y, int value)
        {
            this.x = x;
            this.y = y;
            this.value = value;
            this.xMin = int.MaxValue/2;
            this.yMin = this.xMin;
            this.min = this.xMin;
        }

        public Node xNext;

        public Node yNext;

        public int xMin;

        public int yMin;

        public int min;

        public int value;
    }
    public class path
    {
        public int difficulty; 
        public Node Pathlink;
    }
    class Program
    {
        private static void Solve(int m, int n, int[,] matrix, Cell[,] t)
        {
            t[m - 1, n - 1] = new Cell(m - 1, n - 1, matrix[m - 1, n - 1]);
            for (int i = 0; i < m - 1; i++)
            {
                var c = new Cell(i, n - 1, matrix[i, n - 1]);
                c.xNext = t[m - 1, n - 1];
                c.xMin = t[m - 1, n - 1].value;
                c.Next = t[m - 1, n - 1];
                t[i, n - 1] = c;
            }
            for (int i = 0; i < n - 1; i++)
            {
                var c = new Cell(m - 1, i, matrix[m - 1, 1]);
                c.Next = t[m - 1, n - 1];
                c.yNext = t[m - 1, n - 1];
                c.yMin = t[m - 1, n - 1].value;
                t[m - 1, i] = c;
            }

            for (int i = m - 2; i >= 0; i--)
            {
                for (int j = n-2; j>=0; j--)
                {
                    t[i, j] = new Cell(i, j, matrix[i, j]);
                    // y axis search
                    if (t[i, j + 1].xMin+matrix[i,j+1]<t[i,j+1].yMin)
                    {
                        t[i, j].yNext = t[i, j + 1];
                        t[i, j].yMin = t[i, j + 1].xMin + matrix[i, j + 1];
                    }
                    else
                    {
                        t[i, j].yNext = t[i, j + 1].yNext;
                        t[i, j].yMin = t[i, j + 1].yMin;
                    }

                    // x axis search
                    if (t[i + 1, j].yMin + matrix[i+1, j] < t[i + 1, j].xMin)
                    {
                        t[i, j].xNext = t[i+1, j ];
                        t[i, j].xMin = t[i+1, j].yMin + matrix[i+1, j];
                    }
                    else
                    {
                        t[i, j].xNext = t[i+1, j].xNext;
                        t[i, j].xMin = t[i+1, j ].xMin;
                    }

                    if (t[i, j].yMin < t[i, j].xMin)
                    {
                        t[i, j].Next = t[i, j].yNext;
                        t[i, j].min = t[i, j].yMin;
                    }
                    else
                    {
                        t[i, j].Next = t[i, j].xNext;
                        t[i, j].min = t[i, j].xMin;
                    }
                }
            }
        }
        private static void Main(string[] args)
        {
            int m = 4;
            int n = 4;
            string input = "7 9 2 11 13 23 1 3 14 11 20 6 22 44 3 15";
            string[] items = input.Split(' ');
            int[,] matrix = new int[m, n];
            Cell[,] t = new Cell[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = int.Parse(items[i + j*m]);
                }
            }
            Solve(m,n,matrix,t);
            var p = t[0, 0];
            Console.Write((p.min+p.value).ToString()+ " ");
            while (p.Next != null)
            {
                Console.Write(p.value+"->");
                p = (Cell)p.Next;
            }

            Console.Write(p.value);
            Console.ReadKey();
        }
    }
}
