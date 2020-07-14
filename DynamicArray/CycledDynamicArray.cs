using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicArraLibrary;

namespace DynamicArray
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
