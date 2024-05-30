using Library.ShippingExample.ShippingProviders.Common;

namespace Library.ShippingExample
{
    public class ShippingCostCalculationService
    {
        private readonly IShippingProvider _shippingProvider;

        public ShippingCostCalculationService(IShippingProvider shippingCost)
        {
            _shippingProvider = shippingCost;
        }

        public decimal Calculate(Order order)
        {
            return _shippingProvider.CalculateCost(order);
        }
    }
}
