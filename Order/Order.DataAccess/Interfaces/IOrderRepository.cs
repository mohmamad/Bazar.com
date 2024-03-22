namespace Order.DataAccess.Interfaces
{
    public interface IOrderRepository
    {
        public Task<bool> PurchaseBook(int bookId);
    }
}
