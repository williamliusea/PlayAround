using System.Collections.Generic;

namespace BasicAlgorithms
{
    public class BinaryTree<T>
    {
        public static void BFS(TreeNode<T> root)
        {
            var q = new Queue<TreeNode<T>>();
            q.Enqueue(root);
            while (q.Count > 0)
            {
                var c = q.Dequeue();
                if (c.left != null)
                {
                    q.Enqueue(c.left);
                }
                if (c.right != null)
                {
                    q.Enqueue(c.right);
                }
            }
        }
    }
}
