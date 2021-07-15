using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreShop.Models
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        //public DatabaseContext(DbContextOptions options) : base(options)
        //{
        //    Database.Migrate();
        //}

        public DatabaseContext()
        {
            Database.Migrate();
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Category[] categories = new Category[]
            {
                new Category {Id = 1, Name = "Вода"},
                new Category {Id = 2, Name = "Еда"}
            };

            Product[] products = new Product[]
            {
                new Product {Id = 1, Name = "Кола", CategoryFK = 1},
                new Product {Id = 2, Name = "Бургир", CategoryFK = 2},
            };

            modelBuilder.Entity<Category>().HasData(categories);
            modelBuilder.Entity<Product>().HasData(products);

            base.OnModelCreating(modelBuilder);
        }
    }
}
