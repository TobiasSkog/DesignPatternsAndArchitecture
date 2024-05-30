namespace Labb1.StructuralPatterns.AdapterPattern;
public class PöyPalPaymentAdapter(PöyPalGateway pöyPalGateway) : IPaymentProcessor
{
    private readonly PöyPalGateway _pöyPalGateway = pöyPalGateway;

    public void ProcessPayment(decimal amount)
    {
        _pöyPalGateway.MakePayment(amount);
    }
}
