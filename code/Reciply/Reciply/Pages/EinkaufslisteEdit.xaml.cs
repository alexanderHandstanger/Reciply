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
        //List<Ingredient> initialList = new List<Ingredient>();

        public string ArticleEntry { get; set; }

        private double _amountEntry;
        public EinkaufslisteEdit(ObservableCollection<Ingredient> einkaufsliste)
        {
            InitializeComponent();
            EinkaufsListe = einkaufsliste;
            Edit_Shoppinglist.ItemsSource = EinkaufsListe;

            //using (var dataContext = new DataContext())
            //{
            //    var ingredientsWithKg = dataContext.Ingredients
            //        .Where(i => i.UnitOfMeasurement == UnitOfMeasurement.kg)
            //        .ToList();
            //    EinkaufsListe.AddRange(ingredientsWithKg);
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

            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Einkaufsliste.json");
            MainPage.PageInstance.SaveJson(filePath, EinkaufsListe);
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

            string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Einkaufsliste.json");
            MainPage.PageInstance.SaveJson(filePath, EinkaufsListe);
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