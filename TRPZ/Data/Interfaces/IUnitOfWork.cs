using System;
using System.Collections.Generic;
using System.Text;

namespace TRPZ.Data
{
    public interface IUnitOfWork
    {
        ICookRepository CookRepository { get; }
        IDishRepository DishRepository { get; }

        void SaveChanges();
    }
}
