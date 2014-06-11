using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphs
{
    public class ToTree
    {
        private static int preindex = 0;        
        public static TreeNode<char> Solution(string inorder, string preorder, int b, int e)
        {
            if (b >= e) return null;
            var r = new TreeNode<char>(preorder[preindex++]);
            if (b == e-1) return r;
            int i = Search(inorder, b, e, r.data);
            r.left = Solution(inorder, preorder, b, i);
            r.right = Solution(inorder, preorder, i + 1, e);
            return r;
        }

        public static void solution2(TreeNode<char> root, Tuple<char,int>[] s, int n, ref int i)
        {
            if (i >= s.Length) return;
            var r = new TreeNode<char>(s[i].Item1);
            if((s[i].Item2-1)/2==n)
            {
                if (s[i].Item2 % 2 == 1) root.left = r;
                if (s[i].Item2 % 2 == 0) root.right = r;
                i++;
            }
        }
        private static int Search(string s, int b, int e, char c)
        {
            for (int i = b; i < e; i++)
                if (s[i] == c) return i;
            return -1;
        }

        public static void Test()
        {
            preindex = 0;
            var r = Solution("dbeafc", "abdecf", 0, 6);
        }
    }
}
