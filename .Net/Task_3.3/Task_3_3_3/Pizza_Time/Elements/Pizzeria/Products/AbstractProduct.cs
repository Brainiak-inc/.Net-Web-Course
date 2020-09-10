using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Time
{
     class AbstractProduct
    {
        public override string ToString()
        {
            return GetType().Name;
        }
    }
}
