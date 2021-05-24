using Reciply.Models;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reciply.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EinkaufVerlauf : ContentPage
    {
        private ObservableCollection<ObservableCollection<Ingredient>> AllLastShoppedItems = new ObservableCollection<ObservableCollection<Ingredient>>();
        private int LastShoppedItemsId;
        public EinkaufVerlauf()
        {
            InitializeComponent();
            Initials();

            LastShoppedItemsId = AllLastShoppedItems.Count;
            Date.Text = Convert.ToString("Test");
            LastShoppingList.ItemsSource = AllLastShoppedItems[LastShoppedItemsId - 1];
        }

        public EinkaufVerlauf(ObservableCollection<Ingredient> shoppedItems, DateTime shoppedDate)
        {
            InitializeComponent();

            foreach (var Ingredient in shoppedItems)
            {
                Ingredient.IsSelected = false;
            }

            Initials();
            AllLastShoppedItems.Add(shoppedItems);
            LastShoppedItemsId = AllLastShoppedItems.Count;
            Date.Text = Convert.ToString(shoppedDate);
            LastShoppingList.ItemsSource = AllLastShoppedItems[LastShoppedItemsId - 1];
        }

        public void Initials()
        {
            ObservableCollection<Ingredient> lastLastShoppedItems = new ObservableCollection<Ingredient>();
            lastLastShoppedItems.Add(new Ingredient { Item = "Mehl", Amount = 1, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            lastLastShoppedItems.Add(new Ingredient { Item = "Kartoffeln", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            lastLastShoppedItems.Add(new Ingredient { Item = "Schinken", Amount = 50, UnitOfMeasurement = UnitOfMeasurement.dag, IsSelected = false });
            lastLastShoppedItems.Add(new Ingredient { Item = "Eier", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.Stück, IsSelected = false });
            lastLastShoppedItems.Add(new Ingredient { Item = "Pizzateig", Amount = 1, UnitOfMeasurement = UnitOfMeasurement.Pkg, IsSelected = false });
            lastLastShoppedItems.Add(new Ingredient { Item = "Reis", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            lastLastShoppedItems.Add(new Ingredient { Item = "Wasser", Amount = 5, UnitOfMeasurement = UnitOfMeasurement.l, IsSelected = false });
            lastLastShoppedItems.Add(new Ingredient { Item = "Essig", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.Teelöffel, IsSelected = false });
            lastLastShoppedItems.Add(new Ingredient { Item = "Salz", Amount = 150, UnitOfMeasurement = UnitOfMeasurement.g, IsSelected = false });
            lastLastShoppedItems.Add(new Ingredient { Item = "Mais", Amount = 10, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            lastLastShoppedItems.Add(new Ingredient { Item = "Zuccini", Amount = 0.5, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            lastLastShoppedItems.Add(new Ingredient { Item = "Zucker", Amount = 12, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            lastLastShoppedItems.Add(new Ingredient { Item = "Karotten", Amount = 6, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            lastLastShoppedItems.Add(new Ingredient { Item = "Haferflocken", Amount = 7, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            lastLastShoppedItems.Add(new Ingredient { Item = "Pasta", Amount = 3, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });

            AllLastShoppedItems.Add(lastLastShoppedItems);
        }

        private async void Home_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private async void TakeOverSelected_Button_Clicked(object sender, EventArgs e)
        {
            foreach (var Ingredient in AllLastShoppedItems[LastShoppedItemsId - 1])
            {
                if (Ingredient.IsSelected)
                {
                    MainPage.PageInstance.EinkaufsListe.Add(Ingredient);
                    Ingredient.IsSelected = false;
                }
            }
            await Navigation.PopAsync();
        }

        private async void TakeOverEverything_Button_Clicked(object sender, EventArgs e)
        {
            foreach (var Ingredient in AllLastShoppedItems[LastShoppedItemsId - 1])
            {
                MainPage.PageInstance.EinkaufsListe.Add(Ingredient);
                Ingredient.IsSelected = false;
            }
            await Navigation.PopAsync();
        }
    }
}