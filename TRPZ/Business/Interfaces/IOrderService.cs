using System;
using System.Collections.Generic;
using System.Text;

namespace TRPZ.Business
{
    public interface IOrderService
    {
        DateTime GetTimeWhenAllDishesAreCooked(Order order);
        Order CreateOrder(IEnumerable<Dish> dishes);
    }
}
