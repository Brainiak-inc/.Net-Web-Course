using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Time
{
    internal abstract class AbstractCashier : AbstractWorker
    {

        public abstract bool TakeOrder(PizzaType menu, ref decimal money1, ref decimal money2, Action<Func<AbstractPizza>> callBackPizza);
      
    }
}
