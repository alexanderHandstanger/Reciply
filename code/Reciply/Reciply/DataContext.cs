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

        //Currently the DB is running locally on the phone
        public DataContext()
        {
            Database.Migrate();
            Database.EnsureCreated();
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Ingredient>()
        //        .HasOne(p => p.Recipe)
        //        .WithMany(b => b.Ingredient)
        //        .OnDelete(DeleteBehavior.Cascade);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //If the data in the tables change, rename the xxx.db3 file differently to create a new "migration"
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "test9.db3");
            string connectionString = "Server=;Database=reciply;Port=3306;Uid=;Pwd=;";
            optionsBuilder
                .UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
    }
}
