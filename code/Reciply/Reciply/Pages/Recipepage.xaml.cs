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
    public partial class Recipepage : ContentPage
    {
        public Recipepage()
        {
            InitializeComponent();
            var recipe = Initials();
            ingredients.ItemsSource = recipe.Ingredient;
            BindingContext = recipe;
        }

        private Recipe Initials()
        {
            using var dataContext = new DataContext();
            return dataContext.Recipes.Include(x => x.Ingredient).FirstOrDefault();
        }
    }
}