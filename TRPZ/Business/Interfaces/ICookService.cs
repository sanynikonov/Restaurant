using System;
using System.Collections.Generic;
using System.Text;

namespace TRPZ.Business
{
    public interface ICookService
    {
        DateTime AssignDishToCookAndReturnWaitingTime(Dish dish);
    }
}
