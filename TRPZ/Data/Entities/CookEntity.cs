using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TRPZ.Data
{
    public class CookEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CuisineTypeEntity> CuisinesSpecializedIn { get; set; }
        public DateTime WhenFinishes { get; set; }

        public CookEntity()
        {
            CuisinesSpecializedIn = new Collection<CuisineTypeEntity>();
        }
    }
}
