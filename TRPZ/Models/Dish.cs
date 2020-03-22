using System;
using System.Collections.Generic;
using System.Text;

namespace TRPZ
{
    public class Dish
    {
        public string Name { get; set; }
        public List<string> Ingredients { get; set; }
        public TimeSpan CookingTime { get; set; }
        public int Weight { get; set; }
        public CuisineType CuisineType { get; set; }
        public decimal Price { get; set; }

        public Dish()
        {
            Ingredients = new List<string>();
        }
    }
}
