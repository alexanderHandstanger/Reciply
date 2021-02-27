using Microsoft.EntityFrameworkCore;
using Reciply.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reciply.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Recipepage : ContentPage
    {
        Recipe recipe;
        public Recipepage()
        {
            InitializeComponent();
            recipe = Initials();
            ingredients.ItemsSource = recipe.Ingredient;
            BindingContext = recipe;
        }

        private Recipe Initials()
        {
            using var dataContext = new DataContext();
            return dataContext.Recipes.Include(x => x.Ingredient).FirstOrDefault();
        }

        private void AddPortion(object sender, EventArgs e)
        {
            double onePortionPercentage = 100 / recipe.Portion; //percentage of one portion
            for (int i = 0; i < recipe.Ingredient.Count; i++)
            {
                recipe.Ingredient[i].Amount = recipe.Ingredient[i].Amount * (1 + onePortionPercentage / 100 );
            }
            recipe.Portion++;
            //TODO add portion and raise ingridients
        }

        private void RemovePortion(object sender, EventArgs e)
        {
            double onePortionPercentage = 100 / recipe.Portion; //percentage of one portion
            for (int i = 0; i < recipe.Ingredient.Count; i++)
            {
                recipe.Ingredient[i].Amount = recipe.Ingredient[i].Amount * (1 - onePortionPercentage / 100);
            }
            recipe.Portion--;
            //TODO reduce portion and ingridients
        }

        private void AddToShoppingList(object sender, EventArgs e)
        {
            //TODO add recipe to shoppinglist
        }
    }
}