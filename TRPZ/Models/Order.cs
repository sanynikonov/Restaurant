using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRPZ
{
    public class Order
    {
        public List<KeyValuePair<Dish, DateTime>> DishesWithPreparingTime { get; set; }
        public DateTime WhenOrdered { get; set; }

        public Order()
        {
            DishesWithPreparingTime = new List<KeyValuePair<Dish, DateTime>>();
            WhenOrdered = DateTime.Now;
        }
    }
}
