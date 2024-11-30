using DataStructureAndAlgorithm.DataStructure.BinaryTreeModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.Algorithm.BinaryTree
{
    public static class BinaryTreeTraversal
    {
        public static IEnumerable<T> BreadthFirstEnumerator<T>(this BinaryTreeNode<T> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            Queue<BinaryTreeNode<T>> queue = new();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                yield return current.Value;

                if (current.Left != null)
                {
                    queue.Enqueue(current.Left);
                }

                if (current.Right != null)
                {
                    queue.Enqueue(current.Right);
                }
            }
        }

        public static IEnumerable<T> DepthFirstEnumerator<T>(this BinaryTreeNode<T> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }

            Stack<BinaryTreeNode<T>> stack = new();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                yield return current.Value;

                if (current.Right != null)
                {
                    stack.Push(current.Right);
                }

                if (current.Left != null)
                {
                    stack.Push(current.Left);
                }
            }
        }
    }
}
