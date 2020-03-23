using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace TRPZ.Business
{
    public class OrderServiceMock : IOrderService
    {
        private ICookService cookService;

        public OrderServiceMock(ICookService cookService)
        {
            this.cookService = cookService;
        }

        public Order CreateOrder(IEnumerable<Dish> dishes)
        {
            Order order = new Order();

            foreach (Dish dish in dishes)
            {
                order.DishesWithPreparingTime[dish] = cookService.AssignDishToCookAndReturnWaitingTime(dish);
            }

            return order;
        }

        public DateTime GetTimeWhenAllDishesAreCooked(Order order)
        {
            return order.DishesWithPreparingTime.Max(x => x.Value);
        }
    }
}
