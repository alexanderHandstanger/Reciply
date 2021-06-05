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

        private async void Rate_Button_Clicked(object sender, EventArgs e)
        {
            int rating = int.Parse(Rating.Text);
            if (rating >= 0 && rating <= 5)
            {
                // TODO add rating to recipe
            }
            else
            {
                await DisplayAlert("Invalid rating", "Rating 1-5", "OK");
            }
        }

        private async void Finished_Button_Clicked(object sender, EventArgs e)
        {
            MainPage.PageInstance.SelectedRecipes.Remove(Recipe);
            MainPage.PageInstance.SaveJson(MainPage.PageInstance.FilePathForSelectedRecipes, MainPage.PageInstance.SelectedRecipes);

            await Navigation.PopToRootAsync();
        }
    }
}