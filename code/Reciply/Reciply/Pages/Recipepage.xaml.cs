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
        public Recipepage()
        {
            InitializeComponent();
            ingredients.ItemsSource = Initials().Ingredient;
            BindingContext = Initials();
        }

        private Recipe Initials()
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
            return new Recipe { Id = 1, Description = "Leckeres Nudelgericht", Ingredient = initialList, Portion = 4, Preparation = "Die Zwiebel schälen und in Ringe schneiden. Die gekochten Kartoffel schälen und in Scheiben schneiden. Das Backrohr auf 180° vorheizen.Eine Gratinform mit Butter einstreichen und schichtweise Kartoffel und Zwiebel hineingeben.Jede Schicht mit Salz,Pfeffer und Kümmel würzen.Die oberste Schicht mit Kartoffel abschließen.Den Schlagobers mit Creme Fraiche mischen und darübergießen. 40 Minuten im vorgeheizten Backrohr,Heißluft überbacken.", Rating = 5, Tags = "#Pasta", Duration = 25, Name = "Gulasch" };
        }
    }
}