using Reciply.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reciply.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Recipepage : ContentPage
    {
        private List<Ingredient> placeHolderList = new List<Ingredient>();
        public Recipepage()
        {
            InitializeComponent();
            placeHolderList = Initials();
            PlaceHolderList.ItemsSource = placeHolderList;
        }

        private List<Ingredient> Initials()
        {
            List<Ingredient> initialList = new List<Ingredient>();
            initialList.Add(new Ingredient { Item = "Dotter", Amount = 4, UnitOfMeasurement = UnitOfMeasurement.Stück });
            initialList.Add(new Ingredient { Item = "Zucker", Amount = 25, UnitOfMeasurement = UnitOfMeasurement.dag });
            initialList.Add(new Ingredient { Item = "Mehl", Amount = 25, UnitOfMeasurement = UnitOfMeasurement.dag });
            initialList.Add(new Ingredient { Item = "Wasser", Amount = 125, UnitOfMeasurement = UnitOfMeasurement.ml });
            initialList.Add(new Ingredient { Item = "Öl", Amount = 125, UnitOfMeasurement = UnitOfMeasurement.ml });
            initialList.Add(new Ingredient { Item = "Vanillies", Amount = 18, UnitOfMeasurement = UnitOfMeasurement.Stück });
            initialList.Add(new Ingredient { Item = "Backpulver", Amount = 0.5, UnitOfMeasurement = UnitOfMeasurement.Pkg });
            initialList.Add(new Ingredient { Item = "Kakau", Amount = 10, UnitOfMeasurement = UnitOfMeasurement.Esslöffel });
            return initialList;
        }
    }
}