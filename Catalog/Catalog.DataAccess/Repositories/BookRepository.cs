using Catalog.DataAccess.Entities;
using Catalog.DataAccess.Interfaces;

namespace Catalog.DataAccess.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly CatalogDbContext _dbContext;
        public BookRepository(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Book>> GetBookByIdAsync(int bookId)
        {
            return _dbContext.Books.Where(b => b.BookId == bookId);
        }

        public async Task<IEnumerable<Book>> GetBookByTopicAsync(string topic)
        {
            return _dbContext.Books.Where(b => b.BookTopic.Topic == topic);
        }
    }
}
