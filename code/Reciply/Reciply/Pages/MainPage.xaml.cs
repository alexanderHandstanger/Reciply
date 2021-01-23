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
    public partial class MainPage : ContentPage
    {
        private List<Ingredient> einkaufsliste = new List<Ingredient>();
        public MainPage()
        {
            InitializeComponent();
            einkaufsliste = Initials();
            Einkaufsliste.ItemsSource = einkaufsliste;
        }

        public List<Ingredient> Initials()
        {
            List<Ingredient> initialsList = new List<Ingredient>();
            initialsList.Add(new Ingredient { item = "Mehl", amount = 1, unitOfMeasurement = UnitOfMeasurement.kg, isInShoppingBasket = false });
            initialsList.Add(new Ingredient { item = "Kartoffeln", amount = 2, unitOfMeasurement = UnitOfMeasurement.kg, isInShoppingBasket = false });
            initialsList.Add(new Ingredient { item = "Schinken", amount = 50, unitOfMeasurement = UnitOfMeasurement.dag, isInShoppingBasket = false });
            initialsList.Add(new Ingredient { item = "Eier", amount = 2, unitOfMeasurement = UnitOfMeasurement.Stück, isInShoppingBasket = false });
            initialsList.Add(new Ingredient { item = "Pizzateig", amount = 1, unitOfMeasurement = UnitOfMeasurement.Pkg, isInShoppingBasket = false });
            initialsList.Add(new Ingredient { item = "Reis", amount = 2, unitOfMeasurement = UnitOfMeasurement.kg, isInShoppingBasket = false });
            initialsList.Add(new Ingredient { item = "Wasser", amount = 5, unitOfMeasurement = UnitOfMeasurement.l, isInShoppingBasket = false });
            initialsList.Add(new Ingredient { item = "Essig", amount = 2, unitOfMeasurement = UnitOfMeasurement.Teelöffel, isInShoppingBasket = false });
            initialsList.Add(new Ingredient { item = "Salz", amount = 150, unitOfMeasurement = UnitOfMeasurement.g, isInShoppingBasket = false });
            initialsList.Add(new Ingredient { item = "Mais", amount = 10, unitOfMeasurement = UnitOfMeasurement.kg, isInShoppingBasket = false });
            return initialsList;
        }

        //Navigation
        private async void RecipeButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Recipes(), true);
        }
        private async void SelectedRecipes_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SelectedRecipes(), true);
        }
        private async void EinkaufVerlauf_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EinkaufVerlauf(), true);
        }
    }
}
