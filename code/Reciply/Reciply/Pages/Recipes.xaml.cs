using Reciply.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reciply
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Recipes : ContentPage
    {
        public Recipes()
        {
            InitializeComponent();
        }
        
        private async void Discover_Button_Clicked(object sender, EventArgs e)
        {
            //Code below only for testing
            //await Navigation.PushAsync(new Recipepage(/*"Kartoffelpuffer"*/), true); //instead of null we can now write the name of the desired recipe; f. e. "Vanille Keckse"
            await Navigation.PushAsync(new Discover_RecipePage(), true);
        }

        private async void Home_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private async void OwnRecipeButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OwnRecipesPage(), true);
        }
    }
}