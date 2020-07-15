using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Time
{
    internal class Customer
    {
        public string Name { get; }
        protected decimal Money;
        public AbstractProduct Product { get; protected set; }

        public Customer(string name, decimal money)
        {
            Name = name;
            Money = money;
        }

        public bool OrderPizza(Pizzeria pizzeria, PizzaType pizza)
        {
            return pizzeria.OrderTo(pizza, ref Money, GetPizza);
        }
        protected void GetPizza(Func<AbstractPizza> CallBack)
        {
            Product = CallBack();
        }
    }
}
