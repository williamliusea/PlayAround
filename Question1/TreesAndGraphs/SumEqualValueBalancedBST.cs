using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BasicAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TreesAndGraphs
{
    /// <summary>
    /// Q5 Find elements that sum to a given value in a balanced BST
    /// Find two elements in balanced BST which sums to a given a value. Constraints Time O(n) and space O(logn).          
    ///         6
    ///     3         8
    ///  1    4    7      12
    ///  sum = 16 o/p should be 4 and 12
    /// </summary>
    public class SumEqualValueBalancedBST
    {

        public static Tuple<TreeNode<int>, TreeNode<int>> Solution(TreeNode<int> root, int n)
        {
            var l = new Stack<TreeNode<int>>();
            var r = new Stack<TreeNode<int>>();
            Left(l, root);
            Right(r, root);
            var a = l.Pop();
            var b = r.Pop();
            while(a.data<b.data)
            {
                if (a.data+b.data>n)
                {
                    Right(r, b.left);
                    b = r.Pop();
                }
                else if(a.data+b.data<n)
                {
                    Left(l, a.right);
                    a = l.Pop();
                }
                else
                {
                    return new Tuple<TreeNode<int>, TreeNode<int>>(a, b);
                }
            }

            return null;
        }

        public static void Test()
        {
            var a = new TreeNode<int>() { data = 6 };
            var l = new TreeNode<int>() { data = 3 };
            var r = new TreeNode<int>() { data = 8 };
            a.right = r;
            a.left = l;
            
            var c = r;
            var b = l;
            l = new TreeNode<int>() { data = 1 };
            r = new TreeNode<int>() { data = 4 };
            b.right = r;
            b.left = l;
            l = new TreeNode<int>() { data = 7 };
            r = new TreeNode<int>() { data = 12 };
            c.right = r;
            c.left = l;
            Assert.IsNull(Solution(a, 2));
            var ret=Solution(a, 11);
            Assert.AreEqual(3, ret.Item1.data);
            Assert.AreEqual(8, ret.Item2.data);

            ret = Solution(a, 16);
            Assert.AreEqual(4, ret.Item1.data);
            Assert.AreEqual(12, ret.Item2.data);
        }
        private static void Left(Stack<TreeNode<int>> s, TreeNode<int> root)
        {
            while (root != null)
            {
                s.Push(root);
                root = root.left;
            }
        }
        private static void Right(Stack<TreeNode<int>> s, TreeNode<int> root)
        {
            while (root != null)
            {
                s.Push(root);
                root = root.right;
            }
        }
    }
}
