using Reciply.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reciply.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CookRecipeIngredients : ContentPage
    {
        private Recipe Recipe;
        public CookRecipeIngredients(Recipe recipe)
        {
            InitializeComponent();
            Name.Text = recipe.Name;
            ingredients.ItemsSource = recipe.Ingredient;
            Recipe = recipe;
        }

        private async void Home_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private async void Next_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CookRecipePreparation(Recipe), true);
        }
    }
}