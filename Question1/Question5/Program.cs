using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question5
{
    class Program
    {
        static void Main(string[] args)
        {
            TrieNode root = new TrieNode();
            string[] words = new string[] { "a", "an","and", "bus","dog","god","post","stop" };
            words.ToList().ForEach(x => { root.Add(x); });
            Console.WriteLine(string.Join(" ", root.FindAnagram("stop")));
            Console.WriteLine(string.Join(" ", root.PrefixSearch("a")));
            Console.WriteLine(root.Search("bus"));
            Console.WriteLine(root.Search("sbu"));
            Console.ReadKey();
        }
    }
}
