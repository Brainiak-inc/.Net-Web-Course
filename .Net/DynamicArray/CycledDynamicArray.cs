using DynamicArraLibrary;
using System.Collections.Generic;

namespace CycledDynamicArray
{
    class CycledDynamicArray<T> : DynamicArray<T>
    {
        public CycledDynamicArray(int capacity) : base(capacity)
        {

        }
        public CycledDynamicArray(IEnumerable<T> array) : base(array)
        {

        }

        public override bool MoveNext()
        {
            if (Count - 1 > Index)
            {
                Index++;
            }
            else
            {
                Index = 0;
            }
            return true;
        }
    }
}
