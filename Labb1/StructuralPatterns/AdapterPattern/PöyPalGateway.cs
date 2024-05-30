namespace Labb1.StructuralPatterns.AdapterPattern;
public class PöyPalGateway
{
    public void MakePayment(decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount:C} through PöyPal.");
    }
}
