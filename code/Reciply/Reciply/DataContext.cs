using Microsoft.EntityFrameworkCore;
using Reciply.Models;
using System;
using System.IO;
using Xamarin.Essentials;

namespace Reciply
{
    class DataContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }

        public DbSet<Ingredient> Ingredients { get; set; }

        public DataContext()
        {
            SQLitePCL.Batteries_V2.Init();

            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "test.db3");

            optionsBuilder
                .UseSqlite($"Filename={dbPath}");
        }
    }
}
