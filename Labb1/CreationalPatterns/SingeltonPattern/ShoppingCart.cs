using DesignPatterns.CreationalPatterns.FactoryMethodPattern;

namespace DesignPatterns.CreationalPatterns.SingeltonPattern;
public class ShoppingCart
{
    private static ShoppingCart _instance;
    private static readonly object _lock = new();
    private List<IProduct> _products = [];
    private ShoppingCart() { }


    public static ShoppingCart GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new ShoppingCart();
                }
            }
        }

        return _instance;
    }

    public void AddProduct(IProduct product)
    {
        _products.Add(product);
        Console.Write("Added: ");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write($"{product.Name}");
        Console.ResetColor();
        Console.WriteLine(" to the shopping cart.");
    }

    public List<IProduct> GetProducts() => _products;

    public void ClearCart()
    {
        _products.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Shopping cart cleared.");
        Console.ResetColor();
    }

    public decimal GetTotalAmount()
    {
        decimal sum = _products.Sum(p => p.Price);
        return sum;
    }
}
