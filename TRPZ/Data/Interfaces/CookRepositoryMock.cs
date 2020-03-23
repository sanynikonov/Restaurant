using System;
using System.Collections.Generic;
using System.Text;

namespace TRPZ.Data
{
    public class CookRepositoryMock : ICookRepository
    {
        public IEnumerable<Cook> GetAll()
        {
            return new List<Cook>
            {
                new Cook
                {
                    Name = "B.B. King",
                    CuisinesSpecializedIn = new List<CuisineType>
                    {
                        CuisineType.American, CuisineType.English
                    },
                },
                new Cook
                {
                    Name = "Joe Cocker",
                    CuisinesSpecializedIn = new List<CuisineType>
                    {
                        CuisineType.Italian
                    },
                },
                new Cook
                {
                    Name = "Eric Clapton",
                    CuisinesSpecializedIn = new List<CuisineType>
                    {
                        CuisineType.Russian, CuisineType.Ukrainian
                    },
                }
            };
        }
    }
}
