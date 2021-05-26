using Reciply.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reciply.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EinkaufVerlauf : ContentPage
    {
        private ObservableCollection<ShoppedIngredient> ShoppedItems = new ObservableCollection<ShoppedIngredient>();
        private int ActualShoppedItemsId;

        public EinkaufVerlauf()
        {
            InitializeComponent();
            ShoppedItems = MainPage.PageInstance.ReadJson<ShoppedIngredient>(MainPage.PageInstance.FilePathForShoppedList) as ObservableCollection<ShoppedIngredient>;
            if (ShoppedItems == null)
            {
                ShoppedItems = new ObservableCollection<ShoppedIngredient>();
            }

            if (ShoppedItems.Count > 0)
            {
                ActualShoppedItemsId = ShoppedItems.Count - 1;
                Date.Text = Convert.ToString(ShoppedItems[ActualShoppedItemsId].Time);
                LastShoppingList.ItemsSource = ShoppedItems[ActualShoppedItemsId].Ingredients;
            }
            else
            {
                DisplayAlert("", "Noch keine Einkäufe getätigt.", "OK");
                Date.Text = "Noch keine Einkäufe getätigt.";
            }
        }

        public EinkaufVerlauf(ObservableCollection<Ingredient> shoppedItems, DateTime shoppedDate)
        {
            InitializeComponent();
            
            ShoppedItems = MainPage.PageInstance.ReadJson<ShoppedIngredient>(MainPage.PageInstance.FilePathForShoppedList) as ObservableCollection<ShoppedIngredient>;
            if (ShoppedItems == null)
            {
                ShoppedItems = new ObservableCollection<ShoppedIngredient>();
            }

            //Generate newest LastShoppedItems
            ShoppedIngredient lastShoppedItems = new ShoppedIngredient();
            lastShoppedItems.Ingredients = new List<Ingredient>();
            foreach (var ingredient in shoppedItems)
            {
                ingredient.IsSelected = false;
                lastShoppedItems.Ingredients.Add(ingredient);
            }
            lastShoppedItems.Time = shoppedDate;
            ShoppedItems.Add(lastShoppedItems);
            MainPage.PageInstance.SaveJson(MainPage.PageInstance.FilePathForShoppedList, ShoppedItems);
            
            ActualShoppedItemsId = ShoppedItems.Count - 1;
            Date.Text = Convert.ToString(ShoppedItems[ActualShoppedItemsId].Time);
            LastShoppingList.ItemsSource = ShoppedItems[ActualShoppedItemsId].Ingredients;
        }

        private async void Home_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private async void TakeOverSelected_Button_Clicked(object sender, EventArgs e)
        {
            if (ShoppedItems.Count > 0)
            {
                foreach (var Ingredient in ShoppedItems[ActualShoppedItemsId].Ingredients)
                {
                    if (Ingredient.IsSelected)
                    {
                        MainPage.PageInstance.EinkaufsListe.Add(Ingredient);
                        Ingredient.IsSelected = false;
                    }
                }
                MainPage.PageInstance.SaveJson(MainPage.PageInstance.FilePathForShoppingList, MainPage.PageInstance.EinkaufsListe);
                await DisplayAlert("Erfolg", "Zutaten erfolgreich auf die Einkaufsliste gesetzt", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Fehler", "Error", "OK");
            }
        }

        private async void TakeOverEverything_Button_Clicked(object sender, EventArgs e)
        {
            if (ShoppedItems.Count > 0)
            {
                foreach (var Ingredient in ShoppedItems[ActualShoppedItemsId].Ingredients)
                {
                    MainPage.PageInstance.EinkaufsListe.Add(Ingredient);
                    Ingredient.IsSelected = false;
                }
                MainPage.PageInstance.SaveJson(MainPage.PageInstance.FilePathForShoppingList, MainPage.PageInstance.EinkaufsListe);
                await DisplayAlert("Erfolg", "Zutaten erfolgreich auf die Einkaufsliste gesetzt", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Fehler", "Error", "OK");
            }
        }

        private void Past_Button_Clicked(object sender, EventArgs e)
        {
            if (ActualShoppedItemsId > 0)
            {
                ActualShoppedItemsId--;
                LastShoppingList.ItemsSource = ShoppedItems[ActualShoppedItemsId].Ingredients;
                Date.Text = Convert.ToString(ShoppedItems[ActualShoppedItemsId].Time);
            }
        }

        private void Future_Button_Clicked(object sender, EventArgs e)
        {
            if (ActualShoppedItemsId < ShoppedItems.Count - 1)
            {
                ActualShoppedItemsId++;
                LastShoppingList.ItemsSource = ShoppedItems[ActualShoppedItemsId].Ingredients;
                Date.Text = Convert.ToString(ShoppedItems[ActualShoppedItemsId].Time);
            }
        }
    }
}