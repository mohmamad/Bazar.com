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

        }
    }
}