using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphs
{
    /// <summary>
    /// Implement a function to check if a binary tree is balanced. for the purposes of this question, 
    /// a balanced tree is defined to be a tree such that the heights of the two subtrees of any node never differ by more than one
    /// </summary>    
    class Question1
    {
        public static bool result = true;
        public static int maxdepth = 0;
        public static int mindepth = int.MaxValue;



        public static void Solution1(TreeNode root, int depth)
        {
            if (root == null)
            {
                if (depth > maxdepth) maxdepth = depth;
                if (depth < mindepth) mindepth = depth;
                return;
            }

            Solution1(root.left, depth+1);
            Solution1(root.right,depth+1);
        }

        public static void Test()
        {
            var root = new TreeNode();
            root.left = new TreeNode();
            root.right = new TreeNode();
            Solution1(root, 0);
            Assert.IsTrue(maxdepth - mindepth <= 1);
            maxdepth = 0; mindepth = int.MaxValue;
            var r = root.left;
            r.left = new TreeNode();
            r.left.left = new TreeNode();
            Solution1(root, 0);
            Assert.IsFalse(maxdepth - mindepth <= 1);

        }
    }
}
