using EcommerceLite.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceLite.Data;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Electronics" },
            new Category { Id = 2, Name = "Books" }
        );
        
        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1, Name = "Laptop", Description = "Powerful laptop", Price = 1200.00m, CategoryId = 1 },
            new Product { Id = 2, Name = "Mistborn", Description = "Fantasy novel", Price = 25.00m, CategoryId = 2 }
        );

        modelBuilder.Entity<User>().HasData(
            new User { 
                Id = 1, 
                Username = "admin", 
                PasswordHash = "$2a$11$Dgci3gF3OxwhnA3wY3F93eN9ZMn8aZlG28RQJ1z6gM0wGHPtObL9G", 
                Role = Role.Admin}
        );

        base.OnModelCreating(modelBuilder);
    }
}