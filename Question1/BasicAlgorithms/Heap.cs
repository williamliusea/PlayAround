using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicAlgorithms
{
    /// <summary>
    /// Heap implementation
    /// 
    /// </summary>
    public class Heap
    {
        public List<int> data = new List<int>();

        public void Insert(int item)
        {
            data.Add(item);
            int i=data.Count-1;
            int r=(i-1)/2;
            while(i>0)
            {
                if(data[r]<data[i])
                {
                    Swap(r, i);
                }

                i = r;
                r = (i - 1) / 2;
            }
        }

        public int Pop()
        {
            int result = data[0];
            if (data.Count > 1)
            {
                data[0] = data[data.Count - 1];
            }

            data.RemoveAt(data.Count - 1);
            Heapify(0, data.Count);
            return result;
        }
        public void PopSort(int n)
        {
            if (n > 1)
            {
                Swap(0, n - 1);
                Heapify(0, n - 1);
                PopSort(n - 1);
            }

        }

        public static void HeapSort(List<int> input)
        {
            Heap h=new Heap();
            h.data = input;
            for(int i = h.data.Count / 2;i>=0;i--)
            {
                h.Heapify(i, h.data.Count);
            }

            h.PopSort(h.data.Count);
        }

        public static void Test()
        {
            var h = new Heap();
            List<int> d = new List<int>() { 12, 3, 6, 7, 3, 9, 5, 6, 1 };
            d.ForEach(x => h.Insert(x));
            Console.WriteLine(string.Join(" ", h.data));
            while (h.data.Count > 0)
            {
                Console.Write(h.Pop() + " ");
            }
            Console.WriteLine();
            
            HeapSort(d);
            Console.WriteLine(string.Join(" ", d));
        }
        
        public void Heapify(int root, int n)
        {
            int l = root * 2 + 1;
            int r = root * 2 + 2;
            int larger = root;
            if (l < n && data[l] > data[larger]) larger = l;
            if (r < n && data[r] > data[larger]) larger = r;
            if (larger!=root)
            {
                Swap(larger, root);
                Heapify(larger, n);
            }
        }

        private void Swap(int r, int i)
        {
            int temp = data[r];
            data[r] = data[i];
            data[i] = temp;
        }
    }
}
