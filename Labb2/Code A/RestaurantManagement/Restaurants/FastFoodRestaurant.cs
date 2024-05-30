using RestaurantManagement.Meals;
using RestaurantManagement.Meals.Common;
using RestaurantManagement.Restaurants.Common;

namespace RestaurantManagement.Restaurants
{

    public class FastFoodRestaurant : Restaurant
    {
        public override IMeal PrepareMainCourse()
        {
            return new Hamburger();
        }
    }
}
