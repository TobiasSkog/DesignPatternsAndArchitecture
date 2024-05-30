using System;
using RestaurantManagement.Meals.Common;

namespace RestaurantManagement.Meals
{

    public class GreenSalad : IMeal
    {
        public void ShowDescription()
        {
            Console.WriteLine("Green salad - with lettuce, cucumber and green olives");
        }
    }
}
