using NUnit.Framework;

namespace PizzaLibrary.UnitTests
{
    [TestFixture]
    public class PizzaUnitTests
    {
        [Test]
        public void ConstructorTest()
        {
            var pizza = CreateTestPizza();

            Assert.That(pizza.Name, Is.EqualTo("Пепперони"));
            Assert.That(pizza.Diameter, Is.EqualTo(30));
            Assert.That(pizza.Price, Is.EqualTo(500));
        }

        [Test]
        public void GetInfoTest()
        {
            var pizza = CreateTestPizza();

            var info = pizza.GetInfo();

            Assert.That(info.Length, Is.EqualTo(2));
            Assert.That(info[0], Is.EqualTo("Пепперони (30 см)"));
        }

        private Pizza CreateTestPizza()
        {
            return new Pizza(
                "Пепперони",
                "Острая",
                30,
                PizzaType.Thin,
                new string[] { "колбаса", "сыр" },
                500
            );
        }
    }
}