using System;
using System.Collections.Generic;
using System.Text;
using TRPZ.Data;

namespace TRPZ.Business
{
    public class CookServiceMock : ICookService
    {
        private readonly List<Cook> Cooks;
        private readonly ICookRepository cookRepository;

        public CookServiceMock(ICookRepository cookRepository)
        {
            this.cookRepository = cookRepository;
            Cooks = new List<Cook>(cookRepository.GetAll());
        }

        public DateTime AssignDishToCookAndReturnWaitingTime(Dish dish)
        {
            Cook cook = FindNotBusyCook(dish);
            if (cook == null)
                cook = FindLeastBusyCook(dish);

            if (cook.WhenFinishes < DateTime.Now)
                cook.WhenFinishes = DateTime.Now;
            
            cook.WhenFinishes += dish.CookingTime;

            return cook.WhenFinishes;
        }

        private Cook FindNotBusyCook(Dish dish)
        {
            foreach (Cook cook in Cooks)
            {
                if (IsFreeNow(cook) && DishBelongsToSpecialityOfCook(dish, cook))
                {
                    return cook;
                }
            }
            return null;
        }

        private Cook FindLeastBusyCook(Dish dish)
        {
            if (Cooks.Count > 0)
            {
                Cook leastBusyCook = Cooks[0];
                foreach (Cook cook in Cooks)
                {
                    if (cook.WhenFinishes < leastBusyCook.WhenFinishes && DishBelongsToSpecialityOfCook(dish, cook))
                        leastBusyCook = cook;
                }
                return leastBusyCook;
            }
            else 
                throw new Exception("We have no staff at the kitchen. It will not work!");
        }

        private bool DishBelongsToSpecialityOfCook(Dish dish, Cook cook)
        {
            return cook.CuisinesSpecializedIn.Contains(dish.CuisineType);
        }

        private bool IsFreeNow(Cook cook)
        {
            return cook.WhenFinishes < DateTime.Now;
        }
    }
}
