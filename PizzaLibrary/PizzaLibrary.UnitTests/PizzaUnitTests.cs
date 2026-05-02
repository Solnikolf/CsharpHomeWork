using NUnit.Framework;
using PizzaLibrary;
using System;

namespace PizzaLibrary.UnitTests
{
    [TestFixture]
    public class PizzaUnitTests
    {
        
        [Test]
        public void Pizza_ConstructorAndInfo_Test()
        {
            var pizza = CreateTestPizza();

            Assert.That(pizza.Name, Is.EqualTo("Пепперони"));
            Assert.That(pizza.Diameter, Is.EqualTo(30));
            Assert.That(pizza.Price, Is.EqualTo(500));

            var info = pizza.GetInfo();
            Assert.That(info[0], Is.EqualTo("Пепперони (30 см)"));
        }

        
        [Test]
        public void Beverage_GetInfo_HotDrink_ReturnsCorrectString()
        {
            // Создаем горячий чай
            var coffee = new Beverage("Кофе", "Арабика", 150m, 200, true);

            var info = coffee.GetInfo();

            Assert.That(info[0], Is.EqualTo("Кофе (горячий напиток)"));
            Assert.That(info[1], Does.Contain("200 мл"));
            Assert.That(info[1], Does.Contain("150"));
        }

        
        [Test]
        public void Snack_GetInfo_ReturnsWeight()
        {
            
            var fries = new Snack("Картофель фри", "Соленый", 120m, 150);

            var info = fries.GetInfo();

            Assert.That(info[0], Is.EqualTo("Картофель фри (закуска)"));
            Assert.That(info[1], Does.Contain("150 г"));
        }

        // 
        [Test]
        public void Dish_EmptyName_ThrowsArgumentException()
        {
            
            Assert.Throws<ArgumentException>(() =>
                new Pizza("", "Описание", 30, PizzaType.Thin, null, 100m));
        }

        
        private Pizza CreateTestPizza()
        {
            return new Pizza(
                "Пепперони",
                "Острая",
                30,
                PizzaType.Thin,
                new string[] { "колбаса", "сыр" },
                500m
            );
        }
    }
}