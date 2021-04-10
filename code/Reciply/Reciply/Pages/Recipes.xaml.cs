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

        //Only for testing, will be removed soon -AH
        //Please fix spelling mistakes (Forwarding) -LN
        private async void Temp_Farwarding_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Recipepage("Kartoffelpuffer"), true); //instead of null we can now write the name of the desired recipe; f. e. "Vanille Keckse"
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage(), true);
        }
    }
}