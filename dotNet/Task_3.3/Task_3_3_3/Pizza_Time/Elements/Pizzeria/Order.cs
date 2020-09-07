using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Time
{
    internal struct Order<T, U>
    {
        public T Menu;
        public U CallBackPizza;

        public Order(T menu, U callBackPizza)
        {
            Menu = menu;
            CallBackPizza = callBackPizza;
        }
    }
}
