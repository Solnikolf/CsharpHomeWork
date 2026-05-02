using NUnit.Framework;
using PizzaLibrary;
using System.Collections.Generic;
using System.Linq;

namespace PizzaLibrary.UnitTests
{
    [TestFixture]
    public class PizzaInterfacesTests
    {
        [Test]
        public void PizzaSorting_ByNameThenByDiameter_Test()
        {
            
            var p1 = new Pizza("Margarita", "Standard", 30, PizzaType.Thin, null, 500);
            var p2 = new Pizza("Margarita", "Small", 25, PizzaType.Thin, null, 400);
            var p3 = new Pizza("BBQ", "Meat", 30, PizzaType.Thin, null, 600);

            var list = new List<Pizza> { p1, p2, p3 };

            
            list.Sort();

            
            Assert.That(list[0].Name, Is.EqualTo("BBQ"));

            
            Assert.That(list[1].Name, Is.EqualTo("Margarita"));
            Assert.That(list[1].Diameter, Is.EqualTo(25));

            
            Assert.That(list[2].Diameter, Is.EqualTo(30));
        }

        [Test]
        public void Order_IEnumerable_Foreach_Test()
        {
            
            var order = new Order("Ivan", "Main St", "555-0100");
            var pizza = new Pizza("Pepperoni", "Hot", 30, PizzaType.Thin, null, 500);
            order.AddPizza(pizza);

            
            int count = 0;
            foreach (var p in order)
            {
                Assert.That(p.Name, Is.EqualTo("Pepperoni"));
                count++;
            }

            
            Assert.That(count, Is.EqualTo(1));
        }

        [Test]
        public void Order_AddRemove_Test()
        {
            var order = new Order("Ivan", "Main St", "555-0100");
            var pizza = new Pizza("Pepperoni", "Hot", 30, PizzaType.Thin, null, 500);

            order.AddPizza(pizza);
            Assert.That(order.Count(), Is.EqualTo(1)); // Используем LINQ .Count()

            order.RemovePizza(pizza);
            Assert.That(order.Count(), Is.EqualTo(0));
        }
    }
}