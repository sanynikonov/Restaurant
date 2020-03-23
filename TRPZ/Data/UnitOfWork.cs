using System;
using System.Collections.Generic;
using System.Text;

namespace TRPZ.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EliteRestaurantContext context;

        public UnitOfWork(EliteRestaurantContext context, ICookRepository cookRepository, IDishRepository dishRepository)
        {
            this.context = context;
            CookRepository = cookRepository;
            DishRepository = dishRepository;
        }

        public ICookRepository CookRepository { get; }

        public IDishRepository DishRepository { get; }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
