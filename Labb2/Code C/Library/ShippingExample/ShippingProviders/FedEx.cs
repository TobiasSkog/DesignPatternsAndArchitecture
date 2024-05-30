using Library.ShippingExample.ShippingProviders.Common;

namespace Library.ShippingExample.ShippingProviders
{
    public class FedEx : IShippingProvider
    {
        public decimal CalculateCost(Order order)
        {
            return 10;
        }
    }
}
