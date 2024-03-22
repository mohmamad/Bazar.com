namespace Catalog.DataAccess.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public int BookTopicId { get; set; }
        public BookTopic BookTopic { get; set; }

    }
}
