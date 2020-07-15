using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pizza_Time
{
    class Cooker : AbstracktCooker
    {
        protected static object CloseOrder = new object();

        protected readonly Queue<Order<PizzaType, Action<Func<AbstractPizza>>>> Order;

        public Cooker(Queue<Order<PizzaType, Action<Func<AbstractPizza>>>> order)
        {
            Order = order;

            new Thread(MonitorOrder).Start();
        }

        protected void MonitorOrder()
        {
            Order<PizzaType, Action<Func<AbstractPizza>>> order;

            while (true)
            {
                lock (CloseOrder)
                {
                    if (Order.Count > 0)
                    {
                        order = Order.Dequeue();

                        EventOrderCompleted += order.CallBackPizza;


                        CompleteOrder(() => FactoryPizza(order.Menu));
                    }

                }
            }
        }

        protected AbstractPizza FactoryPizza(PizzaType menu)
        {
            switch (menu)
            {
                case PizzaType.CheezePizza: return new CheezePizza();
                case PizzaType.ItalianPizza: return new ItalianPizza();
                case PizzaType.MexicanPizza: return new MexicanPizza();
                case PizzaType.PepperoniPizza: return new PepperoniPizza();
                default: return null;
            }
        }
    }
}
