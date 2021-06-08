using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Windows;
using Reciply.Models;
using System.IO;

namespace Reciply.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OwnRecipesPage : ContentPage
    {
        public ObservableCollection<Recipe> OwnRecipes = new ObservableCollection<Recipe>();

        private static OwnRecipesPage _instance;
        public static OwnRecipesPage PageInstance
        {
            get
            {
                return _instance;
            }
        }

        public OwnRecipesPage()
        {
            InitializeComponent();
            BindingContext = this;
            _instance = this;
            //Test_AddRecipes.AddRecipes();
            // using var dataContext = new DataContext();
            //OwnRecipes = new ObservableCollection<Recipe>(dataContext.Recipes.ToArray());
            //Initialise_OwnRecipes();
            //File.Delete(MainPage.PageInstance.FilePathForOwnRecipes);
            OwnRecipes = MainPage.PageInstance.ReadJson<Recipe>(MainPage.PageInstance.FilePathForOwnRecipes) as ObservableCollection<Recipe>;
            if (OwnRecipes == null) OwnRecipes = new ObservableCollection<Recipe>();
            recipes.ItemsSource = OwnRecipes;
        }

        public void Initialise_OwnRecipes()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            ingredients.Add(new Ingredient { Item = "Mehl", Amount = 1, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Kartoffeln", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Schinken", Amount = 50, UnitOfMeasurement = UnitOfMeasurement.dag, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Eier", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.Stück, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Pizzateig", Amount = 1, UnitOfMeasurement = UnitOfMeasurement.Pkg, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Reis", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Wasser", Amount = 5, UnitOfMeasurement = UnitOfMeasurement.l, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Essig", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.Teelöffel, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Salz", Amount = 150, UnitOfMeasurement = UnitOfMeasurement.g, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Mais", Amount = 10, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Zuccini", Amount = 0.5, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Zucker", Amount = 12, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Karotten", Amount = 6, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Haferflocken", Amount = 7, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Pasta", Amount = 3, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
          
            OwnRecipes.Add(new Recipe { Id = 1, Description = "Ein supergeiles Gericht", Duration = 3, Name = "5 Minutenkuche", Portion = 4, Rating = 3, Preparation = "Einfach Mixen", Tags = "#Kuchen, #Schnell", Ingredient = ingredients });

            List<Ingredient> ingredients2 = new List<Ingredient>();
            ingredients2.Add(new Ingredient { Item = "Mehl", Amount = 1, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients2.Add(new Ingredient { Item = "Kartoffeln", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients2.Add(new Ingredient { Item = "Schinken", Amount = 50, UnitOfMeasurement = UnitOfMeasurement.dag, IsSelected = false });
            ingredients2.Add(new Ingredient { Item = "Eier", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.Stück, IsSelected = false });
            ingredients2.Add(new Ingredient { Item = "Pizzateig", Amount = 1, UnitOfMeasurement = UnitOfMeasurement.Pkg, IsSelected = false });
            ingredients2.Add(new Ingredient { Item = "Reis", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients2.Add(new Ingredient { Item = "Wasser", Amount = 5, UnitOfMeasurement = UnitOfMeasurement.l, IsSelected = false });
            ingredients2.Add(new Ingredient { Item = "Essig", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.Teelöffel, IsSelected = false });
            ingredients2.Add(new Ingredient { Item = "Salz", Amount = 150, UnitOfMeasurement = UnitOfMeasurement.g, IsSelected = false });
            ingredients2.Add(new Ingredient { Item = "Mais", Amount = 10, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients2.Add(new Ingredient { Item = "Zuccini", Amount = 0.5, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients2.Add(new Ingredient { Item = "Zucker", Amount = 12, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients2.Add(new Ingredient { Item = "Karotten", Amount = 6, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients2.Add(new Ingredient { Item = "Haferflocken", Amount = 7, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients2.Add(new Ingredient { Item = "Pasta", Amount = 3, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });

            OwnRecipes.Add(new Recipe { Id = 2, Description = "Leckere Gemüsesuppe", Duration = 3, Name = "Würzige Suppe", Portion = 4, Rating = 3, Preparation = "Bissi herschneiden und so", Tags = "#Kuchen, #Schnell", Ingredient = ingredients2 });

            
        }

        private async void Home_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchResults = OwnRecipes.Where(r => r.Name.ToLower().Contains(SearchBar.Text.ToLower()));
            recipes.ItemsSource = searchResults;
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddEditRecipe(), true);
        }

        private async void EditButton_Clicked(object sender, EventArgs e)
        {
            var selectedObject = ((Button)sender).CommandParameter as string;
            Recipe selectedItem = OwnRecipes.Where(x => x.Name == selectedObject).FirstOrDefault();    
            await Navigation.PushAsync(new AddEditRecipe(selectedItem), true);
        }
    }
}