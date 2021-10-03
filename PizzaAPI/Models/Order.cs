using System;
using System.Collections.Generic;

namespace PIZZAAPI
{
    public class Order
    {
        public string CustomerName { get; set; }
        public List<Pizza> Pizzas { get; set; }

        public Order(string customerName, List<Pizza> pizzas)
        {
            this.CustomerName = customerName;
            this.Pizzas = pizzas;
        }
    }
}