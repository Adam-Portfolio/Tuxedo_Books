using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;    // for Remote attribute

namespace Bookstore.Models
{
    public class Genre
    {
        // initialize navigation property collection in constructor
        public Genre() => Books = new HashSet<Book>();

        // primary key property
        [MaxLength(10)]
        [Required(ErrorMessage = "Please enter a genre id.")]
        [Remote("CheckGenre", "Validation", "Admin")] // include 'Admin' area name
        public string GenreId { get; set; } = string.Empty;

        [StringLength(25)]
        [Required(ErrorMessage = "Please enter a genre name.")]
        public string Name { get; set; } = string.Empty;

        // navigation property
        public ICollection<Book> Books { get; set; }
    }
}