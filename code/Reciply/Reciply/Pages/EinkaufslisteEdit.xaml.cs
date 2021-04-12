using Microsoft.EntityFrameworkCore;
using Reciply.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reciply.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EinkaufslisteEdit : ContentPage
    {
        public ObservableCollection<Ingredient> EinkaufsListe = new ObservableCollection<Ingredient>();
        //List<Ingredient> initialList = new List<Ingredient>();

        public string ArticleEntry { get; set; }

        private double _amountEntry;
        public EinkaufslisteEdit()
        {
            InitializeComponent();
            Initials();
            //using (var dataContext = new DataContext())
            //{
            //    var ingredientsWithKg = dataContext.Ingredients
            //        .Where(i => i.UnitOfMeasurement == UnitOfMeasurement.kg)
            //        .ToList();
            //    EinkaufsListe.AddRange(ingredientsWithKg);
            //}
        }

        public void Initials()
        {
            ObservableCollection<Ingredient> initialList = new ObservableCollection<Ingredient>();
            initialList.Add(new Ingredient { Item = "Mehl", Amount = 1, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            initialList.Add(new Ingredient { Item = "Kartoffeln", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            initialList.Add(new Ingredient { Item = "Schinken", Amount = 50, UnitOfMeasurement = UnitOfMeasurement.dag, IsSelected = false });
            initialList.Add(new Ingredient { Item = "Eier", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.Stück, IsSelected = false });
            initialList.Add(new Ingredient { Item = "Pizzateig", Amount = 1, UnitOfMeasurement = UnitOfMeasurement.Pkg, IsSelected = false });
            initialList.Add(new Ingredient { Item = "Reis", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            initialList.Add(new Ingredient { Item = "Wasser", Amount = 5, UnitOfMeasurement = UnitOfMeasurement.l, IsSelected = false });
            initialList.Add(new Ingredient { Item = "Essig", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.Teelöffel, IsSelected = false });
            initialList.Add(new Ingredient { Item = "Salz", Amount = 150, UnitOfMeasurement = UnitOfMeasurement.g, IsSelected = false });
            initialList.Add(new Ingredient { Item = "Mais", Amount = 10, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            initialList.Add(new Ingredient { Item = "Zuccini", Amount = 0.5, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            initialList.Add(new Ingredient { Item = "Zucker", Amount = 12, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            initialList.Add(new Ingredient { Item = "Karotten", Amount = 6, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            initialList.Add(new Ingredient { Item = "Haferflocken", Amount = 7, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            initialList.Add(new Ingredient { Item = "Pasta", Amount = 3, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });

            EinkaufsListe = initialList;

            Edit_Shoppinglist.ItemsSource = EinkaufsListe;

            //using (var dataContext = new DataContext())
            //{
            //    dataContext.RemoveRange(dataContext.Ingredients);
            //    dataContext.Database.ExecuteSqlRaw("delete from sqlite_sequence where name='Ingredients';");
            //    dataContext.Database.ExecuteSqlRaw("delete from sqlite_sequence where name='Recipes';");
            //    dataContext.Ingredients.AddRange(EinkaufsListe);
            //    dataContext.SaveChanges();
            //}
        }
        //Buttons
        private async void EinkaufVerlauf_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EinkaufVerlauf(), true);
        }

        //Methods
        //public ICommand AddIngrediantCommand => new Command(AddIngredient);
        public void AddIngredient()
        {
            if (string.IsNullOrEmpty(ArcticleEntry.Text) || string.IsNullOrEmpty(AmountEntry.Text) || !double.TryParse(AmountEntry.Text, out _amountEntry)) return;
            ArticleEntry = ArcticleEntry.Text;
            EinkaufsListe.Add(new Ingredient { Item = ArticleEntry, Amount = _amountEntry, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
        }

        //public ICommand DeleteSelectedCommand => new Command(DeleteSelcted);
        public void DeleteSelectedItemsButton_Clicked(object sender, EventArgs e)
        {
            for (int i = EinkaufsListe.Count - 1; i >= 0; i--)
            {
                if (EinkaufsListe[i].IsSelected)
                {
                    EinkaufsListe.Remove(EinkaufsListe[i]);
                }
            }
        }

        private void AddIngredientButton_Clicked(object sender, EventArgs e)
        {
            AddIngredient();
        }

        private void DeleteEveryItemButton_Clicked(object sender, EventArgs e)
        {
            EinkaufsListe.Clear();
        }

        private async void Home_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}