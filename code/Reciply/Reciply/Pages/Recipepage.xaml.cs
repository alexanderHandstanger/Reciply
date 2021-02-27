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
            recipe.Portion++;
            //TODO Portionen erhöhen (Zutaten erhöhen)
        }

        private void RemovePortion(object sender, EventArgs e)
        {
            //TODO Portionen sinken (Zutaten vermindern)
        }

        private void AddToShoppingList(object sender, EventArgs e)
        {
            //TODO Rezept hinzufügen zur Einkaufsliste
        }
    }
}