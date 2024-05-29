namespace DesignPatterns.CreationalPatterns.FactoryMethodPattern;
public abstract class ProductFactory
{
    public abstract IProduct FactoryCreation(string name, string description, Brand brand, decimal price);
}

public class ElectronicsFactory : ProductFactory
{
    public override IProduct FactoryCreation(string name, string description, Brand brand, decimal price)
    {
        return new Electronics(name, description, brand, price);
    }
}

public class BookFactory : ProductFactory
{
    public override IProduct FactoryCreation(string name, string description, Brand brand, decimal price)
    {
        return new Book(name, description, brand, price);
    }
}

public class FoodFactory : ProductFactory
{
    public override IProduct FactoryCreation(string name, string description, Brand brand, decimal price)
    {
        return new Food(name, description, brand, price);
    }
}

public class DrinkFactory : ProductFactory
{
    public override IProduct FactoryCreation(string name, string description, Brand brand, decimal price)
    {
        return new Drink(name, description, brand, price);
    }
}
public class Electronics : IProduct
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Category Category { get; set; }
    public Brand Brand { get; set; }
    public decimal Price { get; set; }

    public Electronics(string name, string description, Brand brand, decimal price)
    {
        Name = name;
        Description = description;
        Category = Category.Electronics;
        Brand = brand;
        Price = price;
    }
}
public class Book : IProduct
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Category Category { get; set; }
    public Brand Brand { get; set; }
    public decimal Price { get; set; }
    public Book(string name, string description, Brand brand, decimal price)
    {
        Name = name;
        Description = description;
        Category = Category.Book;
        Brand = brand;
        Price = price;
    }
}
public class Food : IProduct
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Category Category { get; set; }
    public Brand Brand { get; set; }
    public decimal Price { get; set; }

    private Food() { }
    public Food(string name, string description, Brand brand, decimal price)
    {
        Name = name;
        Description = description;
        Category = Category.Food;
        Brand = brand;
        Price = price;
    }
}
public class Drink : IProduct
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Category Category { get; set; }
    public Brand Brand { get; set; }
    public decimal Price { get; set; }
    public Drink(string name, string description, Brand brand, decimal price)
    {
        Name = name;
        Description = description;
        Category = Category.Drink;
        Brand = brand;
        Price = price;
    }
}