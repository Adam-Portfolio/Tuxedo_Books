using System.Text.Json.Serialization;

namespace Bookstore.Models
{
    public class AuthorGridData : GridData
    {
        // set initial sort field in constructor
        public AuthorGridData() => SortField = nameof(Author.FirstName);

        // sort flag
        [JsonIgnore]
        public bool IsSortByFirstName =>
            SortField.EqualsNoCase(nameof(Author.FirstName));
    }
}
