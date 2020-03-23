using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TRPZ.Data;

namespace TRPZ.Business
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<DishEntity, Dish>()
                .ForMember(p => p.CuisineType, 
                    c => c.MapFrom(d => Enum.Parse<CuisineType>(d.CuisineType.CuisineType)));
            CreateMap<CookEntity, Cook>()
                .ForMember(p => p.CuisinesSpecializedIn,
                    c => c.MapFrom(d => d.CuisinesSpecializedIn
                        .Select(e => Enum.Parse<CuisineType>(e.CuisineType))));
        }
    }
}
