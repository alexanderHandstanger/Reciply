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

namespace Reciply.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OwnRecipesPage : ContentPage
    {
        public ObservableCollection<Models.Recipe> OwnRecipes { get; set; }

        public Command<int> Command1 { get; set; } = new Command<int>(i =>
        {
            using var dataContext = new DataContext();
            var editRecipe = dataContext.Recipes.ElementAt(i);
        });

        public OwnRecipesPage()
        {
            InitializeComponent();
            BindingContext = this;
            Test_AddRecipes.AddRecipes();
            using var dataContext = new DataContext();
            OwnRecipes = new ObservableCollection<Models.Recipe>(dataContext.Recipes.ToArray());
            ingredients.ItemsSource = OwnRecipes;
        }

        private async void Home_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchResults = OwnRecipes.Where(r => r.Name.ToLower().Contains(SearchBar.Text.ToLower()));
            ingredients.ItemsSource = searchResults;
        }

        private async void AddButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddEditRecipe(), true);
        }

        private void EditButton_Clicked(object sender, EventArgs e)
        {
            //Redirect to Recipes Add/Change Page with a Recipe parameter for editing?
        }
    }
}