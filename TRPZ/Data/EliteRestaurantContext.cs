using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace TRPZ.Data
{
    public class EliteRestaurantContext : DbContext
    {
        public DbSet<DishEntity> Dishes { get; set; }
        public DbSet<CookEntity> Cooks { get; set; }
        public DbSet<CuisineTypeEntity> CuisineTypes { get; set; }
        public DbSet<IngredientEntity> Ingredients { get; set; }

        public EliteRestaurantContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public EliteRestaurantContext() : base() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EliteRestaurantDb;Integrated Security=True;";
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CookEntity>().ToTable("Cooks");
            modelBuilder.Entity<CuisineTypeEntity>().ToTable("CuisineTypes");
            modelBuilder.Entity<DishEntity>().ToTable("Dishes");
            modelBuilder.Entity<IngredientEntity>().ToTable("Ingredients");

            //var American = new CuisineTypeEntity { CuisineType = "American" };
            //var Ukrainian = new CuisineTypeEntity { CuisineType = "Ukrainian" };
            //var Italian = new CuisineTypeEntity { CuisineType = "Italian" };
            //var Russian = new CuisineTypeEntity { CuisineType = "Russian" };
            //var English = new CuisineTypeEntity { CuisineType = "English" };

            //modelBuilder.Entity<CuisineTypeEntity>().HasData(American, Ukrainian, Italian, Russian, English);

            //modelBuilder.Entity<CookEntity>().HasData(
            //    new CookEntity
            //    {
            //        Name = "B.B. King",
            //        CuisinesSpecializedIn = new List<CuisineTypeEntity>
            //        {
            //            American, English
            //        },
            //    },
            //    new CookEntity
            //    {
            //        Name = "Joe Cocker",
            //        CuisinesSpecializedIn = new List<CuisineTypeEntity>
            //        {
            //            Italian
            //        },
            //    },
            //    new CookEntity
            //    {
            //        Name = "Eric Clapton",
            //        CuisinesSpecializedIn = new List<CuisineTypeEntity>
            //        {
            //            Russian, Ukrainian
            //        },
            //    });

            //modelBuilder.Entity<DishEntity>().HasData(
            //    new DishEntity
            //    {
            //        Name = "Fahitos",
            //        CookingTime = new TimeSpan(0, 10, 0),
            //        CuisineType = American,
            //        Price = 100m,
            //        Weight = 150
            //    },
            //    new DishEntity
            //    {
            //        Name = "Fish & Chips",
            //        CookingTime = new TimeSpan(0, 15, 0),
            //        CuisineType = English,
            //        Price = 100m,
            //        Weight = 100
            //    },
            //    new DishEntity
            //    {
            //        Name = "Varenyky",
            //        CookingTime = new TimeSpan(0, 10, 0),
            //        CuisineType = Ukrainian,
            //        Price = 100m,
            //        Weight = 200
            //    },
            //    new DishEntity
            //    {
            //        Name = "Pasta Bolognese",
            //        CookingTime = new TimeSpan(0, 20, 0),
            //        CuisineType = Italian,
            //        Price = 100m,
            //        Weight = 250
            //    },
            //    new DishEntity
            //    {
            //        Name = "Pelmeni",
            //        CookingTime = new TimeSpan(0, 10, 0),
            //        CuisineType = Russian,
            //        Price = 100m,
            //        Weight = 200
            //    });
        }
    }
}
