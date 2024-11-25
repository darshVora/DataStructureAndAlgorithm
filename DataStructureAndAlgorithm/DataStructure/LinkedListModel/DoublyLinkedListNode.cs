using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.DataStructure.LinkedListModel
{
    public class DoublyLinkedListNode<T>(T value, DoublyLinkedListNode<T>? previous = default, DoublyLinkedListNode<T>? next = default)
    {
        public DoublyLinkedListNode<T>? Pervious { get; set; } = previous;
        public T Value { get; set; } = value;
        public DoublyLinkedListNode<T>? Next { get; set; } = next;
    }
}
