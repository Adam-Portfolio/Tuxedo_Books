using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;    // for ValidateNever

namespace Bookstore.Models
{
    public partial class Book
    {
        // initialize navigation property collection in constructor
        public Book() => Authors = new HashSet<Author>();

        // primary key property
        public int BookId { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Range(1.0, 1000000.0, ErrorMessage = "Price must be 1 or more.")]
        public double Price { get; set; }

        // foreign key property
        [Required(ErrorMessage = "Please select a genre.")]
        public string GenreId { get; set; } = string.Empty;

        // navigation properties
        [ValidateNever]
        public Genre Genre { get; set; } = null!;
        public ICollection<Author> Authors { get; set; }

    }
}
