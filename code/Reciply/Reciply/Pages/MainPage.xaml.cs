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
        private List<string> list;
        public MainPage()
        {
            InitializeComponent();
            list = Initials();
            Einkaufsliste.ItemsSource = list;
            EinkaufslisteCheckbox.ItemsSource = list;
        }

        public List<string> Initials()
        {
            List<string> initialsList = new List<string>();
            initialsList.Add("Bob");
            initialsList.Add("Alex");
            initialsList.Add("Robert");
            initialsList.Add("Miguel");
            initialsList.Add("Bob");
            initialsList.Add("Alex");
            initialsList.Add("Robert");
            initialsList.Add("Miguel");
            initialsList.Add("Bob");
            initialsList.Add("Alex");
            initialsList.Add("Robert");
            initialsList.Add("Miguel");
            initialsList.Add("Bob");
            initialsList.Add("Alex");
            initialsList.Add("Robert");
            initialsList.Add("Miguel");
            initialsList.Add("Bob");
            initialsList.Add("Alex");
            initialsList.Add("Robert");
            initialsList.Add("Miguel");
            return initialsList;
        }
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
