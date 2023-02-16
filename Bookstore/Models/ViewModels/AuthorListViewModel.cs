namespace Bookstore.Models
{
    public class AuthorListViewModel
    {
        public IEnumerable<Author> Authors { get; set; } = new List<Author>();
        public AuthorGridData CurrentRoute { get; set; } = new AuthorGridData();
        public int TotalPages { get; set; }
    }
}
