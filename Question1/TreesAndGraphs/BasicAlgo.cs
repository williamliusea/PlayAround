using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TreesAndGraphs
{
    public class BasicAlgo
    {
        public static bool IsTree(GraphNode root, Dictionary<GraphNode, bool> visited)
        {
            if (visited[root])
            {
                return false;
            }
            else if (root.edges != null)
            {
                visited[root] = true;
                foreach (var item in root.edges)
                {
                    if (!IsTree(item, visited))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static void DFTraverse(GraphNode root, HashSet<GraphNode> visited)
        {
            if (!visited.Contains(root))
            {
                visited.Add(root);
                foreach (var item in root.edges)
                {
                    DFTraverse(item, visited);
                }
            }
        }

        public static void BFTraverse(GraphNode root)
        {
            var visited = new HashSet<GraphNode>();
            var q = new Queue<GraphNode>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var t = q.Dequeue();
                if (!visited.Contains(t))
                {
                    visited.Add(t);
                    foreach (var item in t.edges)
                    {
                        q.Enqueue(item);
                    }
                }
            }
        }

        public static bool IsBalanceTree(TreeNode<int> root)
        {
            int depth = 0;
            return IsBalanceTree(root, ref depth);
        }

        private static bool IsBalanceTree(TreeNode<int> root, ref int depth)
        {
            depth = 1;
            if (root.left == null && root.right == null) return true;
            int ld = 0, rd = 0;
            if (root.left != null)
            {
                if (!IsBalanceTree(root.left, ref ld)) return false;
            }
            
            if (root.right != null)
            {
                if (!IsBalanceTree(root.right, ref rd)) return false;
            }

            if (Math.Abs(rd - ld) > 1) return false;
            depth = Math.Max(rd, ld) + 1;
            return true;
            
        }

        public static void Test()
        {
            var root = new TreeNode<int>();
            root.left = new TreeNode<int>();
            root.left.left = new TreeNode<int>();
            Assert.IsFalse(IsBalanceTree(root));
            root.right = new TreeNode<int>();
            Assert.IsTrue(IsBalanceTree(root));
        }
    }
}
