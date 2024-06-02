using System.Text;

namespace VarmDrinkStation;

public interface IWarmDrink
{
    void Consume();
}
internal class Water : IWarmDrink
{
    public void Consume()
    {
        Console.WriteLine("Warm water is served.");
    }
}
internal class Coffee : IWarmDrink
{
    public void Consume()
    {
        Console.WriteLine("Warm coffee is served.");
    }
}
internal class Cappuccino : IWarmDrink
{
    public void Consume()
    {
        Console.WriteLine("Warm cappuccino is served.");
    }
}
internal class Chocolate : IWarmDrink
{
    public void Consume()
    {
        Console.WriteLine("Warm chocolate is served.");
    }
}
public interface IWarmDrinkFactory
{
    IWarmDrink Prepare(int total);
}
internal class HotWaterFactory : IWarmDrinkFactory
{
    public IWarmDrink Prepare(int total)
    {
        Console.WriteLine($"Pour {total} ml hot water in your cup");
        return new Water();
    }
}
internal class HotCoffeeFactory : IWarmDrinkFactory
{
    public IWarmDrink Prepare(int total)
    {
        Console.WriteLine($"Pour {total} ml hot coffee in your cup");
        return new Coffee();
    }
}
internal class HotCappuccinoFactory : IWarmDrinkFactory
{
    public IWarmDrink Prepare(int total)
    {
        Console.WriteLine($"Pour {total} ml hot cappuccino in your cup");
        return new Cappuccino();
    }
}
internal class HotChocolateFactory : IWarmDrinkFactory
{
    public IWarmDrink Prepare(int total)
    {
        Console.WriteLine($"Pour {total} ml hot chocolate in your cup");
        return new Chocolate();
    }
}
public class WarmDrinkMachine
{
    private readonly List<Tuple<string, IWarmDrinkFactory>> namedFactories = [];

    public WarmDrinkMachine()
    {
        foreach (var t in typeof(WarmDrinkMachine).Assembly.GetTypes())
        {
            if (typeof(IWarmDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
            {
                namedFactories.Add(Tuple.Create(
                  t.Name.Replace("Factory", string.Empty),
                  (IWarmDrinkFactory)Activator.CreateInstance(t)!));
            }
        }
    }
    public IWarmDrink MakeDrink()
    {
        PrintMenu();
        return GetUserChoiceOfDrink();
    }
    private IWarmDrink GetUserChoiceOfDrink()
    {
        while (true)
        {
            Console.Write("Select a number to continue: ");
            string s;
            if ((s = Console.ReadLine()!) != null
                && int.TryParse(s, out int i) // c# 7
                && i >= 0
                && i < namedFactories.Count)
            {
                Console.Write("How much: ");
                s = Console.ReadLine()!;
                if (s != null
                    && int.TryParse(s, out int total)
                    && total > 0)
                {
                    return namedFactories[i].Item2.Prepare(total);
                }
            }
            Console.WriteLine("Something went wrong with your input.");
            Console.WriteLine("Press any key to try again...");
            Console.ReadKey();
            Console.Clear();
        }
    }

    private void PrintMenu()
    {
        Console.WriteLine("This is what we serve today:");
        for (var index = 0; index < namedFactories.Count; index++)
        {
            var tuple = namedFactories[index];

            // Quick fix to split the words up to multiple
            // words when using pascal casing to make the
            // print look a bit better and be easier to read
            var charArray = tuple.Item1.ToCharArray();
            StringBuilder sb = new();
            for (int i = 0; i < charArray.Length; i++)
            {
                if (char.IsUpper(charArray[i]) && i != 0)
                {
                    sb.Append(' ');
                }

                sb.Append(charArray[i]);
            }
            string formattedName = sb.ToString();
            Console.WriteLine($"{index}: {formattedName}");
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        var machine = new WarmDrinkMachine();
        IWarmDrink drink = machine.MakeDrink();
        drink.Consume();
    }
}
