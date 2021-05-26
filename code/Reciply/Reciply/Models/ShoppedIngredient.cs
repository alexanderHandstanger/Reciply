using System;
using System.Collections.Generic;
using System.Text;

namespace Reciply.Models
{
    class ShoppedIngredient
    {
        public DateTime Time { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}
