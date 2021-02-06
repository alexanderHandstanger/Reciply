using Microsoft.EntityFrameworkCore;
using Reciply.Models;
using Reciply.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Reciply
{
    public partial class MainPage : ContentPage //currently finished
    {
        private List<Ingredient> EinkaufsListe = new List<Ingredient>();
        private List<SelectedRecipe> SelectRecipe = new List<SelectedRecipe>();
        public MainPage()
        {
            InitializeComponent();
            InitialSelectedRecipes();
            Initials();
            //using (var dataContext = new DataContext())
            //{
            //    var ingredientsWithKg = dataContext.Ingredients
            //        .Where(i => i.UnitOfMeasurement == UnitOfMeasurement.kg)
            //        .ToList();
                
            //}
        }

        public void Initials()
        {
            List<Ingredient> initialsList = new List<Ingredient>();
            initialsList.Add(new Ingredient { Item = "Mehl", Amount = 1, UnitOfMeasurement = UnitOfMeasurement.kg, IsInShoppingBasket = false });
            initialsList.Add(new Ingredient { Item = "Kartoffeln", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.kg, IsInShoppingBasket = false });
            initialsList.Add(new Ingredient { Item = "Schinken", Amount = 50, UnitOfMeasurement = UnitOfMeasurement.dag, IsInShoppingBasket = false });
            initialsList.Add(new Ingredient { Item = "Eier", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.Stück, IsInShoppingBasket = false });
            initialsList.Add(new Ingredient { Item = "Pizzateig", Amount = 1, UnitOfMeasurement = UnitOfMeasurement.Pkg, IsInShoppingBasket = false });
            initialsList.Add(new Ingredient { Item = "Reis", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.kg, IsInShoppingBasket = false });
            initialsList.Add(new Ingredient { Item = "Wasser", Amount = 5, UnitOfMeasurement = UnitOfMeasurement.l, IsInShoppingBasket = false });
            initialsList.Add(new Ingredient { Item = "Essig", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.Teelöffel, IsInShoppingBasket = false });
            initialsList.Add(new Ingredient { Item = "Salz", Amount = 150, UnitOfMeasurement = UnitOfMeasurement.g, IsInShoppingBasket = false });
            initialsList.Add(new Ingredient { Item = "Mais", Amount = 10, UnitOfMeasurement = UnitOfMeasurement.kg, IsInShoppingBasket = false });
            initialsList.Add(new Ingredient { Item = "Zuccini", Amount = 0.5, UnitOfMeasurement = UnitOfMeasurement.kg, IsInShoppingBasket = false });
            initialsList.Add(new Ingredient { Item = "Zucker", Amount = 12, UnitOfMeasurement = UnitOfMeasurement.kg, IsInShoppingBasket = false });
            initialsList.Add(new Ingredient { Item = "Karotten", Amount = 6, UnitOfMeasurement = UnitOfMeasurement.kg, IsInShoppingBasket = false });
            initialsList.Add(new Ingredient { Item = "Haferflocken", Amount = 7, UnitOfMeasurement = UnitOfMeasurement.kg, IsInShoppingBasket = false });
            initialsList.Add(new Ingredient { Item = "Pasta", Amount = 3, UnitOfMeasurement = UnitOfMeasurement.kg, IsInShoppingBasket = false });
            EinkaufsListe.AddRange(initialsList);
            Einkaufsliste.ItemsSource = initialsList;

            //using (var dataContext = new DataContext())
            //{
            //    dataContext.RemoveRange(dataContext.Ingredients);
            //    dataContext.Database.ExecuteSqlRaw("delete from sqlite_sequence where name='Ingredients';");
            //    dataContext.Database.ExecuteSqlRaw("delete from sqlite_sequence where name='Recipes';");
            //    dataContext.Ingredients.AddRange(initialsList);
            //    dataContext.SaveChanges();
            //}
        }

        public void InitialSelectedRecipes()
        {

            SelectRecipe.Add(new SelectedRecipe { RecipeName = "Gulasch" });
            SelectRecipe.Add(new SelectedRecipe { RecipeName = "Kuchen" });
            SelectRecipe.Add(new SelectedRecipe { RecipeName = "Pizza" });
            SelectRecipe.Add(new SelectedRecipe { RecipeName = "Schnitzel" });
            selectRecipe.ItemsSource = SelectRecipe;
        }



        //Navigation
        private async void RecipeButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Recipes(), true);
        }

        private async void EinkaufVerlauf_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EinkaufVerlauf(), true);
        }

        private async void ButtonClicked_JetztKochen(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CookRecipesIngrediants(), true);
        }

        private async void Einkaufsliste_Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EinkaufslisteEdit(), true);
        }

        private async void Einkaufsliste_Share_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Test_AddRecipes(), true);
        }

        //Other
        private void SelectedRecipes_Clicked(object sender, EventArgs e)
        {
            selectRecipe.IsVisible = !selectRecipe.IsVisible;
        }
    }
}
