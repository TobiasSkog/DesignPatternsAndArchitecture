using System.Reflection;
using DesignPatternsLibrary.PatternExecutors;
using RestaurantManagement.Restaurants;
using RestaurantManagement.Restaurants.Common;

namespace RestaurantManagement
{
    public class Executor : PatternExecutor
    {
        public override string Name => "???";

        public override void Execute()
        {
            Restaurant restaurant = InitializeRestaurant();

            restaurant.OrderDailySpecial();
        }

        private Restaurant InitializeRestaurant()
        {
            var choosenType = typeof(FastFoodRestaurant).FullName;

            return Assembly.GetExecutingAssembly().CreateInstance(choosenType) as Restaurant;
        }
    }
}
