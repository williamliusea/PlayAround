
namespace TreesAndGraphs
{
    public class TreeNode<T>
    {
        public TreeNode<T> left;
        public TreeNode<T> right;
        public T data;
        public TreeNode(T data)
        {
            this.data = data;
        }
        public TreeNode() { }
        public override string ToString()
        {
            return data.ToString();
        }
    }
}
