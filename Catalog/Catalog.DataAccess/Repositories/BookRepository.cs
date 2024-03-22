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
        public async Task<bool> PurchaseBook(int bookId)
        {
            var book = _dbContext.Books.Where(b => b.BookId == bookId && b.Quantity > 0);
            if (book.Any())
            {
                book.ToList()[0].Quantity--;
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
