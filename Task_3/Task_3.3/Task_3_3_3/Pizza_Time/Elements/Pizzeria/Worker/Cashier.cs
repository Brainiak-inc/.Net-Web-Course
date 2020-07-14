using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza_Time
{
    internal class Cashier : AbstractCashier
    {
        protected readonly Queue<Order<PizzaType, Action<Func<AbstractPizza>>>> Order;
        
        public Cashier(Queue<Order<PizzaType, Action<Func<AbstractPizza>>>> order)
        {
            Order = order;
        } 
        public override bool TakeOrder(PizzaType menu, ref decimal customerMoney, ref decimal companyMoney, Action<Func<AbstractPizza>> CallBackPizza)
        {
            if (menu == PizzaType.None || CheckMoney(menu, ref customerMoney, ref companyMoney) == -1)
            {
                return false;
            }
            Order.Enqueue(new Order<PizzaType, Action<Func<AbstractPizza>>>(menu, CallBackPizza));

            return true;
        }
        private int CheckMoney(PizzaType menu, ref decimal customerMoney, ref decimal companyMoney)
        {
            if (((int)menu) <= customerMoney)
            {
                customerMoney -= (int)menu;
                companyMoney += (int)menu;

                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}
