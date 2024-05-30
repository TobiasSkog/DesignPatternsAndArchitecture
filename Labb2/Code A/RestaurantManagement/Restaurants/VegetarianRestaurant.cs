using RestaurantManagement.Meals;
using RestaurantManagement.Meals.Common;
using RestaurantManagement.Restaurants.Common;

namespace RestaurantManagement.Restaurants
{

    public class VegetarianRestaurant : Restaurant
    {
        public override IMeal PrepareMainCourse()
        {
            return new GreenSalad();
        }
    }
}
