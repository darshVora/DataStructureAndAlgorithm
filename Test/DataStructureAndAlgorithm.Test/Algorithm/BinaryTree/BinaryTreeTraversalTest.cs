using DataStructureAndAlgorithm.Algorithm.BinaryTree;
using DataStructureAndAlgorithm.DataStructure.BinaryTreeModel;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace DataStructureAndAlgorithm.Test.Algorithm.BinaryTree
{
    [TestFixture]
    internal class BinaryTreeTraversalTest
    {

        // SetUp method to initialize the test environment
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Creates tree
        /// </summary>
        /// <returns>Root node of tree</returns>
        public static BinaryTreeNode<int> CreateTree()
        {
            //      5
            //    /   \
            //   6     7
            //  / \     \
            // 8   9    10
            var root = new BinaryTreeNode<int>(5);
            root.Left = new BinaryTreeNode<int>(6);
            root.Right = new BinaryTreeNode<int>(7);
            root.Left.Left = new BinaryTreeNode<int>(8);
            root.Left.Right = new BinaryTreeNode<int>(9);
            root.Right.Right = new BinaryTreeNode<int>(10);

            return root;
        }

        // Test: Depth first search on Binary tree
        [Test]
        public void TestDepthFirstTraversal()
        {
            var root = CreateTree();
            var result = string.Join(',', root.DepthFirstEnumerator());
            ClassicAssert.AreEqual(result, "5,6,8,9,7,10");
        }

        // Test: Breadth first search on Binary tree
        [Test]
        public void TestBreadthFirstTraversal()
        {
            var root = CreateTree();
            var result = string.Join(',', root.BreadthFirstEnumerator());
            ClassicAssert.AreEqual(result, "5,6,7,8,9,10");
        }

        // Test: Depth first search on Binary tree
        [Test]
        public void TestDepthFirstTraversal_OnlyRoot()
        {
            var root = new BinaryTreeNode<int>(5);
            var result = string.Join(',', root.DepthFirstEnumerator());
            ClassicAssert.AreEqual(result, "5");
        }

        // Test: Breadth first search on Binary tree
        [Test]
        public void TestBreadthFirstTraversal_OnlyRoot()
        {
            var root = new BinaryTreeNode<int>(5);
            var result = string.Join(',', root.BreadthFirstEnumerator());
            ClassicAssert.AreEqual(result, "5");
        }
    }
}
