using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Time
{
    internal abstract class AbstractRestaraunt
    {
        public abstract bool OrderTo(PizzaType menu, ref decimal money, Action<Func<AbstractPizza>> CallBackPizza);
    }
}
