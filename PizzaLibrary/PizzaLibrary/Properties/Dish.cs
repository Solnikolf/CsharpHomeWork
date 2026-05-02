public abstract class Dish
{
    public string Name { get; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public Dish(string name, string description, decimal price)
    {
        Name = name;
        Description = description;
        Price = price;
    }

    public abstract string[] GetInfo(); 