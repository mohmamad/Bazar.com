using Catalog.DataAccess.Entities;

namespace Catalog.DataAccess.Interfaces
{
    public interface IBookRepository
    {
        public Task<IEnumerable<Book>> GetBookByIdAsync(int bookId);

        public Task<IEnumerable<Book>> GetBookByTopicAsync(string topic);
    }
}
