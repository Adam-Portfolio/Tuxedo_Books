namespace Bookstore.Models
{
    // Trying to store a Book object in session can cause problems because the JSON 
    // serialization done in SessionExtensionMethods.cs can create circular references
    // as the serializer tries to follow all the navigation properties. You can decorate
    // those properties with the [JsonIgnore] attribute, but you can end up with that
    // scattered all around. Another way, shown here, is to create a DTO class with the 
    // data needed for the cart. 
    
    public class BookDTO
    {
        public int BookId { get; set; }
        public string Title { get; set; } = string.Empty;
        public double Price { get; set; } 
        public Dictionary<int, string> Authors { get; set; } = new Dictionary<int, string>();

        // default constructor (required for model binding)
        public BookDTO() { }

        // overloaded constructor accepts a Book object
        public BookDTO(Book book){
            BookId = book.BookId;
            Title = book.Title;
            Price = book.Price;
            if (book.Authors?.Count > 0) {
                foreach (Author a in book.Authors) {
                    Authors.Add(a.AuthorId, a.FullName);
                }
            }
            
        }
    }

}
