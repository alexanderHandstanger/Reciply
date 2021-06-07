using Microsoft.EntityFrameworkCore;
using Reciply.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms.Xaml;
using Syncfusion.Pdf;
using System.IO;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Drawing;
using Xamarin.Essentials;
using Xamarin.Forms;
using Plugin.XamarinFormsSaveOpenPDFPackage;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Reciply.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Test_AddRecipes : ContentPage
    {
        public Test_AddRecipes()
        {
            InitializeComponent();
        }

        public static void AddRecipes()
        {
            var recipes = new List<Recipe>()
            {
                new Recipe()
                {
                    Ingredient = new List<Ingredient>()
                    {
                        new Ingredient { Item = "Mehl", Amount = 150, UnitOfMeasurement = UnitOfMeasurement.g, IsSelected = false },
                        new Ingredient { Item = "Milch", Amount = 150, UnitOfMeasurement = UnitOfMeasurement.ml, IsSelected = false },
                        new Ingredient { Item = "Ei", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.Stück, IsSelected = false },
                        new Ingredient { Item = "Salz", Amount = 1, UnitOfMeasurement = UnitOfMeasurement.Prise, IsSelected = false },
                        new Ingredient { Item = "Butter oder Öl in der Pfanne", Amount = 1, UnitOfMeasurement = UnitOfMeasurement.Esslöffel, IsSelected = false },
                        new Ingredient { Item = "Backpulver", Amount = 0.5, UnitOfMeasurement = UnitOfMeasurement.Pkg, IsSelected = false }

                    },
                    Duration = 20,
                    Name = "Pancakes",
                    Portion = 2,
                    Rating = 4,
                    Tags = "#pancakes",
                    Description = "Pancakes sind ein beliebtes Frühstück in Nordamerika und werden dort mit Butter und Ahornsirup oder mit Speck gegessen. Ein flaumiges Rezept.",
                    Preparation = "Für die köstlichen Pancakes zuerst die Eier trennen. Danach das Eigelb, Mehl, Backpulver, Zucker, Salz und einen Schuss Milch in einer Schüssel zu einem zähflüssigen Teig verrühren. " +
                    "Nun das Eiklar steif schlagen und unter die Teigmasse heben, sodass eine cremige Masse entsteht. Wenn der Teig zu fest ist, einfach noch ein wenig Milch hinzufügen. " +
                    "Dann Butter (oder Öl) in eine kleine Pfanne geben, mit einem Pinsel schön verteilen und heiß werden lassen. " +
                    "Den Teig portionsweise (mit einem Suppenschöpfer) in die Pfanne geben und auf jeder Seite 2-3 Minuten goldbraun backen.Traditionell serviert man die fertigen Pancakes mit flüssiger Butter und/oder Ahornsirup oder auch frischen Früchten."
                },
                new Recipe()
                {
                    Ingredient = new List<Ingredient>()
                    {
                        new Ingredient { Item = "Zucker", Amount = 75, UnitOfMeasurement = UnitOfMeasurement.g, IsSelected = false,  },
                        new Ingredient { Item = "Butter (weich)", Amount = 125, UnitOfMeasurement = UnitOfMeasurement.g, IsSelected = false },
                        new Ingredient { Item = "Vanillezucker", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.Pkg, IsSelected = false },
                        new Ingredient { Item = "Mehl", Amount = 250, UnitOfMeasurement = UnitOfMeasurement.g, IsSelected = false },
                        new Ingredient { Item = "Salz", Amount = 1, UnitOfMeasurement = UnitOfMeasurement.Prise, IsSelected = false },
                        new Ingredient { Item = "Ei", Amount = 1, UnitOfMeasurement = UnitOfMeasurement.Stück, IsSelected = false }

                    },
                    Duration = 90,
                    Name = "Vanille Kekse",
                    Portion = 2,
                    Rating = 4,
                    Tags = "#vanille #kekse",
                    Description = "Vanille Kekse schmecken besonders in der Weihnachtszeit. Ein Rezept, wenn ihre Kinder backen wollen.",
                    Preparation = "Für die einfachen Vanille Kekse alle Zutaten auf einer Arbeitsfläche zu einem glatten Teig verkneten. Dann in eine Frischhaltefolie wickeln und für eine Stunde in den Kühlschrank stellen. Das Backrohr auf 200 Grad Ober-/Unterhitze vorheizen und ein Backblech mit Backpapier auslegen. Den Teig auf einer bemehlten Arbeitsfläche ausrollen und nach beliebigen Formen Kekse ausstechen. Die Kekse auf das Backblech legen und für 10 Minuten in Backrohr hellgelb backen."
                },
                new Recipe()
                {
                    Ingredient = new List<Ingredient>()
                    {
                        new Ingredient { Item = "Kartoffeln, festkochende", Amount = 75, UnitOfMeasurement = UnitOfMeasurement.g, IsSelected = false },
                        new Ingredient { Item = "Salz", Amount = 1, UnitOfMeasurement = UnitOfMeasurement.Prise, IsSelected = false },
                        new Ingredient { Item = "Pfeffer", Amount = 1, UnitOfMeasurement = UnitOfMeasurement.Prise, IsSelected = false },
                        new Ingredient { Item = "Eier", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.Stück, IsSelected = false },
                        new Ingredient { Item = "Mehl", Amount = 3, UnitOfMeasurement = UnitOfMeasurement.Esslöffel, IsSelected = false },
                        new Ingredient { Item = "Öl", Amount = 10, UnitOfMeasurement = UnitOfMeasurement.Esslöffel, IsSelected = false },
                        new Ingredient { Item = "Zwiebel", Amount = 1, UnitOfMeasurement = UnitOfMeasurement.Stück, IsSelected = false }

                    },
                    Duration = 30,
                    Name = "Kartoffelpuffer",
                    Portion = 4,
                    Rating = 5,
                    Tags = "#kartoffeln #puffer",
                    Description = "Kartoffelpuffer sind eine köstliche und einfache Sache und passen eigentlich fast immer.",
                    Preparation = "Kartoffelpuffer kennen die meisten von uns schon aus unseren Kindheitstagen. Zuerst schält man die Zwiebel und die Kartoffeln und dann reibt man sie mit einer Reibe - nicht zu fein aber auch nicht zu grob. Das Ganze kommt danach in eine große Schüssel, wo die Eier, das Mehl, das Salz und der Pfeffer hinzu kommen. Alles wird mit den Händen gut durchgeknetet. Wenn die Kartoffeln nicht sofort verarbeitet werden, empfiehlt es sich, sie vorher auszudrücken, da sie sehr viel Wasser verlieren - allzu lange sollten sie dennoch trotzdem nicht stehen. Nun wird in einer Pfanne Öl erhitzt. Mit einem Schöpfer gibt man immer zirka eineinhalb Schöpfer Klecks in die Pfanne und brät ihn von beiden Seiten goldbraun an."

                },
                new Recipe()
                {
                    Ingredient = new List<Ingredient>()
                    {
                        new Ingredient { Item = "Dotter", Amount = 4, UnitOfMeasurement = UnitOfMeasurement.Stück },
                        new Ingredient { Item = "Zucker", Amount = 25, UnitOfMeasurement = UnitOfMeasurement.dag },
                        new Ingredient { Item = "Mehl", Amount = 25, UnitOfMeasurement = UnitOfMeasurement.dag },
                        new Ingredient { Item = "Wasser", Amount = 125, UnitOfMeasurement = UnitOfMeasurement.ml },
                        new Ingredient { Item = "Öl", Amount = 125, UnitOfMeasurement = UnitOfMeasurement.ml },
                        new Ingredient { Item = "Vanillies", Amount = 18, UnitOfMeasurement = UnitOfMeasurement.Stück },
                        new Ingredient { Item = "Backpulver", Amount = 0.5, UnitOfMeasurement = UnitOfMeasurement.Pkg },
                        new Ingredient { Item = "Kakau", Amount = 10, UnitOfMeasurement = UnitOfMeasurement.Esslöffel }

                    },
                    Duration = 25,
                    Name = "Gulasch",
                    Portion = 4,
                    Rating = 5,
                    Tags = "#Pasta",
                    Description = "Leckeres Nudelgericht",
                    Preparation = "Die Zwiebel schälen und in Ringe schneiden. Die gekochten Kartoffel schälen und in Scheiben schneiden. Das Backrohr auf 180° vorheizen.Eine Gratinform mit Butter einstreichen und schichtweise Kartoffel und Zwiebel hineingeben.Jede Schicht mit Salz,Pfeffer und Kümmel würzen.Die oberste Schicht mit Kartoffel abschließen.Den Schlagobers mit Creme Fraiche mischen und darübergießen. 40 Minuten im vorgeheizten Backrohr,Heißluft überbacken."

                }
            };
            using (var dataContext = new DataContext())
            {
                dataContext.RemoveRange(dataContext.Recipes);
                dataContext.Recipes.AddRange(recipes);
                dataContext.SaveChanges();
            }
        }

        private async void Add_Recipes_Button_Clicked(object sender, EventArgs e)
        {
            AddRecipes();
            //Create a new PDF document.
            PdfDocument document = new PdfDocument();
            //Add a page to the document.
            PdfPage page = document.Pages.Add();
            //Create PDF graphics for the page.
            PdfGraphics graphics = page.Graphics;
            //Set the standard font.
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);
            //Draw the text.
            using var dataContext = new DataContext();
            var str = "";
            foreach (var item in dataContext.Recipes.Include(x => x.Ingredient))
            {
                str += $"{item.Name}\n";
                foreach (var ingredient in item.Ingredient)
                {
                    str += $"=> {ingredient.Item}: {ingredient.Amount} {ingredient.UnitOfMeasurement}\n";
                }
            }
            graphics.DrawString("EinkaufsListe\n" + str, font, PdfBrushes.Black, new PointF(0, 0));
            graphics.Flush();
            var stream = new MemoryStream();
            //Save the document.
            document.Save(stream);
            //Close the document.
            document.Close(true);
            //Open the pdf
            await CrossXamarinFormsSaveOpenPDFPackage.Current.SaveAndView("Einkaufsliste.pdf", "application/pdf", stream, PDFOpenContext.InApp);
            //Close the stream
            stream.Close();
        }

        private async void Home_Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        private void JsonFileShoppingListGenerate_Button_Clicked(object sender, EventArgs e)
        {
            ObservableCollection<Ingredient> shoppingList = new ObservableCollection<Ingredient>();
            shoppingList.Add(new Ingredient { Item = "Mehl", Amount = 1, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            shoppingList.Add(new Ingredient { Item = "Kartoffeln", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            shoppingList.Add(new Ingredient { Item = "Schinken", Amount = 50, UnitOfMeasurement = UnitOfMeasurement.dag, IsSelected = false });
            shoppingList.Add(new Ingredient { Item = "Eier", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.Stück, IsSelected = false });
            shoppingList.Add(new Ingredient { Item = "Pizzateig", Amount = 1, UnitOfMeasurement = UnitOfMeasurement.Pkg, IsSelected = false });
            shoppingList.Add(new Ingredient { Item = "Reis", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            shoppingList.Add(new Ingredient { Item = "Wasser", Amount = 5, UnitOfMeasurement = UnitOfMeasurement.l, IsSelected = false });
            shoppingList.Add(new Ingredient { Item = "Essig", Amount = 2, UnitOfMeasurement = UnitOfMeasurement.Teelöffel, IsSelected = false });
            shoppingList.Add(new Ingredient { Item = "Salz", Amount = 150, UnitOfMeasurement = UnitOfMeasurement.g, IsSelected = false });
            shoppingList.Add(new Ingredient { Item = "Mais", Amount = 10, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            shoppingList.Add(new Ingredient { Item = "Zuccini", Amount = 0.5, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            shoppingList.Add(new Ingredient { Item = "Zucker", Amount = 12, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            shoppingList.Add(new Ingredient { Item = "Karotten", Amount = 6, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            shoppingList.Add(new Ingredient { Item = "Haferflocken", Amount = 7, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });
            shoppingList.Add(new Ingredient { Item = "Pasta", Amount = 3, UnitOfMeasurement = UnitOfMeasurement.kg, IsSelected = false });

            MainPage.PageInstance.SaveJson(MainPage.PageInstance.FilePathForShoppingList, shoppingList);
        }

        private void JsonFileSelectedRecipesGenerate_Button_Clicked(object sender, EventArgs e)
        {
            ObservableCollection<Recipe> SelectedRecipes = new ObservableCollection<Recipe>();

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

            MainPage.PageInstance.SaveJson(MainPage.PageInstance.FilePathForSelectedRecipes, SelectedRecipes);
        }

        private void DeleteJsonButton_Clicked(object sender, EventArgs e)
        {
            MainPage.PageInstance.EinkaufsListe = null;
            MainPage.PageInstance.SelectedRecipes = null;
            File.Delete(MainPage.PageInstance.FilePathForShoppingList);
            File.Delete(MainPage.PageInstance.FilePathForSelectedRecipes);
            File.Delete(MainPage.PageInstance.FilePathForShoppedList);
        }
    }
}