using Microsoft.EntityFrameworkCore;
using Order.DataAccess.Entities;

namespace Order.DataAccess
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedingBook(modelBuilder);
        }

        public void SeedingBook(ModelBuilder mb)
        {
            mb.Entity<Book>().HasData
               (
               new Book
               {
                   BookId = 1,
                   Title = "How to get a good grade in DOS in 40 minutes a day",
                   Quantity = 5,
                   Price = 15,
               }
               );
            mb.Entity<Book>().HasData
                (
                new Book
                {
                    BookId = 2,
                    Title = "RPCs for Noobs",
                    Quantity = 3,
                    Price = 20,
                }
                );
            mb.Entity<Book>().HasData
                (
                new Book
                {
                    BookId = 3,
                    Title = "Xen and the Art of Surviving Undergraduate School.",
                    Quantity = 5,
                    Price = 15,
                }
                );
            mb.Entity<Book>().HasData
                (
                new Book
                {
                    BookId = 4,
                    Title = "Cooking for the Impatient Undergrad.",
                    Quantity = 5,
                    Price = 15,
                }
                );
        }
    }
}