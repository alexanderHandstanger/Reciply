using Reciply.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Reciply.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EinkaufslisteEdit : ContentPage
    {
        public ObservableCollection<Ingredient> EinkaufsListe = new ObservableCollection<Ingredient>();

        public EinkaufslisteEdit()
        {
            InitializeComponent();
            EinkaufsListe = MainPage.PageInstance.EinkaufsListe;
            Edit_Shoppinglist.ItemsSource = EinkaufsListe;
        }

        //Methods
        public static string RemoveSpaces(string input)
        {
            return new string(input.ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray());
        }

        public async void AddIngredient()
        {
            if (!string.IsNullOrEmpty(ArcticleEntry.Text) && !string.IsNullOrEmpty(AmountEntry.Text) && double.TryParse(AmountEntry.Text, out double amount) && einheit.SelectedItem != null)
            {
                if (EinkaufsListe == null)
                {
                    EinkaufsListe = new ObservableCollection<Ingredient>();
                }
                UnitOfMeasurement unit = (UnitOfMeasurement)Enum.Parse(typeof(UnitOfMeasurement), einheit.SelectedItem.ToString());
                ArcticleEntry.Text = RemoveSpaces(ArcticleEntry.Text);
                AmountEntry.Text = RemoveSpaces(AmountEntry.Text);

                MainPage.PageInstance.AddToShoppingList(new Ingredient { Item = ArcticleEntry.Text, Amount = Convert.ToDouble(AmountEntry.Text), UnitOfMeasurement = unit, IsSelected = false });
                MainPage.PageInstance.SaveJson(MainPage.PageInstance.FilePathForShoppingList, EinkaufsListe);
            }
            else
            {
                await DisplayAlert("Fehler", "Ungültige Eingabe!", "OK");
            }
        }

        //Buttons
        private async void EinkaufVerlauf_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EinkaufVerlauf(), true);
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

            MainPage.PageInstance.SaveJson(MainPage.PageInstance.FilePathForShoppingList, EinkaufsListe);
        }

        private void AddIngredientButton_Clicked(object sender, EventArgs e)
        {
            AddIngredient();
            ArcticleEntry.Text = "";
            AmountEntry.Text = "";
            einheit.SelectedItem = einheit.Title;
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