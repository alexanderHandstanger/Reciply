using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Reciply.Models
{
    public class Ingredient : INotifyPropertyChanged
    {
        public int Id { get; set; } //Primary Key
        public Recipe Recipe { get; set; } //The recipe 1/n
        public int RecipeId { get; set; } //Foreign Key
        public string Item { get; set; } //Name des zu einkaufenden Gegenstandes (z.B. Mehl)
        private double amount;
        public double Amount
        {
            get => amount;
            set
            {
                amount = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Amount)));
            }
        } //Wie viel davon einzukaufen ist (z.B. 1{kg})
        public UnitOfMeasurement UnitOfMeasurement { get; set; } //Die Einheit von amount (z.B. kg,ml,l,...)
        public bool IsSelected { get; set; } //True = Wenn der Gegenstand in der Einkaufsliste abgehakt ist (im Einkaufskorb), False = Wenn nicht

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
