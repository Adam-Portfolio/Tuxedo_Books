using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bookstore.Models
{
    internal class ConfigureGenres : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> entity)
        {
            // seed initial data
            entity.HasData(
                new { GenreId = "novel", Name = "Novel" },
                new { GenreId = "memoir", Name = "Memoir" },
                new { GenreId = "mystery", Name = "Mystery" },
                new { GenreId = "scifi", Name = "Science Fiction" },
                new { GenreId = "history", Name = "History" }
            );
        }
    }

}
