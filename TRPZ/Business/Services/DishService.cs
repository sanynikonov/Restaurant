using System;
using System.Collections.Generic;
using System.Text;
using TRPZ.Data;

namespace TRPZ.Business
{
    public class DishService : IDishService
    {
        private readonly IDishRepository dishRepository;

        public DishService(IDishRepository dishRepository)
        {
            this.dishRepository = dishRepository;
        }

        public IEnumerable<Dish> GetAll()
        {
            return dishRepository.GetAll();
        }
    }
}
