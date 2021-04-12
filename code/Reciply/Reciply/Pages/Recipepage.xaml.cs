using Microsoft.EntityFrameworkCore;
using Reciply.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reciply.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Recipepage : ContentPage
    {
        public ObservableCollection<Recipe> recipe { get; } = new ObservableCollection<Recipe>();
        private List<double> amountOfOnePortionList = new List<double>();
        public Recipepage()
        {
            InitializeComponent();
            recipe = Initials();
            //var recipe = Initials(filter);
            ingredients.ItemsSource = recipe[0].Ingredient;
            BindingContext = recipe[0];
            SetAmountOfOnePortion();
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
            for (int i = 0; i < recipe[0].Ingredient.Count; i++)
            {
                recipe[0].Ingredient[i].Amount = recipe[0].Ingredient[i].Amount + amountOfOnePortionList[i];
            }
            recipe[0].Portion++;
        }

        private void RemovePortion(object sender, EventArgs e)
        {
            for (int i = 0; i < recipe[0].Ingredient.Count; i++)
            {
                recipe[0].Ingredient[i].Amount = recipe[0].Ingredient[i].Amount - amountOfOnePortionList[i];
            }
            recipe[0].Portion--;
        }

        private void SetAmountOfOnePortion() //sets the ingridient amount of one portion
        {
            if (amountOfOnePortionList.Count == 0)
            {
                for (int i = 0; i < recipe[0].Ingredient.Count; i++)
                {
                    double amountOfOnePortion = recipe[0].Ingredient[i].Amount / recipe[0].Portion;
                    amountOfOnePortionList.Add(amountOfOnePortion);
                }
            }
        }

        private void AddToShoppingList(object sender, EventArgs e)
        {
            //TODO add recipe to shoppinglist
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}