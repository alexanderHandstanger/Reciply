using Reciply.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reciply.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipePage : ContentPage
    {
        public ObservableCollection<Recipe> Recipe { get; } = new ObservableCollection<Recipe>();
        private List<double> AmountOfOnePortionList = new List<double>();

        public RecipePage(Recipe recipe)
        {           
            InitializeComponent();
            Recipe.Add(recipe);
            SetAmountOfOnePortion();

            BindingContext = Recipe[0];
            Ingredients.ItemsSource = Recipe[0].Ingredient;
            Portions.Text = Convert.ToString(Recipe[0].Portion);
        }

        private void AddPortion(object sender, EventArgs e)
        {
            for (int i = 0; i < Recipe[0].Ingredient.Count; i++)
            {
                Recipe[0].Ingredient[i].Amount = Recipe[0].Ingredient[i].Amount + AmountOfOnePortionList[i];
            }
            Recipe[0].Portion++;
            Portions.Text = Convert.ToString(Recipe[0].Portion);
        }

        private void RemovePortion(object sender, EventArgs e)
        {
            for (int i = 0; i < Recipe[0].Ingredient.Count; i++)
            {
                Recipe[0].Ingredient[i].Amount = Recipe[0].Ingredient[i].Amount - AmountOfOnePortionList[i];
            }
            Recipe[0].Portion--;
            Portions.Text = Convert.ToString(Recipe[0].Portion);
        }

        private void SetAmountOfOnePortion() //sets the ingridient amount of one portion
        {
            if (AmountOfOnePortionList.Count == 0)
            {
                for (int i = 0; i < Recipe[0].Ingredient.Count; i++)
                {
                    double amountOfOnePortion = Recipe[0].Ingredient[i].Amount / Recipe[0].Portion;
                    AmountOfOnePortionList.Add(amountOfOnePortion);
                }
            }
        }

        private async void AddToShoppingList(object sender, EventArgs e)
        {
            foreach (var ingredient in Recipe[0].Ingredient)
            {
                MainPage.PageInstance.EinkaufsListe.Add(ingredient);
            }
            MainPage.PageInstance.SelectedRecipes.Add(Recipe[0]);
            MainPage.PageInstance.SaveJson(MainPage.PageInstance.FilePathForSelectedRecipes, MainPage.PageInstance.SelectedRecipes);
            MainPage.PageInstance.SaveJson(MainPage.PageInstance.FilePathForShoppingList, MainPage.PageInstance.EinkaufsListe);
            await DisplayAlert("Erfolg", "Rezepte erfolgreich auf die Einkaufsliste gesetzt", "OK");
        }

        private async void Home_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private async void AddToSelectedRecipes_Button_Clicked(object sender, EventArgs e)
        {
            MainPage.PageInstance.SelectedRecipes.Add(Recipe[0]);
            MainPage.PageInstance.SaveJson(MainPage.PageInstance.FilePathForSelectedRecipes, MainPage.PageInstance.SelectedRecipes);
            await DisplayAlert("Erfolg", "Rezepte erfolgreich auf die ausgewählte Rezepte gesetzt", "OK");
        }

        private async void JetztKochen_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CookRecipeIngredients(Recipe[0]), true);
        }
    }
}