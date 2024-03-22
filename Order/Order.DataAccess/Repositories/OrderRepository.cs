using Order.DataAccess.Interfaces;

namespace Order.DataAccess.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderDbContext _dbContext;
        public OrderRepository(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
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
