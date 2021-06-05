using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Reciply.Models
{
    public class Recipe : INotifyPropertyChanged
    {
        public int Id { get; set; }//Primary Key
        public string Name { get; set; } //Name of the Recipe
        private List<Ingredient> ingredient;
        public List<Ingredient> Ingredient 
        {
            get => ingredient;
            set
            {
                ingredient = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Ingredient)));
            }
        } //The Ingredients 1/n
        public int Portion { get; set; } //One Portion = food for one people
        public int Rating { get; set; } //How many stars the food is rated 
        public double Duration { get; set; } //How long does the recipe need to be cooked
        public string Tags { get; set; } //Which tags the food has for example
        public string Description { get; set; } //The description of the food for example.: Carbonara is food with bacon and pasta
        public string Preparation { get; set; } //How you make the food

        public event PropertyChangedEventHandler PropertyChanged;
    }
}