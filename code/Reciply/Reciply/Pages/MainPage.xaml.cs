using Newtonsoft.Json;
using Reciply.Models;
using Reciply.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace Reciply
{
    public partial class MainPage : ContentPage
    {
        private string FilePathForShoppingList = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Einkaufsliste.json");
        private string FilePathForSelectedRecipes = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "SelectedRecipes.json");

        public ObservableCollection<Ingredient> EinkaufsListe = new ObservableCollection<Ingredient>();
        private ObservableCollection<Recipe> SelectedRecipes = new ObservableCollection<Recipe>();
        private ObservableCollection<Ingredient> ShoppedItems = new ObservableCollection<Ingredient>();

        private bool Shopped;

        private static MainPage _instance;
        public static MainPage PageInstance
        {
            get
            {
                return _instance;
            }
        }

        public MainPage()
        {
            _instance = this;
            InitializeComponent();

            ReadShoppingListFromJson();
            ReadSelectedRecipesFromJson();

            SelectedRecipe.ItemsSource = SelectedRecipes;
            Einkaufsliste.ItemsSource = EinkaufsListe;
        }

        //Methods for Json
        public void ReadShoppingListFromJson()
        {
            using (StreamReader r = new StreamReader(FilePathForShoppingList))
            {
                string json = r.ReadToEnd();
                EinkaufsListe = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<Ingredient>>(json);
            }
        }

        private void SaveShoppingListAsJson()
        {
            File.Delete(FilePathForShoppingList);
            string json = JsonConvert.SerializeObject(EinkaufsListe);
            File.WriteAllText(FilePathForShoppingList, json);
        }

        public void ReadSelectedRecipesFromJson()
        {
            using (StreamReader r = new StreamReader(FilePathForSelectedRecipes))
            {
                string json = r.ReadToEnd();
                SelectedRecipes = Newtonsoft.Json.JsonConvert.DeserializeObject<ObservableCollection<Recipe>>(json);
            }
        }

        //Navigation Buttons
        private async void RecipeButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Recipes(), true);
        }

        private async void EinkaufVerlauf_Clicked(object sender, EventArgs e)
        {
            if (Shopped)
            {
                await Navigation.PushAsync(new EinkaufVerlauf(ShoppedItems, DateTime.Now), true);
            }
            else
            {
                await Navigation.PushAsync(new EinkaufVerlauf(), true);
            }         
        }

        private async void ButtonClicked_JetztKochen(object sender, EventArgs e)
        {
            var selectedObject = ((Button)sender).CommandParameter;
            int selectedItemId = int.Parse(string.Format("{0}", selectedObject));
            Recipe selectedItem = SelectedRecipes.Where(x => x.Id == selectedItemId).FirstOrDefault();

            await Navigation.PushAsync(new CookRecipeIngredients(selectedItem), true);
        }

        private async void Einkaufsliste_Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EinkaufslisteEdit(EinkaufsListe), true);
        }

        private async void Einkaufsliste_Share_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Test_AddRecipes(), true);
        }

        private void SelectedRecipes_Clicked(object sender, EventArgs e)
        {
            SelectedRecipe.IsVisible = !SelectedRecipe.IsVisible;
        }

        private async void Home_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        //Other
        private void ConfimPurchase_Button_Clicked(object sender, EventArgs e)
        {
            for (int i = EinkaufsListe.Count - 1; i >= 0; i--)
            {
                if (EinkaufsListe[i].IsSelected)
                {
                    ShoppedItems.Add(EinkaufsListe[i]);
                    EinkaufsListe.Remove(EinkaufsListe[i]);
                    Shopped = true;
                }
            }
            SaveShoppingListAsJson();
        }
    }
}