using Microsoft.AspNetCore.Mvc;
using Bookstore.Models;

namespace Bookstore.Controllers
{
    public class AuthorController : Controller
    {
        private Repository<Author> data { get; set; }
        public AuthorController(BookstoreContext ctx) => data = new Repository<Author>(ctx);

        public IActionResult Index() => RedirectToAction("List");

        public ViewResult List(AuthorGridData values)
        {
            // create options for querying authors
            var options = new QueryOptions<Author> {
                Includes = "Books",
                PageNumber = values.PageNumber,
                PageSize = values.PageSize,
                OrderByDirection = values.SortDirection,
            };
            if (values.IsSortByFirstName)
                options.OrderBy = a => a.FirstName;
            else
                options.OrderBy = a => a.LastName;

            // create view model and add page of author data, the current grid route segments,
            // and the total number of pages
            var vm = new AuthorListViewModel {
                Authors = data.List(options),
                CurrentRoute = values,
                TotalPages = values.GetTotalPages(data.Count)
            };

            // pass view model to view
            return View(vm);
        }

        public IActionResult Details(int id)
        {
            var author = data.Get(new QueryOptions<Author> {
                Where = a => a.AuthorId == id,
                Includes = "Books"
            }) ?? new Author();
            return View(author);
        }
    }
}