using System;
using System.Collections.Generic;
using System.Text;

namespace TRPZ.Data
{
    public class DishRepositoryMock : IDishRepository
    {
        public IEnumerable<Dish> GetAll()
        {
            return new List<Dish>
            {
                new Dish
                {
                    Name = "Fahitos",
                    CookingTime = new TimeSpan(0, 20, 0),
                    CuisineType = CuisineType.American,
                    Price = 100m,
                    Weight = 150
                },
                new Dish
                {
                    Name = "Fish & Chips",
                    CookingTime = new TimeSpan(0, 20, 0),
                    CuisineType = CuisineType.English,
                    Price = 100m,
                    Weight = 100
                },
                new Dish
                {
                    Name = "Varenyky",
                    CookingTime = new TimeSpan(0, 20, 0),
                    CuisineType = CuisineType.Ukrainian,
                    Price = 100m,
                    Weight = 200
                },
                new Dish
                {
                    Name = "Pasta Bolognese",
                    CookingTime = new TimeSpan(0, 20, 0),
                    CuisineType = CuisineType.Italian,
                    Price = 100m,
                    Weight = 250
                },
                new Dish
                {
                    Name = "Pelmeni",
                    CookingTime = new TimeSpan(0, 20, 0),
                    CuisineType = CuisineType.Russian,
                    Price = 100m,
                    Weight = 200
                },
            };
        }
    }
}
