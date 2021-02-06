﻿using Microsoft.EntityFrameworkCore;
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
    public partial class EinkaufslisteEdit : ContentPage
    {
        private List<Ingredient> EinkaufsListe = new List<Ingredient>();
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
            List<Ingredient> initialList = new List<Ingredient>();
            initialList.Add(new Ingredient { Item = "Mehl", Amount = 1, UnitOfMeasurement = UnitOfMeasurement.kg, IsInShoppingBasket = false });
            initialList.Add(new Ingredient { Item = "Kartoffeln", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.kg, IsInShoppingBasket = false });
            initialList.Add(new Ingredient { Item = "Schinken", Amount = 50, UnitOfMeasurement = UnitOfMeasurement.dag, IsInShoppingBasket = false });
            initialList.Add(new Ingredient { Item = "Eier", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.Stück, IsInShoppingBasket = false });
            initialList.Add(new Ingredient { Item = "Pizzateig", Amount = 1, UnitOfMeasurement = UnitOfMeasurement.Pkg, IsInShoppingBasket = false });
            initialList.Add(new Ingredient { Item = "Reis", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.kg, IsInShoppingBasket = false });
            initialList.Add(new Ingredient { Item = "Wasser", Amount = 5, UnitOfMeasurement = UnitOfMeasurement.l, IsInShoppingBasket = false });
            initialList.Add(new Ingredient { Item = "Essig", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.Teelöffel, IsInShoppingBasket = false });
            initialList.Add(new Ingredient { Item = "Salz", Amount = 150, UnitOfMeasurement = UnitOfMeasurement.g, IsInShoppingBasket = false });
            initialList.Add(new Ingredient { Item = "Mais", Amount = 10, UnitOfMeasurement = UnitOfMeasurement.kg, IsInShoppingBasket = false });
            initialList.Add(new Ingredient { Item = "Zuccini", Amount = 0.5, UnitOfMeasurement = UnitOfMeasurement.kg, IsInShoppingBasket = false });
            initialList.Add(new Ingredient { Item = "Zucker", Amount = 12, UnitOfMeasurement = UnitOfMeasurement.kg, IsInShoppingBasket = false });
            initialList.Add(new Ingredient { Item = "Karotten", Amount = 6, UnitOfMeasurement = UnitOfMeasurement.kg, IsInShoppingBasket = false });
            initialList.Add(new Ingredient { Item = "Haferflocken", Amount = 7, UnitOfMeasurement = UnitOfMeasurement.kg, IsInShoppingBasket = false });
            initialList.Add(new Ingredient { Item = "Pasta", Amount = 3, UnitOfMeasurement = UnitOfMeasurement.kg, IsInShoppingBasket = false });

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


    }
}