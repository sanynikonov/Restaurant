using System;
using System.Collections.Generic;
using System.Text;

namespace TRPZ.Data
{
    public interface ICookRepository
    {
        IEnumerable<Cook> GetAll();
    }
}
