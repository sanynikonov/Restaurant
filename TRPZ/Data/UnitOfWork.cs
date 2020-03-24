using System;
using System.Collections.Generic;
using System.Text;

namespace TRPZ.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EliteRestaurantContext context;
        private ICookRepository cookRepository;
        private IDishRepository dishRepository;

        public UnitOfWork(EliteRestaurantContext context)
        {
            this.context = context;
        }

        public ICookRepository CookRepository
        {
            get
            {
                return cookRepository ??= new CookRepository(context);
            }
        }

        public IDishRepository DishRepository
        {
            get
            {
                return dishRepository ??= new DishRepository(context);
            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
