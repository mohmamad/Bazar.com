using Catalog.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.DataAccess
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedingBookTopic(modelBuilder);
            SeedingBook(modelBuilder);
        }

        public void SeedingBookTopic(ModelBuilder mb)
        {
            mb.Entity<BookTopic>().HasData
                (
                new BookTopic
                {
                    BookTopicId = 1,
                    Topic = "distributed systems"
                }
                );
            mb.Entity<BookTopic>().HasData
                (
                new BookTopic
                {
                    BookTopicId = 2,
                    Topic = "undergraduate school"
                }
                );
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
                    BookTopicId = 1,
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
                    BookTopicId = 1,
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
                    BookTopicId = 2,
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
                    BookTopicId = 2,
                }
                );
        }
    }
}