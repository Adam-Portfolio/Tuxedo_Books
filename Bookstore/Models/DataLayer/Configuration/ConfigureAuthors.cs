using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Models
{
    internal class ConfigureAuthors : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> entity)
        {
            // seed initial data
            entity.HasData(
                new { AuthorId = 1, FirstName = "Michelle", LastName = "Alexander" },
                new { AuthorId = 2, FirstName = "Stephen E.", LastName = "Ambrose" },
                new { AuthorId = 3, FirstName = "Margaret", LastName = "Atwood" },
                new { AuthorId = 4, FirstName = "Jane", LastName = "Austen" },
                new { AuthorId = 5, FirstName = "James", LastName = "Baldwin" },
                new { AuthorId = 6, FirstName = "Emily", LastName = "Bronte" },
                new { AuthorId = 7, FirstName = "Agatha", LastName = "Christie" },
                new { AuthorId = 8, FirstName = "Ta-Nehisi", LastName = "Coates" },
                new { AuthorId = 9, FirstName = "Jared", LastName = "Diamond" },
                new { AuthorId = 10, FirstName = "Joan", LastName = "Didion" },
                new { AuthorId = 11, FirstName = "Daphne", LastName = "Du Maurier" },
                new { AuthorId = 12, FirstName = "Tina", LastName = "Fey" },
                new { AuthorId = 13, FirstName = "Roxane", LastName = "Gay" },
                new { AuthorId = 14, FirstName = "Dashiel", LastName = "Hammett" },
                new { AuthorId = 15, FirstName = "Frank", LastName = "Herbert" },
                new { AuthorId = 16, FirstName = "Aldous", LastName = "Huxley" },
                new { AuthorId = 17, FirstName = "Stieg", LastName = "Larsson" },
                new { AuthorId = 18, FirstName = "David", LastName = "McCullough" },
                new { AuthorId = 19, FirstName = "Toni", LastName = "Morrison" },
                new { AuthorId = 20, FirstName = "George", LastName = "Orwell" },
                new { AuthorId = 21, FirstName = "Mary", LastName = "Shelley" },
                new { AuthorId = 22, FirstName = "Sun", LastName = "Tzu" },
                new { AuthorId = 23, FirstName = "Augusten", LastName = "Burroughs" },
                new { AuthorId = 25, FirstName = "JK", LastName = "Rowling" },
                new { AuthorId = 26, FirstName = "Seth", LastName = "Grahame-Smith" }
            );
        }
    }

}