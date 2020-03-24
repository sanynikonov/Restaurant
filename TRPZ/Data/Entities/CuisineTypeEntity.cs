using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TRPZ.Data
{
    public class CuisineTypeEntity
    {
        [Key]
        public int Id { get; set; }
        public string CuisineType { get; set; }
    }
}
