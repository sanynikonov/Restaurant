using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TRPZ.Data;

namespace TRPZ.Business
{
    public class DishService : IDishService
    {
        private readonly IUnitOfWork unit;
        private readonly IMapper mapper;

        public DishService(IUnitOfWork unit, IMapper mapper)
        {
            this.unit = unit;
            this.mapper = mapper;
        }

        public IEnumerable<Dish> GetAll()
        {
            var entities = unit.DishRepository.GetAll();
            return mapper.Map<IEnumerable<Dish>>(entities);
        }
    }
}
