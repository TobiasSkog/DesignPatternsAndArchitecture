using RestaurantManagement.Meals.Common;
using System;

namespace RestaurantManagement.Meals
{

    public class Hamburger : IMeal
    {
        public void ShowDescription()
        {
            Console.WriteLine("Hamburger - with beef meat, Worcestershire sauce and cheese.");
        }
    }
}
