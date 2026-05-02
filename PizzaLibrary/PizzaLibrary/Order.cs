using System;
using System.Collections;
using System.Collections.Generic;

namespace PizzaLibrary
{
    public class Order : IEnumerable<Pizza>
    {
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        
        private List<Pizza> _pizzas;

        public Order(string customerName, string address, string phone)
        {
            CustomerName = customerName;
            Address = address;
            Phone = phone;
            _pizzas = new List<Pizza>();
        }

        
        public void AddPizza(Pizza pizza) => _pizzas.Add(pizza);
        public void RemovePizza(Pizza pizza) => _pizzas.Remove(pizza);

        
        public IEnumerator<Pizza> GetEnumerator() => _pizzas.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}