using Library.ShippingExample.ShippingProviders.Common;

namespace Library.ShippingExample.ShippingProviders
{
    public class RoyalMail : IShippingProvider
    {
        public decimal CalculateCost(Order order)
        {
            return 8.5m;
        }
    }
}
