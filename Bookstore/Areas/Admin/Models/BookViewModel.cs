using System.ComponentModel.DataAnnotations;

namespace Bookstore.Models
{
    public class BookViewModel
    {
        public Book Book { get; set; } = new Book();

        [Required(ErrorMessage = "Please select at least one author.")]
        public int[] SelectedAuthors { get; set; } = Array.Empty<int>();

        public IEnumerable<Genre> Genres { get; set; } = new List<Genre>();
        public IEnumerable<Author> Authors { get; set; } = new List<Author>();

    }
}
