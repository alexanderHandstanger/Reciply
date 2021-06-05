using Reciply.Models;
using Reciply.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace Reciply
{
    public partial class MainPage : ContentPage //currently finished
    {
        public ObservableCollection<Ingredient> EinkaufsListe = new ObservableCollection<Ingredient>();
        private ObservableCollection<Recipe> SelectedRecipes = new ObservableCollection<Recipe>();
        private ObservableCollection<Ingredient> ShoppedItems = new ObservableCollection<Ingredient>();
        private bool Shopped;

        private static MainPage _instance;
        public static MainPage PageInstance
        {
            get
            {
                return _instance;
            }
        }

        public MainPage()
        {
            _instance = this;
            InitializeComponent();
            InitialSelectedRecipes();
            Initials();
            Einkaufsliste.ItemsSource = EinkaufsListe;
            //using (var dataContext = new DataContext())
            //{
            //    var ingredientsWithKg = dataContext.Ingredients
            //        .Where(i => i.UnitOfMeasurement == UnitOfMeasurement.kg)
            //        .ToList();    
            //}
        }

        public void Initials()
        {
            EinkaufsListe.Add(new Ingredient { Item = "Mehl", Amount = 1, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            EinkaufsListe.Add(new Ingredient { Item = "Kartoffeln", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            EinkaufsListe.Add(new Ingredient { Item = "Schinken", Amount = 50, UnitOfMeasurement = UnitOfMeasurement.dag, IsSelected = false });
            EinkaufsListe.Add(new Ingredient { Item = "Eier", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.Stück, IsSelected = false });
            EinkaufsListe.Add(new Ingredient { Item = "Pizzateig", Amount = 1, UnitOfMeasurement = UnitOfMeasurement.Pkg, IsSelected = false });
            EinkaufsListe.Add(new Ingredient { Item = "Reis", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            EinkaufsListe.Add(new Ingredient { Item = "Wasser", Amount = 5, UnitOfMeasurement = UnitOfMeasurement.l, IsSelected = false });
            EinkaufsListe.Add(new Ingredient { Item = "Essig", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.Teelöffel, IsSelected = false });
            EinkaufsListe.Add(new Ingredient { Item = "Salz", Amount = 150, UnitOfMeasurement = UnitOfMeasurement.g, IsSelected = false });
            EinkaufsListe.Add(new Ingredient { Item = "Mais", Amount = 10, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            EinkaufsListe.Add(new Ingredient { Item = "Zuccini", Amount = 0.5, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            EinkaufsListe.Add(new Ingredient { Item = "Zucker", Amount = 12, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            EinkaufsListe.Add(new Ingredient { Item = "Karotten", Amount = 6, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            EinkaufsListe.Add(new Ingredient { Item = "Haferflocken", Amount = 7, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            EinkaufsListe.Add(new Ingredient { Item = "Pasta", Amount = 3, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            //using (var dataContext = new DataContext())
            //{
            //    dataContext.RemoveRange(dataContext.Ingredients);
            //    dataContext.Database.ExecuteSqlRaw("delete from sqlite_sequence where name='Ingredients';");
            //    dataContext.Database.ExecuteSqlRaw("delete from sqlite_sequence where name='Recipes';");
            //    dataContext.Ingredients.AddRange(initialsList);
            //    dataContext.SaveChanges();
            //}
        }

        public void InitialSelectedRecipes()
        {
            //Demo Data for testing
            List<Ingredient> ingredients = new List<Ingredient>();
            ingredients.Add(new Ingredient { Item = "Mehl", Amount = 1, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Kartoffeln", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Schinken", Amount = 50, UnitOfMeasurement = UnitOfMeasurement.dag, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Eier", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.Stück, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Pizzateig", Amount = 1, UnitOfMeasurement = UnitOfMeasurement.Pkg, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Reis", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Wasser", Amount = 5, UnitOfMeasurement = UnitOfMeasurement.l, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Essig", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.Teelöffel, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Salz", Amount = 150, UnitOfMeasurement = UnitOfMeasurement.g, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Mais", Amount = 10, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Zuccini", Amount = 0.5, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Zucker", Amount = 12, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Karotten", Amount = 6, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Haferflocken", Amount = 7, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Pasta", Amount = 3, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });

            SelectedRecipes.Add(new Recipe { Id = 1, Description = "Ein supergeiles Gericht", Duration = 3, Name = "5 Minutenkuche", Portion = 4, Rating = 3, Preparation = "Einfach Mixen", Tags = "#Kuchen, #Schnell", Ingredient = ingredients });

            ingredients.Clear();
            ingredients.Add(new Ingredient { Item = "Mehl", Amount = 1, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Kartoffeln", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Schinken", Amount = 50, UnitOfMeasurement = UnitOfMeasurement.dag, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Eier", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.Stück, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Pizzateig", Amount = 1, UnitOfMeasurement = UnitOfMeasurement.Pkg, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Reis", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Wasser", Amount = 5, UnitOfMeasurement = UnitOfMeasurement.l, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Essig", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.Teelöffel, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Salz", Amount = 150, UnitOfMeasurement = UnitOfMeasurement.g, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Mais", Amount = 10, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Zuccini", Amount = 0.5, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Zucker", Amount = 12, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Karotten", Amount = 6, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Haferflocken", Amount = 7, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            ingredients.Add(new Ingredient { Item = "Pasta", Amount = 3, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });

            SelectedRecipes.Add(new Recipe { Id = 2, Description = "Leckere Gemüsesuppe", Duration = 3, Name = "Würzige Suppe", Portion = 4, Rating = 3, Preparation = "Bissi herschneiden und so", Tags = "#Kuchen, #Schnell", Ingredient = ingredients });
            SelectedRecipe.ItemsSource = SelectedRecipes;
        }

        //Navigation
        private async void RecipeButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Recipes(), true);
        }

        private async void EinkaufVerlauf_Clicked(object sender, EventArgs e)
        {
            if (Shopped)
            {
                await Navigation.PushAsync(new EinkaufVerlauf(ShoppedItems, DateTime.Now), true);
            }
            else
            {
                await Navigation.PushAsync(new EinkaufVerlauf(), true);
            }         
        }

        private async void ButtonClicked_JetztKochen(object sender, EventArgs e)
        {
            var selectedObject = ((Button)sender).CommandParameter;
            int selectedItemId = int.Parse(string.Format("{0}", selectedObject));
            Recipe selectedItem = SelectedRecipes.Where(x => x.Id == selectedItemId).FirstOrDefault();

            await Navigation.PushAsync(new CookRecipeIngredients(selectedItem), true);
        }

        private async void Einkaufsliste_Edit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EinkaufslisteEdit(EinkaufsListe), true);
        }

        private async void Einkaufsliste_Share_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Test_AddRecipes(), true);
        }

        //Other
        private void SelectedRecipes_Clicked(object sender, EventArgs e)
        {
            SelectedRecipe.IsVisible = !SelectedRecipe.IsVisible;
        }

        private async void Home_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        public void ConfimPurchase_Button_Clicked(object sender, EventArgs e)
        {
            for (int i = EinkaufsListe.Count - 1; i >= 0; i--)
            {
                if (EinkaufsListe[i].IsSelected)
                {
                    ShoppedItems.Add(EinkaufsListe[i]);
                    EinkaufsListe.Remove(EinkaufsListe[i]);
                    Shopped = true;
                }
            }     
        }

        private async void SettingsClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage(), true);
        }
    }
}