using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reciply.Models;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reciply.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddEditRecipe : ContentPage
    {
        public Recipe Recipe;
        public ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient>();
        public List<Ingredient> ingredientList = new List<Ingredient>();
        double entryDouble;
        int entryInt;
        public AddEditRecipe()
        {
            Recipe=null;
            ingredients.Clear();
            ingredientList.Clear();
            InitializeComponent();
        }
        public AddEditRecipe(Recipe recipe)
        {
            Recipe = recipe;

            foreach (var item in recipe.Ingredient)
            {
                ingredients.Add(item);
                ingredientList.Add(item);
            }
            InitializeComponent();
            Ingrediant_list.ItemsSource = Recipe.Ingredient;
            portion.Text = Convert.ToString(Recipe.Portion);
            dauer.Text = Convert.ToString(Recipe.Duration);
            tag.Text = Convert.ToString(Recipe.Tags);
            beschreibung.Text = Convert.ToString(Recipe.Description);
            zubereitung.Text = Convert.ToString(Recipe.Preparation);
        }

        public void AddIngrediant_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ingrediant.Text) 
                || string.IsNullOrEmpty(amount.Text) || !double.TryParse(amount.Text, out entryDouble)
                || einheit.SelectedItem == null) return;
            UnitOfMeasurement unit = (UnitOfMeasurement)Enum.Parse(typeof(UnitOfMeasurement), einheit.SelectedItem.ToString());
            ingredients.Add(new Ingredient { Item = ingrediant.Text, Amount = double.Parse(amount.Text), UnitOfMeasurement = unit });
            ingredientList.Add(new Ingredient { Item = ingrediant.Text, Amount = double.Parse(amount.Text), UnitOfMeasurement = unit });
            ingrediant.Text = null;
            amount.Text = null;
            einheit.SelectedItem = einheit.Title;
        }

        public void AddRecipe_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(recipeName.Text)
                || string.IsNullOrEmpty(portion.Text) || !int.TryParse(portion.Text, out entryInt)
                || string.IsNullOrEmpty(dauer.Text) || !double.TryParse(dauer.Text, out entryDouble)
                || string.IsNullOrEmpty(tag.Text)
                || string.IsNullOrEmpty(beschreibung.Text)
                || string.IsNullOrEmpty(zubereitung.Text)) return;
            Recipe = new Recipe
            {
                Name = recipeName.Text,
                Ingredient = ingredientList,
                Portion = int.Parse(portion.Text),
                Duration = double.Parse(dauer.Text),
                Tags = tag.Text,
                Description = beschreibung.Text,
                Preparation = zubereitung.Text
            };
            
        }

        public async void Cancle_Clicked(object sender, EventArgs e)
        {
            recipeName.Text = "";
            ingredients = new ObservableCollection<Ingredient>();
            ingrediant.Text = "";
            amount.Text = "";
            einheit.SelectedItem = einheit.Title;
            portion.Text = "";
            dauer.Text = "";
            tag.Text = "";
            beschreibung.Text = "";
            zubereitung.Text = "";


            //await Navigation.PushAsync(new OwnRecipes(), true);
        }
    }
}