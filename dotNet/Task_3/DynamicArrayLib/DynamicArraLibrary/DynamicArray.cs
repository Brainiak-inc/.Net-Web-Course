using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArraLibrary
{
    public class DynamicArray<T> : ICollection<T>, IEnumerator<T>, ICloneable
    {
        protected T[] Array;

        public DynamicArray()
        {
            Capacity = 8;
        }
        public DynamicArray(int capacity)
        {
            Capacity = capacity;
        }
        public DynamicArray(IEnumerable<T> array) : this()
        {
            foreach (var item in array)
            {
                Add(item);
            }
        }
        public T this[int index]
        {
            get
            {
                if (index > Count * (-1) && index < Count)
                {
                    if (index >= 0)
                    {
                        return Array[index];
                    }
                    else
                    {
                        return Array[Count - 1 + index];
                    }

                }
                throw new ArgumentOutOfRangeException("Cannot go out of the array range!");
            }
            set
            {
                if (index > Count * (-1) && index < Count)
                {
                    if (index >= 0)
                    {
                        Array[index] = value;
                    }
                    else
                    {
                        Array[Count - 1 + index] = value;
                    }
                    return;
                }
                throw new ArgumentOutOfRangeException("Cannot go out of the array range!");
            }
        }

        public int Count { get; private set; }

        public int Capacity
        {
            get
            {
                return Array.Length;
            }
            set
            {
                if (Array == null)
                {
                    Array = new T[value];
                }
                else if (Count <= value)
                {
                    T[] tempArray = Array;
                    Array = new T[value];

                    tempArray.CopyTo(Array, 0);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Cannot go out of the array range!");
                }
            }
        }
        public void Add(T item)
        {
            if (Count == Capacity)
            {
                Capacity *= 2;
            }
            Array[Count] = item;

            Count++;
        }
        public void Clear()
        {
            Array = new T[0];
        }
        public bool Contains(T item)
        {
            foreach (var value in this)
            {
                if (value.Equals(item))
                {
                    return true;
                }
            }
            return false;
        }
        public void CopyTo(T[] array, int indexArray)
        {
            if (indexArray < 0 || indexArray >= array.Length)
            {
                throw new ArgumentOutOfRangeException("indexArray out of array range!");
            }
            if (array.Length - indexArray < Count)
            {
                throw new ArgumentOutOfRangeException("Insufficient array size!");
            }
            for (int i = 0; i < Count; i++)
            {
                array[indexArray + 1] = Array[i];
            }
        }
        public int IndexOf(T item)
        {
            for (int i = 0; i < Count; i++)
            {
                if (Array[i].Equals(item))
                {
                    return 1;
                }
            }
            return -1;
        }
        public bool Insert(int index, T item)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException("indexArray out of array range!");
            }
            Array[index] = item;

            return true;
        }
        public bool Remove(T item)
        {
            int temp = IndexOf(item);

            if (temp == -1)
            {
                return false;
            }
            RemoveAt(temp);

            return true;
        }
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException("indexArray out of array range!");
            }
            for (int i = index; i < Count; i++)
            {
                if (!(i + 1 == Count))
                {
                    Array[i] = Array[i + 1];
                }
            }
            Count--;
        }
        public T[] ToArray()
        {
            T[] temp = new T[Count];

            for (int i = 0; i < Count; i++)
            {
                temp[i] = Array[i];
            }
            return temp;
        }
        public object Clone()
        {
            DynamicArray<T> temp = new DynamicArray<T>(ToArray());

            for (int i = temp.Count - 1; i > Count - 1; i++)
            {
                temp.RemoveAt(i);
            }
            return temp;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this;
        }
        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public bool IsReadOnly => false;

        protected int Index = -1;
        public T Current => Array[Index];
        object IEnumerator.Current => Current;

        public virtual bool MoveNext()
        {
            if (Count - 1 > Index)
            {
                Index++;

                return true;
            }
            else
            {
                return false;
            }
        }
        public virtual void Reset()
        {
            Index = -1;
        }
        public override bool Equals(object obj)
        {
            DynamicArray<T> temp = obj as DynamicArray<T>;

            if (temp != null)
            {
                if (Capacity == temp.Capacity && Count == temp.Count)
                {
                    for (int i = 0; i < Count; i++)
                    {
                        if (!Array[i].Equals(temp[i]))
                        {
                            return false;
                        }

                    }
                    return true;
                }

            }
            return false;
        }
        public override int GetHashCode()
        {
            return Array.GetHashCode();
        }
        public void AddRange(IEnumerable<T> collection)
        {
            int collectionLength = 0;

            foreach (var item in collection)
            {
                collectionLength++;
            }
            if (Count + collectionLength > Capacity)
            {
                int newCapacity = Capacity;

                while (Count + collectionLength > newCapacity)
                {
                    newCapacity += 2;
                }
                Capacity = newCapacity;
            }
            foreach (var item in collection)
            {
                Add(item);
            }
        }
    }
}
