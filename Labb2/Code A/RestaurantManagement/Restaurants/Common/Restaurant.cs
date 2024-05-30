using System;
using RestaurantManagement.Meals.Common;

namespace RestaurantManagement.Restaurants.Common
{
    public abstract class Restaurant
    {

        public abstract IMeal PrepareMainCourse();

        public void OrderDailySpecial()
        {
            Console.WriteLine("Drink: sparkling water");

            var mainCourse = PrepareMainCourse();
            mainCourse.ShowDescription();
        }
    }
}
