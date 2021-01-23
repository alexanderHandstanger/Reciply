using System;
using System.Collections.Generic;
using System.Text;

namespace Reciply.Models
{
    class Recipe
    {
        public Ingredient Ingredient { get; set; } //The Ingredients
        public int Portion { get; set; } //One Portion = food for one people
        public int Rating { get; set; } //How many stars the food is rated 
        public string Tags { get; set; } //Which tags the food has for example
        public string Description { get; set; } //The description of the food for example.: Carbonara is food with bacon and pasta
        public string Preparation { get; set; } //How you make the food
    }
}