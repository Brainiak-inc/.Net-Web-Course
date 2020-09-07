using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Time
{
    internal class Pizzeria : AbstractRestaraunt
    {
        protected decimal Money;
        protected Queue<Order<PizzaType, Action<Func<AbstractPizza>>>> Order;
        protected event Action<Func<AbstractPizza>> EventOrderCompleted;
        protected List<AbstractWorker> Worker;

        public Pizzeria(decimal money)
        {
            Money = money;

            Order = new Queue<Order<PizzaType, Action<Func<AbstractPizza>>>>();
            EventOrderCompleted = new Action<Func<AbstractPizza>>((d) => { });
            Worker = new List<AbstractWorker>() { new Cashier(Order), new Cooker(Order), new Cooker(Order) };
        }

        public override bool OrderTo(PizzaType menu, ref decimal money, Action<Func<AbstractPizza>> CallBackPizza)
        {
            AbstractCashier cashier = null;

            foreach (var item in Worker)
            {
                if (item is AbstractCashier)
                {
                    cashier = (AbstractCashier)item;
                }
            }

            if (cashier != null)
            {
                return cashier.TakeOrder(menu, ref money, ref Money, CallBackPizza);
            }

            return false;
        }
    }
}
