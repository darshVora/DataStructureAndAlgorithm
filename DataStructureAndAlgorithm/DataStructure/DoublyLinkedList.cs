using DataStructureAndAlgorithm.DataStructure.LinkedListModel;
using System.Collections;

namespace DataStructureAndAlgorithm.DataStructure
{
    /// <summary>
    /// Implementation of doubly linked list, Support all list operations
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DoublyLinkedList<T> : IList<T>
    {
        private DoublyLinkedListNode<T>? head;
        private int size;

        public T this[int index] { get => GetValue(index); set => Insert(index, value); }

        public int Count => size;

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            if (head == null)
            {
                head = new(item);
            }
            else
            {
                var lastNode = GetLastNode();
                lastNode.Next = new(item, lastNode);
            }

            size++;
        }

        private DoublyLinkedListNode<T>? GetLastNode()
        {
            var node = head;

            while (node?.Next != null)
            {
                node = node.Next;
            }

            return node;
        }

        public void Clear()
        {
            head = null;
            size = 0;
        }

        public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(head);
        }

        public int IndexOf(T item)
        {
            var equalityComparer = EqualityComparer<T>.Default;

            var node = head;
            int index = 0;

            while (node?.Next != null)
            {
                if (equalityComparer.Equals(node.Value, item))
                {
                    return index;
                }

                node = node.Next;
                index++;
            }

            return -1;
        }

        public T GetValue(int index)
        {
            var node = head;

            for (int i = 0; i < index; i++)
            {
                node = node.Next;
            }

            return node.Value;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > size)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                var newNode = new DoublyLinkedListNode<T>(item, null, head);
                head.Pervious = newNode;
                head = newNode;
            }
            else
            {
                var node = head;

                //Go to node before index
                for (int i = 0; i < index - 1; i++)
                {
                    node = node.Next;
                }

                //New node with previous -> node, next -> node.next 
                var newNode = new DoublyLinkedListNode<T>(item, node, node?.Next);
                node.Next = newNode;

                //For last element node.Next will be null
                if (newNode?.Next != null)
                {
                    //new node's next node's previous should have reference to new node
                    newNode.Next.Pervious = newNode;
                }
            }

            size++;
        }

        public bool Remove(T item)
        {
            var equalityComparer = EqualityComparer<T>.Default;

            var node = head;

            while (node != null)
            {
                if (equalityComparer.Equals(node.Value, item))
                {
                    //For first element node.Previous will be null
                    if (node.Pervious != null)
                    {
                        node.Pervious.Next = node.Next;
                    }
                    else
                    {
                        //Change head reference to node -> next when head element is removed
                        head = node.Next;
                    }

                    //For last element node.next will be null
                    if (node.Next != null)
                    {
                        node.Next.Pervious = node.Pervious;
                    }

                    size--;
                    return true;
                }

                node = node.Next;
            }

            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException();
            }

            if (index == 0)
            {
                var newHead = head.Next;
                head.Next = null;
                head = newHead;
            }
            else
            {
                var node = head;

                for (int i = 0; i < index; i++)
                {
                    node = node.Next;
                }

                node.Pervious.Next = node.Next;

                //For last element node.Next will be null

                if (node.Next != null)
                {
                    node.Next.Pervious ??= node.Pervious;
                }
            }

            size--;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        internal class Enumerator<T>(DoublyLinkedListNode<T>? head) : IEnumerator<T>
        {
            private DoublyLinkedListNode<T>? head = head;
            private DoublyLinkedListNode<T>? node = head;
            public T Current => node.Value;

            object IEnumerator.Current => node.Value;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (node?.Next == null)
                {
                    return false;
                }

                //Move to next node
                node = node.Next;

                return true;
            }

            public void Reset()
            {
                //Reset node to head
                node = head;
            }
        }
    }
}
