using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.DataStructure
{
    /// <summary>
    /// Implementation of Dynamic Array, Supports all list operations.
    /// </summary>
    /// <typeparam name="T">Type of Value in List</typeparam>
    public class List<T> : IList<T>
    {
        private const int defaultCapacity = 4;
        private int resizeMultiplier = 2;
        private int size;
        private int version;

        //Array for storing items in list
        private T[] items;

        static readonly T[] _emptyArray = Array.Empty<T>();

        //Resize capacity count
        Func<int, int> resizeCapacityCount;

        //Default logic of resize capacity count
        Func<int, int> defaultResizeCapacityCount => (currentCapacity) =>
        {
            if (currentCapacity == 0)
            {
                return defaultCapacity;
            }

            return currentCapacity * resizeMultiplier;
        };

        public List()
        {
            items = _emptyArray;
            resizeCapacityCount = defaultResizeCapacityCount;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="capacity">Capacity of list</param>
        /// <param name="resizeCapacityCount">Delegate must return resized capacity count based on current capacity count</param>
        public List(int capacity, Func<int, int> resizeCapacityCount = null)
        {
            if (resizeCapacityCount == null)
            {
                resizeCapacityCount = defaultResizeCapacityCount;
            }

            this.resizeCapacityCount = resizeCapacityCount;

            //Initialize to empty array if capacity is less than equals to 0
            if (capacity <= 0)
            {
                items = _emptyArray;
            }
            else
            {
                items = new T[capacity];
            }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= size)
                {
                    throw new IndexOutOfRangeException();
                }

                return items[index];
            }
            set
            {
                if (index < 0 || index >= size)
                {
                    throw new IndexOutOfRangeException();
                }

                items[index] = value;
            }
        }

        public bool IsFixedSize => false;

        public bool IsReadOnly => false;

        public int Count => size;

        public bool IsSynchronized => false;

        public int IndexOf(T item)
        {
            var equalityComparer = EqualityComparer<T>.Default;

            for (int i = 0; i < size; i++)
            {
                if (equalityComparer.Equals(item, items[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Ensures capacity in items array
        /// </summary>
        public void EnsureCapacity()
        {
            if (size >= items.Length)
            {
                var capacity = resizeCapacityCount(items.Length);
                var newArray = new T[capacity];
                Array.Copy(items, newArray, items.Length);
                items = newArray;
            }
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > size)
            {
                throw new IndexOutOfRangeException();
            }

            EnsureCapacity();

            //Increase size by 1 then shift element by 1
            for (int i = ++size; index <= i; i--)
            {
                items[i] = items[i - 1];
            }

            //Put item into index
            items[index] = item;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = index; i < size; i++)
            {
                items[i] = items[i + 1];
            }

            size--;
        }

        public void Add(T item)
        {
            EnsureCapacity();
            items[size++] = item;
        }

        public void Clear()
        {
            if (size > 0)
            {
                Array.Clear(items, 0, size);
            }
        }

        public bool Contains(T item)
        {
            return IndexOf(item) >= 0;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            var indexOfItem = IndexOf(item);

            if (indexOfItem >= 0)
            {
                RemoveAt(indexOfItem);
                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
