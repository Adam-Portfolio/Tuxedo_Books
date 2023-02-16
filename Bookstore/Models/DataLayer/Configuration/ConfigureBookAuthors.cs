using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Models
{
    internal class ConfigureBookAuthors : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> entity) 
        {
            entity
                .HasMany(b => b.Authors)     // many-to-many relationship
                .WithMany(a => a.Books)
                .UsingEntity(
                     ba => ba.HasData(       // seed initial data
                        new { BooksBookId = 1, AuthorsAuthorId = 18 },
                        new { BooksBookId = 2, AuthorsAuthorId = 20 },
                        new { BooksBookId = 3, AuthorsAuthorId = 7 },
                        new { BooksBookId = 4, AuthorsAuthorId = 2 },
                        new { BooksBookId = 5, AuthorsAuthorId = 19 },
                        new { BooksBookId = 6, AuthorsAuthorId = 8 },
                        new { BooksBookId = 7, AuthorsAuthorId = 12 },
                        new { BooksBookId = 8, AuthorsAuthorId = 16 },
                        new { BooksBookId = 9, AuthorsAuthorId = 2 },
                        new { BooksBookId = 10, AuthorsAuthorId = 20 },
                        new { BooksBookId = 11, AuthorsAuthorId = 15 },
                        new { BooksBookId = 12, AuthorsAuthorId = 4 },
                        new { BooksBookId = 13, AuthorsAuthorId = 21 },
                        new { BooksBookId = 14, AuthorsAuthorId = 5 },
                        new { BooksBookId = 15, AuthorsAuthorId = 9 },
                        new { BooksBookId = 16, AuthorsAuthorId = 13 },
                        new { BooksBookId = 17, AuthorsAuthorId = 7 },
                        new { BooksBookId = 18, AuthorsAuthorId = 4 },
                        new { BooksBookId = 19, AuthorsAuthorId = 11 },
                        new { BooksBookId = 20, AuthorsAuthorId = 22 },
                        new { BooksBookId = 21, AuthorsAuthorId = 17 },
                        new { BooksBookId = 22, AuthorsAuthorId = 3 },
                        new { BooksBookId = 23, AuthorsAuthorId = 14 },
                        new { BooksBookId = 24, AuthorsAuthorId = 1 },
                        new { BooksBookId = 25, AuthorsAuthorId = 10 },
                        new { BooksBookId = 26, AuthorsAuthorId = 6 },
                        new { BooksBookId = 27, AuthorsAuthorId = 23 },
                        new { BooksBookId = 28, AuthorsAuthorId = 4 },
                        new { BooksBookId = 28, AuthorsAuthorId = 26 },
                        new { BooksBookId = 29, AuthorsAuthorId = 25 }
                ));

        }
    }
}
