using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Time
{
    internal abstract class AbstracktCooker : AbstractWorker
    {
        public event Action<Func<AbstractPizza>> EventOrderCompleted = new Action<Func<AbstractPizza>>((i) => { });

        protected void CompleteOrder(Func<AbstractPizza> CallBackPizza)
        {
            EventOrderCompleted.Invoke(CallBackPizza);
        }
    }
}
