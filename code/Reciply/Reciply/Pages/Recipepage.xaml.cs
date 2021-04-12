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
            return dataContext.Recipes.Include(x => x.Ingredient).Where(n => filter == n.Name).First();
        }

        private async void Home_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}