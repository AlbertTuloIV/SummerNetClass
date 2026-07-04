using Microsoft.EntityFrameworkCore;
using BookStoreWebApp.Models;

namespace BookStoreWebApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .Property(b => b.Price)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Pages = 180, Price = 12.99m },
                new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee", Pages = 281, Price = 14.99m },
                new Book { Id = 3, Title = "1984", Author = "George Orwell", Pages = 328, Price = 11.99m },
                new Book { Id = 4, Title = "Pride and Prejudice", Author = "Jane Austen", Pages = 432, Price = 9.99m },
                new Book { Id = 5, Title = "The Catcher in the Rye", Author = "J.D. Salinger", Pages = 214, Price = 10.99m }
            );
        }
    }
}
