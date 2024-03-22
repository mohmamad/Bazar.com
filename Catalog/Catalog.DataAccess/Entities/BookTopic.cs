namespace Catalog.DataAccess.Entities
{
    public class BookTopic
    {
        public int BookTopicId { get; set; }
        public string Topic { get; set; }
        public List<Book> Books { get; set; }
    }
}
