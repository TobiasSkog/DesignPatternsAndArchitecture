using Library.ShippingExample.ShippingProviders.Common;

namespace Library.ShippingExample.ShippingProviders
{
    public class UnitedParcelService : IShippingProvider
    {
        public decimal CalculateCost(Order order)
        {
            return 9;
        }
    }
}
