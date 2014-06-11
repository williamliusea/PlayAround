
namespace TreesAndGraphs
{
    public class FlattenTree
    {
        public class LinkedNode
        {
            public int value;
            public LinkedNode next;
            public LinkedNode(int value)
            {
                this.value = value;
            }
        }
        public static LinkedNode Solution(TreeNode<int> root)
        {
            if (root == null) return null;
            var r = new LinkedNode(root.data);
            if (root.left != null) r.next = Solution(root.left);
            var c = r;
            while (c.next != null) c = c.next;
            if (root.right != null) c.next = Solution(root.right);

            return r;
        }
    }
}
