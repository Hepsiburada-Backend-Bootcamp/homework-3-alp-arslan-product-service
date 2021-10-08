using Microsoft.EntityFrameworkCore;
using ProductNS.Domain.Models;
using System;
using System.Linq;


namespace ProductNS.Infrastructure.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
            //TODO: Refactor this method ASAP. VERY URGENT. PLEASE.
            //Comment this out before migrating and updating db
            //AddDummyData();
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }

        private void AddDummyData()
        {
            //This is a very bad way of filling the db,
            //Because of the scope, this method is called for every request.
            //TODO: Refactor this ASAP
            if (Products.Any())
                return;
            DateTime now = DateTime.Now;
            Categories.AddRange(
                new Category
                {
                    Name = "Furniture",
                    Description = "Consists of large objects such as tables, chairs, " +
                    "or beds that are used in a room for sitting or lying on " +
                    "or for putting things on or in.",
                    DateOfCreation = now
                },
                new Category
                {
                    Name = "Electronics",
                    Description = "is the technology of using transistors and silicon chips, " +
                    "especially in devices such as radios, televisions, and computers.",
                    DateOfCreation = now
                }
            );
            SaveChanges();

            Brands.AddRange(
                new Brand
                {
                    Name = "Ikea",
                    Description = "IKEA is a global destination store for home furnishing, " +
                    "appliances, ready-to-assemble furniture, home accessories and kitchen products.",
                    DateOfCreation = now
                },
                new Brand
                {
                    Name = "Big Phones",
                    Description = " designs, manufactures and markets smartphones, personal computers, " +
                    "tablets, wearables and accessories, and sells a variety of related services. ",
                    DateOfCreation = now
                }
            );
            SaveChanges();
            
            Products.AddRange(
                new Product
                {
                    Name = "Chair",
                    Description = "A chair",
                    Category = Categories.Find(1),
                    Brand = Brands.Find(1),
                    Price = 50,
                    DateOfCreation = now,
                    DateOfLastEdit = now
                },
                new Product
                {
                    Name = "Sofa",
                    Description = "A sofa",
                    Category = Categories.Find(1),
                    Brand = Brands.Find(1),
                    Price = 100,
                    DateOfCreation = now,
                    DateOfLastEdit = now
                },
                new Product
                {
                    Name = "Huge Phone",
                    Description = "The biggest phone yet",
                    Category = Categories.Find(2),
                    Brand = Brands.Find(2),
                    Price = 5000,
                    DateOfCreation = now,
                    DateOfLastEdit = now
                }
            );
            SaveChanges();
        }
    }
}
