using System;
using System.Collections.Generic;
using System.Text;

namespace TRPZ
{
    public class Cook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CuisineType> CuisinesSpecializedIn { get; set; }
        public DateTime WhenFinishes { get; set; }

        public Cook()
        {
            CuisinesSpecializedIn = new List<CuisineType>();
        }
    }
}
