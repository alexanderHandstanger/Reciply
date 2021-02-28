﻿using Microsoft.EntityFrameworkCore;
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
        public List<Ingredient> EinkaufsListe = new List<Ingredient>();

        //List<Ingredient> initialList = new List<Ingredient>();

        public string articleEntry { get; set; }
        public double amountEntry { get; set; }
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

            EinkaufsListe.AddRange(initialList);

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
        public ICommand AddIngrediantCommand => new Command(AddIngrdiants);
        public void AddIngrdiants()
        {
            EinkaufsListe.Add(new Ingredient { Item = articleEntry, Amount = amountEntry, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
        }

        //public ICommand DeleteSelectedCommand => new Command(DeleteSelcted);
        public void DeleteSelcted(object sender, EventArgs e)
        {
            foreach (var ingrediant in EinkaufsListe)
            {
                if (ingrediant.IsSelected == true)
                {
                    EinkaufsListe.Remove(ingrediant);
                }
            }
        }


    }
}