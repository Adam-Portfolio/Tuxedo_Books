using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Models
{
    public class Author
    {
        // initialize navigation property collection in constructor
        public Author() => Books = new HashSet<Book>();

        // primary key property
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Please enter a first name.")]
        [MaxLength(200)]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter a last name.")]
        [MaxLength(200)]
        [Remote("CheckAuthor", "Validation", "Admin", AdditionalFields = "FirstName, Operation")] // include 'Admin' area name
        public string LastName { get; set; } = string.Empty;

        // read-only property
        public string FullName => $"{FirstName} {LastName}";

        // navigation property
        public ICollection<Book> Books { get; set; }
    }
}
