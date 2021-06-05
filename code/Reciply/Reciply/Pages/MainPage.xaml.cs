using Newtonsoft.Json;
using Reciply.Models;
using Reciply.Pages;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace Reciply
{
    public partial class MainPage : ContentPage
    {
        public string FilePathForShoppingList = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ShoppingList.json");
        public string FilePathForSelectedRecipes = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "SelectedRecipes.json");
        public string FilePathForShoppedList = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "ShoppedList.json");
        public string FilePathForOwnRecipes = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "OwnRecipes.json");

        public ObservableCollection<Ingredient> EinkaufsListe = new ObservableCollection<Ingredient>();
        public ObservableCollection<Recipe> SelectedRecipes = new ObservableCollection<Recipe>();
        public ObservableCollection<Ingredient> ShoppedItems = new ObservableCollection<Ingredient>();

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

            EinkaufsListe = ReadJson<Ingredient>(FilePathForShoppingList) as ObservableCollection<Ingredient>;
            SelectedRecipes = ReadJson<Recipe>(FilePathForSelectedRecipes) as ObservableCollection<Recipe>;

            Einkaufsliste.ItemsSource = EinkaufsListe;
            SelectedRecipe.ItemsSource = SelectedRecipes;
        }

        //Methods for Json
        public object ReadJson<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, null);
                return null;
            }
            else
            {
                string json;
                using (StreamReader r = new StreamReader(filePath))
                {
                    json = r.ReadToEnd();
                    return JsonConvert.DeserializeObject<ObservableCollection<T>>(json);
                }
            }
        }

        public void SaveJson(string filePath, object dataToSave)
        {
            File.Delete(filePath);
            string json = JsonConvert.SerializeObject(dataToSave);
            File.WriteAllText(filePath, json);
        }

        //Other Methods
        public void AddToShoppingList(Ingredient itemToAdd)
        {
            if (EinkaufsListe.Any(x => x.Item == itemToAdd.Item))
            {
                var ingredient = EinkaufsListe.Where(x => x.Item == itemToAdd.Item && x.UnitOfMeasurement == itemToAdd.UnitOfMeasurement).First();
                ingredient.Amount += itemToAdd.Amount;
            }
            else
            {
                EinkaufsListe.Add(itemToAdd);
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
                ShoppedItems.Clear();
                Shopped = false;
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
            await Navigation.PushAsync(new EinkaufslisteEdit(), true);
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

        //Other Buttons
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
            SaveJson(FilePathForShoppingList, EinkaufsListe);
        }
    }
}