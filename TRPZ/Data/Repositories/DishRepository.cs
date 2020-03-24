using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TRPZ.Data
{
    public class DishRepository : IDishRepository
    {
        private EliteRestaurantContext context;

        public DishRepository(EliteRestaurantContext context)
        {
            this.context = context;
        }

        public IEnumerable<DishEntity> GetAll()
        {
            return context.Dishes.ToList();
        }
    }
}
