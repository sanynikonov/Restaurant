using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TRPZ.Data
{
    public class CookRepositoryMock : ICookRepository
    {
        private EliteRestaurantContext context;

        public CookRepositoryMock(EliteRestaurantContext context)
        {
            this.context = context;
        }

        public IEnumerable<CookEntity> GetAll()
        {
            return context.Cooks.ToList();
        }
    }
}
