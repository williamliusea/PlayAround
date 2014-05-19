using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreesAndGraphs
{
    /// <summary>
    /// Design an algorithm and write code to find the first common ancestor of two nodes in a binary tree. 
    /// Avoid storing additional nodes in a data structure. Note: it is not necessarily a binary search tree
    /// 
    /// Throughts: when contructing a full path from node to root. the first common ancestor will appear in the path.
    /// Therefore, we first compute the path P1, P2. Then try to align two path to make sure they compare at the 
    /// same height. From the node up, the first items that are equal is what we want to find.
    /// time: O(logn)
    /// space: O(1)
    /// </summary>
    class Question7
    {
        public static TreeNode common;
        public class TreeNode
        {
            public TreeNode left;
            public TreeNode right;
            public TreeNode parent;
            public int d;
            private static int count = 0;
            public TreeNode()
            {
                d = count;
                count++;
            }

            public override string ToString()
            {
                return d.ToString();
            }
        }

        public static int Depth(TreeNode node)
        {
            var depth = 0;
            var cur = node;
            while(cur.parent!=null)
            {
                depth++;
                cur = cur.parent;
            }
            return depth;
        }

        /// <summary>
        /// Assumption of this solution is that each node has a parent link
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static TreeNode Solution1(TreeNode a, TreeNode b)
        {
            var d1 = Depth(a);
            var d2 = Depth(b);
            var ca=a;
            var cb=b;
            while(ca!=cb)
            {
                if (d1 >=d2)
                {
                    ca = ca.parent;
                    d1--;
                }
                
                if(d2>d1)
                {
                    cb = cb.parent;
                    d2--;
                }
            }

            return ca;
        }

        
        public static int Find(TreeNode root, TreeNode a, TreeNode b)
        {
            int result=0;
            if(root==a) result|=1;
            if (root==b) result|=2;
            if (root.left != null && common == null)
                result|=Find(root.left,a,b);
            if (root.right != null && common == null)
                result|=Find(root.right,a,b);
            
            if (result==3 && common==null)
            {
                common=root;
            }

            return result;
        }
        /// <summary>
        /// Assumption here is that the node does not has a parent link
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static TreeNode Solution2(TreeNode root, TreeNode a, TreeNode b)
        {
            common = null;
            Find(root, a, b);
            return common;
        }

        public static void Test()
        {
            var root = new TreeNode();
            root.left = new TreeNode();
            root.left.parent=root;
            root.right = new TreeNode();
            root.right.parent=root;
            var r = root.left;
            r.left = new TreeNode();
            r.left.parent=r;
            r.left.left = new TreeNode();
            r.left.left.parent=r.left;
            Assert.AreEqual(0, Solution1(r.left.left, root.right).d);
            Assert.AreEqual(1, Solution1(r.left.left, root.left).d);
            Assert.AreEqual(0, Solution2(root, r.left.left, root.right).d);
            Assert.AreEqual(1, Solution2(root, r.left.left, root.left).d);

        }
    }
}
