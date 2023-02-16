namespace Bookstore.Models
{
    public interface IBookRepository : IRepository<Book>
    {
        void AddNewAuthors(Book book, int[] authorids, IRepository<Author> authorData);
    }
}
