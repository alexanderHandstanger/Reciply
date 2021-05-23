using Reciply.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reciply.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CookRecipePreparation : ContentPage
    {
        private Recipe Recipe;
        public CookRecipePreparation(Recipe recipe)
        {
            InitializeComponent();
            Name.Text = recipe.Name;
            Preparation.Text = recipe.Preparation;
            Recipe = recipe;
        }

        private async void Home_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private async void Back_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CookRecipeIngredients(Recipe), true);
        }

        private async void Next_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CookRecipeFinished(Recipe), true);
        }
    }
}