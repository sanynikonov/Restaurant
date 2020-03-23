using System;
using System.Collections.Generic;
using System.Text;

namespace TRPZ.Business
{
    public interface IDishService
    {
        IEnumerable<Dish> GetAll();
    }
}
