using System;

namespace PizzaLibrary
{

    
    public abstract class Dish
    {
        public string Name { get; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public Dish(string name, string description, decimal price)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Название не может быть пустым");
            if (price < 0)
                throw new ArgumentException("Цена не может быть отрицательной");

            Name = name;
            Description = description;
            Price = price;
        }

        public abstract string[] GetInfo();
    }

    
    public class Pizza : Dish
    {
        public int Diameter { get; set; }
        public PizzaType Type { get; set; }
        public string[] Ingredients { get; set; }

        public Pizza(string name, string description, int diameter,
                     PizzaType type, string[] ingredients, decimal price)
            : base(name, description, price)
        {
            if (diameter <= 0)
                throw new ArgumentException("Диаметр должен быть положительным");

            Diameter = diameter;
            Type = type;
            Ingredients = ingredients ?? Array.Empty<string>();
        }

        public override string[] GetInfo()
        {
            var info = new string[2];
            info[0] = $"{Name} ({Diameter} см)";

            string typeStr;
            if (Type == PizzaType.Thin) typeStr = "тонкая";
            else if (Type == PizzaType.Thick) typeStr = "толстая";
            else if (Type == PizzaType.Closed) typeStr = "закрытая";
            else typeStr = "неизвестно";

            string ingredientsStr = (Ingredients != null && Ingredients.Length > 0)
                ? string.Join(", ", Ingredients)
                : "нет";

            info[1] = $"Описание: {Description}. Тип: {typeStr}. Ингредиенты: {ingredientsStr}. Цена: {Price} руб.";
            return info;
        }
    } 

    
    public class Beverage : Dish
    {
        public bool IsHot { get; set; }
        public int VolumeMl { get; set; }

        public Beverage(string name, string description, decimal price, int volumeMl, bool isHot)
            : base(name, description, price)
        {
            VolumeMl = volumeMl;
            IsHot = isHot;
        }

        public override string[] GetInfo()
        {
            var info = new string[2];
            string type = IsHot ? "горячий" : "холодный";
            info[0] = $"{Name} ({type} напиток)";
            info[1] = $"Объем: {VolumeMl} мл. Описание: {Description}. Цена: {Price} руб.";
            return info;
        }
    } 

    
    public class Snack : Dish
    {
        public int WeightGrams { get; set; }

        public Snack(string name, string description, decimal price, int weightGrams)
            : base(name, description, price)
        {
            WeightGrams = weightGrams;
        }

        public override string[] GetInfo()
        {
            var info = new string[2];
            info[0] = $"{Name} (закуска)";
            info[1] = $"Вес: {WeightGrams} г. Описание: {Description}. Цена: {Price} руб.";
            return info;
        }
    } 

} 