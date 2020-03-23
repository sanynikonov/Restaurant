using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TRPZ.Data
{
    public class DishRepositoryMock : IDishRepository
    {
        private EliteRestaurantContext context;

        public DishRepositoryMock(EliteRestaurantContext context)
        {
            this.context = context;
        }

        public IEnumerable<DishEntity> GetAll()
        {
            return context.Dishes.ToList();
        }
    }
}
