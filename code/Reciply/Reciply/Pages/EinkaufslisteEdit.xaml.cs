using Reciply.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reciply.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EinkaufslisteEdit : ContentPage
    {
        public ObservableCollection<Ingredient> EinkaufsListe = new ObservableCollection<Ingredient>();

        public string ArticleEntry { get; set; }

        private double _amountEntry;
        public EinkaufslisteEdit()
        {
            InitializeComponent();
            EinkaufsListe = MainPage.PageInstance.EinkaufsListe;
            Edit_Shoppinglist.ItemsSource = EinkaufsListe;
        }

        //Buttons
        private async void EinkaufVerlauf_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EinkaufVerlauf(), true);
        }

        //Methods
        public void AddIngredient()
        {
            if (string.IsNullOrEmpty(ArcticleEntry.Text) || string.IsNullOrEmpty(AmountEntry.Text) || !double.TryParse(AmountEntry.Text, out _amountEntry)) return;
            ArticleEntry = ArcticleEntry.Text;
            EinkaufsListe.Add(new Ingredient { Item = ArticleEntry, Amount = _amountEntry, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });

            MainPage.PageInstance.SaveJson(MainPage.PageInstance.FilePathForShoppingList, EinkaufsListe);
        }

        public void DeleteSelectedItemsButton_Clicked(object sender, EventArgs e)
        {
            for (int i = EinkaufsListe.Count - 1; i >= 0; i--)
            {
                if (EinkaufsListe[i].IsSelected)
                {
                    EinkaufsListe.Remove(EinkaufsListe[i]);
                }
            }

            MainPage.PageInstance.SaveJson(MainPage.PageInstance.FilePathForShoppingList, EinkaufsListe);
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