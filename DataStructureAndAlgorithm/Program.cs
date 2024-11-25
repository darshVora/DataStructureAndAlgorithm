using DataStructureAndAlgorithm.DataStructure;
using System;

namespace DataStructureAndAlgorithm
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IList<int> list = new DoublyLinkedList<int>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(i);
            }

            var randomIndex = 0;
            var value = Random.Shared.Next(int.MaxValue);
            list.Insert(randomIndex, value);
            list.RemoveAt(randomIndex);

            list.Insert(list.Count - 1, value);
            list.RemoveAt(list.Count - 1);
        }
    }
}