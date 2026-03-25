using System;

namespace PizzaLibrary
{
    public class Pizza
    {
        public readonly string Name;

        public string Description { get; set; }
        public int Diameter { get; set; }
        public PizzaType Type { get; set; }
        public string[] Ingredients { get; set; }
        public decimal Price { get; set; }

        public Pizza(string name, string description, int diameter,
                     PizzaType type, string[] ingredients, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название не может быть пустым");

            if (diameter <= 0)
                throw new ArgumentException("Диаметр должен быть положительным");

            if (price < 0)
                throw new ArgumentException("Цена не может быть отрицательной");

            Name = name;
            Description = description;
            Diameter = diameter;
            Type = type;
            Ingredients = ingredients ?? Array.Empty<string>();
            Price = price;
        }

        public string[] GetInfo()
        {
            var info = new string[2];

            info[0] = $"{Name} ({Diameter} см)";

            string typeStr;

            if (Type == PizzaType.Thin)
                typeStr = "тонкая";
            else if (Type == PizzaType.Thick)
                typeStr = "толстая";
            else if (Type == PizzaType.Closed)
                typeStr = "закрытая";
            else
                typeStr = "неизвестно";

            string ingredientsStr = Ingredients.Length > 0
                ? string.Join(", ", Ingredients)
                : "нет";

            info[1] = $"Описание: {Description}. Тип: {typeStr}. " +
                      $"Ингредиенты: {ingredientsStr}. Цена: {Price} руб.";

            return info;
        }
    }
}