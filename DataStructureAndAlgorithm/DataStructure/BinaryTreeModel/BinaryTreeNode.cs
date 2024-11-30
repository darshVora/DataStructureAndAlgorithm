namespace DataStructureAndAlgorithm.DataStructure.BinaryTreeModel
{
    public class BinaryTreeNode<T>(T value, BinaryTreeNode<T> left = null, BinaryTreeNode<T> right = null)
    {
        public T Value { get; set; } = value;
        public BinaryTreeNode<T> Left { get; set; } = left;
        public BinaryTreeNode<T> Right { get; set; } = right;
    }
}
 