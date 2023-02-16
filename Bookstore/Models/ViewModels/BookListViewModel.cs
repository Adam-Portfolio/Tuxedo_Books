namespace Bookstore.Models
{
    public class BookListViewModel 
    {
        public IEnumerable<Book> Books { get; set; } = new List<Book>();
        public BookGridData CurrentRoute { get; set; } = new BookGridData();
        public int TotalPages { get; set; }
    }
}
