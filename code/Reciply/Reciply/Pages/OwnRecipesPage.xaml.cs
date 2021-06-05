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

namespace Reciply.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OwnRecipesPage : ContentPage
    {
        public ObservableCollection<Recipe> OwnRecipes { get; set; }

        public OwnRecipesPage()
        {
            InitializeComponent();
            BindingContext = this;
            Test_AddRecipes.AddRecipes();
            using var dataContext = new DataContext();
            OwnRecipes = new ObservableCollection<Recipe>(dataContext.Recipes.ToArray());
            recipes.ItemsSource = OwnRecipes;
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

        private void AddButton_Clicked(object sender, EventArgs e)
        {
            //Redirect to Recipes Add/Change Page
        }

        private void EditButton_Clicked(object sender, EventArgs e)
        {
            //Redirect to Recipes Add/Change Page with a Recipe parameter for editing?
        }
    }
}