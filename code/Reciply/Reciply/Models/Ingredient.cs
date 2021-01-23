using System;
using System.Collections.Generic;
using System.Text;

namespace Reciply.Models
{
    public class Ingredient
    {
        public string item { get; set; } //Name des zu einkaufenden Gegenstandes (z.B. Mehl)
        public int amount { get; set; } //Wie viel davon einzukaufen ist (z.B. 1{kg})
        public UnitOfMeasurement unitOfMeasurement { get; set; } //Die Einheit von amount (z.B. kg,ml,l,...)
        public bool isInShoppingBasket { get; set; } //True = Wenn der Gegenstand in der Einkaufsliste abgehakt ist (im Einkaufskorb), False = Wenn nicht
    }
}
