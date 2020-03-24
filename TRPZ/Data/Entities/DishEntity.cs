using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TRPZ.Data
{
    public class DishEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<IngredientEntity> Ingredients { get; set; }
        public TimeSpan CookingTime { get; set; }
        public int Weight { get; set; }
        public CuisineTypeEntity CuisineType { get; set; }
        public decimal Price { get; set; }

        public DishEntity()
        {
            Ingredients = new Collection<IngredientEntity>();
        }
    }
}
