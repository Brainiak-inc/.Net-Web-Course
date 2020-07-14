using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pizza_Time
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizzeria pizzeria = new Pizzeria(1000);

            List<Customer> customers = new List<Customer>()
            {
                new Customer("Vikentii", 600)
            };

            Console.WriteLine($"Customer: {customers[0].Name} made an order");

            customers[0].OrderPizza(pizzeria, PizzaType.ItalianPizza);

            Console.WriteLine($"Customer: {customers[0].Name} got product " + CheckOrder(customers[0]).Product.ToString());
            
            Console.ReadKey();
        }
        static Customer CheckOrder(Customer customer)
        {
            while (customer.Product == null)
            {
                Thread.Sleep(1000);
            }
            return customer;
        }
    }
}
