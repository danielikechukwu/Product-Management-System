using Microsoft.EntityFrameworkCore;
using ProductManagementSystem.Models;

namespace ProductManagementSystem.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Electronics" },
                new Category { CategoryId = 2, Name = "Furniture" }
            );

            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Smartphone", Description = "High-end phone", Price = 800, CreatedDate = DateTime.Parse("2025-01-01"), CreatedBy = "Admin", Stock = 10, ProductType = "Premium", IsAvailable = true, CategoryId = 1 },
                new Product { Id = 2, Name = "Desk Lamp", Price = 50, CreatedDate = DateTime.Parse("2025-01-01"), CreatedBy = "Admin", Stock = 10, ProductType = "Premium", IsAvailable = true, CategoryId = 2  },
                new Product { Id = 3, Name = "Tablet", Description = "Compact tablet", Price = 300, CreatedDate = DateTime.Parse("2025-01-01"), CreatedBy = "Out-of-Stock", Stock = 0, ProductType = "Standard", IsAvailable = true, CategoryId = 1 },
                new Product { Id = 4, Name = "Chair", Price = 150, CreatedDate = DateTime.Parse("2025-01-01"), CreatedBy = "Admin", Stock = 0, ProductType = "Standard", IsAvailable = false, CategoryId = 2 }
            );

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

    }
}
