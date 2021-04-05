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
        private async void Temp_Farwarding_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Recipepage("Vanille Kekse"), true);
        }
    }
}