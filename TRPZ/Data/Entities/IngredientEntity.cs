using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TRPZ.Data
{
    public class IngredientEntity
    {
        [Key]
        public int Id { get; set; }
        public string Ingredient { get; set; }
    }
}
