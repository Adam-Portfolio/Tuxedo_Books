using Microsoft.AspNetCore.Mvc.ViewFeatures;

/* 
 * Note about validation: Admin area allows Author to be inserted, updated, and deleted. 
 * Check whether first name and last name are in database should only happen on insert,
 * so additional field of 'Operation' is needed to determine when to hit database. Genre
 * can be inserted, updated, and deleted, too, but because the thing being checked (GenreId) 
 * is also the primary key, application doesn't allow it to be changed on edit like it allows
 * the Author name fields to be changed. So, on edit, GenreId is a read-only field, so it's
 * not changed by user, so no check is needed. Thus, Genre check doesn't need additional
 * 'Operation' field. 
 * 
 * Genre check is necessary bc if try to add a GenreId that already exists in database, will
 * get EF duplicate primary key error. The Author insert won't throw errors, but still a 
 * good check to have, to help reduce bad data. 
 */
namespace Bookstore.Models
{
    // used by client-side and server-side remote validation checks
    public class Validate
    {
        // private constants for working with TempData
        private const string GenreKey = "validGenre";
        private const string AuthorKey = "validAuthor";

        // constructor and private TempData property
        private ITempDataDictionary tempData { get; set; }
        public Validate(ITempDataDictionary temp) => tempData = temp;

        // public properties
        public bool IsValid { get; private set; }
        public string ErrorMessage { get; private set; } = string.Empty;

        // genre
        public void CheckGenre(string genreId, Repository<Genre> data)
        {
            Genre? entity = data.Get(genreId);
            IsValid = (entity == null) ? true : false;
            ErrorMessage = (IsValid) ? "" :
                $"Genre id {genreId} is already in the database.";
        }
        public void MarkGenreChecked() => tempData[GenreKey] = true;
        public void ClearGenre() => tempData.Remove(GenreKey);
        public bool IsGenreChecked => tempData.Keys.Contains(GenreKey);

        // author
        public void CheckAuthor(string firstName, string lastName, string operation, Repository<Author> data)
        {
            Author? entity = null; 
            if (operation.EqualsNoCase("add")) // only check database on add
            {
                entity = data.Get(new QueryOptions<Author> {
                    Where = a => a.FirstName == firstName && a.LastName == lastName
                });
            }
            IsValid = (entity == null) ? true : false;
            ErrorMessage = (IsValid) ? "" :
                $"Author {entity!.FullName} is already in the database.";
        }
        public void MarkAuthorChecked() => tempData[AuthorKey] = true;
        public void ClearAuthor() => tempData.Remove(AuthorKey);
        public bool IsAuthorChecked => tempData.Keys.Contains(AuthorKey);
    }
}