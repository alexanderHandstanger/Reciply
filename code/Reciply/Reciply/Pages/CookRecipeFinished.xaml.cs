using Reciply.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reciply.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CookRecipeFinished : ContentPage
    {
        private Recipe Recipe;
        public CookRecipeFinished(Recipe recipe)
        {
            InitializeComponent();
            Name.Text = recipe.Name;
            Recipe = recipe;
        }

        private async void Home_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private async void Back_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CookRecipePreparation(Recipe), true);
        }
    }
}