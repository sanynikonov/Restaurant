using System;
using System.Collections.Generic;
using System.Text;

namespace TRPZ.Business
{
    public class CookServiceMock : ICookService
    {
        private readonly List<Cook> Cooks;

        public CookServiceMock()
        {
            Cooks = new List<Cook>
            {
                new Cook
                {
                    Name = "B.B. King",
                    CuisinesSpecializedIn = new List<CuisineType>
                    {
                        CuisineType.American, CuisineType.English
                    },
                },
                new Cook
                {
                    Name = "Joe Cocker",
                    CuisinesSpecializedIn = new List<CuisineType>
                    {
                        CuisineType.Italian
                    },
                },
                new Cook
                {
                    Name = "Eric Clapton",
                    CuisinesSpecializedIn = new List<CuisineType>
                    {
                        CuisineType.Russian, CuisineType.Ukrainian
                    },
                }
            };
        }

        public DateTime AssignDishToCookAndReturnWaitingTime(Dish dish)
        {
            Cook cook = FindNotBusyCook(dish);
            if (cook == null)
                cook = FindLeastBusyCook(dish);

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
