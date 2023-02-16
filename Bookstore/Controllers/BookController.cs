using Microsoft.AspNetCore.Mvc;
using Bookstore.Models;

namespace Bookstore.Controllers
{
    public class BookController : Controller
    {
        private Repository<Book> data { get; set; }
        public BookController(BookstoreContext ctx) => data = new Repository<Book>(ctx);

        public RedirectToActionResult Index() => RedirectToAction("List");

        public ViewResult List(BookGridData values)
        {
            // create options for querying books
            var options = new QueryOptions<Book> { 
                Includes = "Authors, Genre",
                OrderByDirection = values.SortDirection,
                PageNumber = values.PageNumber,
                PageSize = values.PageSize
            };
            if (values.IsSortByGenre) 
                options.OrderBy = b => b.GenreId;
            else if (values.IsSortByPrice) 
                options.OrderBy = b => b.Price;
            else 
                options.OrderBy = b => b.Title;

            // create view model
            var vm = new BookListViewModel { 
                Books = data.List(options),
                CurrentRoute = values,
                TotalPages = values.GetTotalPages(data.Count)
            };

            return View(vm);
        }

        public ViewResult Details(int id)
        {
            var book = data.Get(new QueryOptions<Book> {
                Where = b => b.BookId == id,
                Includes = "Authors, Genre"
            }) ?? new Book();
            return View(book);
        }
    }   
}