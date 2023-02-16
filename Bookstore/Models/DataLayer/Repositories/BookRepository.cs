namespace Bookstore.Models
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BookstoreContext ctx) : base(ctx) { }

        public void AddNewAuthors(Book book, int[] authorids, IRepository<Author> authorData)
        {
            // first remove any current authors
            foreach (Author author in book.Authors)
            {
                book.Authors.Remove(author);
            }

            // then add new authors
            foreach (int id in authorids)
            {
                Author? author = authorData.Get(id);
                if (author != null) 
                    book.Authors.Add(author);
            }
        }
    }
}