using NUnit.Framework;
using NUnit.Framework.Legacy;
using DataStructureAndAlgorithm.DataStructure;

namespace DataStructureAndAlgorithm.Test
{
    [TestFixture]
    public class ListTest
    {
        private IList<int> _testList;

        // SetUp method to initialize the test environment
        [SetUp]
        public void Setup()
        {
            _testList = new DataStructure.List<int>();
        }

        // Test: Add method - Add a single item to the list
        [Test]
        public void TestAddItem()
        {
            _testList.Add(5);
            ClassicAssert.AreEqual(1, _testList.Count, "Item should be added to the list.");
            ClassicAssert.AreEqual(5, _testList[0], "The item in the list should be 5.");
        }

        // Test: Remove method - Remove an item from the list
        [Test]
        public void TestRemoveItem()
        {
            _testList.Add(10);
            _testList.Add(20);
            _testList.Remove(10); //Remove first item
            ClassicAssert.AreEqual(1, _testList.Count, "Item should be removed from the list.");
            ClassicAssert.AreEqual(20, _testList[0], "The only item left in the list should be 20.");
            _testList.Add(30);
            _testList.Add(40);
            _testList.Remove(40); //Remove last item
            ClassicAssert.AreEqual(2, _testList.Count, "Item should be removed from the list.");
            ClassicAssert.AreEqual(30, _testList[_testList.Count - 1], "The last item in the list should be 30.");
            _testList.Insert(0, 10);
            _testList.Remove(20); //Remove middle item
            ClassicAssert.AreEqual(2, _testList.Count, "Item should be removed from the list.");
            ClassicAssert.AreEqual(30, _testList[1], "The last item in the list should be 30.");
        }

        // Test: Contains method - Check if an item exists in the list
        [Test]
        public void TestContainsItem()
        {
            _testList.Add(30);
            _testList.Add(40);
            bool contains30 = _testList.Contains(30);
            bool contains50 = _testList.Contains(50);
            ClassicAssert.IsTrue(contains30, "List should contain 30.");
            ClassicAssert.IsFalse(contains50, "List should not contain 50.");
        }

        // Test: IndexOf method - Find the index of an item
        [Test]
        public void TestIndexOfItem()
        {
            _testList.Add(100);
            _testList.Add(200);
            _testList.Add(300);
            int index = _testList.IndexOf(200);
            ClassicAssert.AreEqual(1, index, "Index of 200 should be 1.");
        }

        // Test: Clear method - Clear all items from the list
        [Test]
        public void TestClearList()
        {
            _testList.Add(1);
            _testList.Add(2);
            _testList.Clear();
            ClassicAssert.AreEqual(0, _testList.Count, "List should be empty after clear.");
        }

        // Test: Count property - Get the number of items in the list
        [Test]
        public void TestCountProperty()
        {
            ClassicAssert.AreEqual(0, _testList.Count, "List should initially be empty.");
            _testList.Add(1);
            ClassicAssert.AreEqual(1, _testList.Count, "List should have 1 item.");
            _testList.Add(2);
            ClassicAssert.AreEqual(2, _testList.Count, "List should have 2 items.");
            _testList.Insert(2, 3);
            ClassicAssert.AreEqual(3, _testList.Count, "List should have 3 items.");
            _testList.RemoveAt(2);
            ClassicAssert.AreEqual(2, _testList.Count, "List should have 2 items.");
            _testList.Remove(2);
            ClassicAssert.AreEqual(1, _testList.Count, "List should have 1 items.");
        }

        // Test: Insert method - Insert an item at a specific index
        [Test]
        public void TestInsertItem()
        {
            _testList.Add(5);
            _testList.Insert(0, 10); // Insert 10 at index 0
            _testList.Insert(_testList.Count, 20); // Insert 20 at Last index
            ClassicAssert.AreEqual(20, _testList[2], "Last item should be 20.");
            ClassicAssert.AreEqual(10, _testList[0], "First item should be 10.");
            ClassicAssert.AreEqual(5, _testList[1], "Second item should be 5.");
        }

        // Test: RemoveAt method - Remove an item at a specific index
        [Test]
        public void TestRemoveAtItem()
        {
            _testList.Add(5);
            _testList.Add(10);
            _testList.Add(20);
            _testList.Add(30);
            _testList.Add(40);
            _testList.RemoveAt(_testList.Count - 1); // Remove item at last index
            ClassicAssert.AreEqual(30, _testList[_testList.Count - 1], "Last item should be 30.");
            _testList.RemoveAt(2); // Remove item at middle list
            ClassicAssert.AreEqual(30, _testList[2], "At index 2 item should be 30.");
            _testList.RemoveAt(0); //Remove item at first index3
            ClassicAssert.AreEqual(10, _testList[0], "First item should be 10.");
        }
    }
}
