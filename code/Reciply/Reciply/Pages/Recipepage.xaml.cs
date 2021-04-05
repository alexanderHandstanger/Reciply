using Microsoft.EntityFrameworkCore;
using Reciply.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reciply.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Recipepage : ContentPage
    {
        public Recipepage(string filter)
        {
            InitializeComponent();
            var recipe = Initials(filter);
            ingredients.ItemsSource = recipe.Ingredient;
            BindingContext = recipe;
        }

        private Recipe Initials(string filter)
        {
            using var dataContext = new DataContext();
            if (string.IsNullOrEmpty(filter))
            {
                return dataContext.Recipes.Include(x => x.Ingredient).FirstOrDefault();
            }
            return (Recipe)dataContext.Recipes.Include(x => x.Ingredient).Where(n => filter == n.Name).Select(r => new Recipe
            {
                Name = r.Name,
                Ingredient = r.Ingredient,
                Portion = r.Portion,
                Rating = r.Rating,
                Duration = r.Duration,
                Tags = r.Tags,
                Description = r.Description,
                Preparation = r.Preparation
            });
        }
    }
}