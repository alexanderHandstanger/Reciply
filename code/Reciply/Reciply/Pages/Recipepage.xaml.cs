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
            //var recipe = Initials(filter);
            SetAmountOfOnePortion();
            BindingContext = Recipe[0];
            Ingredients.ItemsSource = Recipe[0].Ingredient;
            Portions.Text = Convert.ToString(Recipe[0].Portion);
        }

        private ObservableCollection<Recipe> Initials()
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

            ObservableCollection<Recipe> initialRecipe = new ObservableCollection<Recipe>();
            initialRecipe.Add( new Recipe { Id = 1, Description = "Ein supergeiles Gericht", Duration = 3, Name = "5 Minutenkuche", Portion = 4, Rating = 3, Preparation = "Einfach Mixen", Tags = "#Kuchen, #Schnell", Ingredient = ingredients });
            
            return initialRecipe;
        }

        /*
        private Recipe Initials(string filter)
        {
            using var dataContext = new DataContext();
            if (string.IsNullOrEmpty(filter))
            {
                return dataContext.Recipes.Include(x => x.Ingredient).FirstOrDefault();
            }
            return dataContext.Recipes.Include(x => x.Ingredient).Where(n => filter == n.Name).First();
        } 
        */

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

        private void AddToShoppingList(object sender, EventArgs e)
        {
            //TODO add recipe to shoppinglist
        }

        private async void Home_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}