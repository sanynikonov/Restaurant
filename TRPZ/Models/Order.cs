using System;
using System.Collections.Generic;
using System.Text;

namespace TRPZ
{
    public class Order
    {
        public Dictionary<Dish, DateTime> DishesWithPreparingTime { get; set; }
        public DateTime WhenOrdered { get; set; }

        public Order()
        {
            DishesWithPreparingTime = new Dictionary<Dish, DateTime>();
            WhenOrdered = DateTime.Now;
        }
    }
}
