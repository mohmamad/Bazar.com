using Catalog.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.DataAccess
{
    public class CatalogDbContext : DbContext
    {
        public CatalogDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Book> Books { get; set; }
    }
}