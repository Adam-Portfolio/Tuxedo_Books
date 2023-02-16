using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bookstore.Models;

namespace Bookstore.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class AuthorController : Controller
    {
        private Repository<Author> data { get; set; }
        public AuthorController(BookstoreContext ctx) => data = new Repository<Author>(ctx);

        public ViewResult Index()
        {
            var authors = data.List(new QueryOptions<Author> {
                OrderBy = a => a.FirstName
            });
            return View(authors);
        }

        // select (posted from author drop down on Index page). 
        [HttpPost]
        public RedirectToActionResult Select(int id, string operation)
        {
            switch (operation.ToLower())
            {
                case "edit":
                    return RedirectToAction("Edit", new { id });
                case "delete":
                    return RedirectToAction("Delete", new { id });
                default:
                    return RedirectToAction("Index");
            }
        }

        // add
        [HttpGet]
        public ViewResult Add() => View("Author", new Author()); 

        [HttpPost]
        public IActionResult Add(Author author, string operation)
        {
            // server-side version of remote validation 
            var validate = new Validate(TempData);
            if (!validate.IsAuthorChecked) {
                validate.CheckAuthor(author.FirstName, author.LastName, operation, data);
                if (!validate.IsValid) {
                    ModelState.AddModelError(nameof(author.LastName), validate.ErrorMessage);
                }    
            }
            
            if (ModelState.IsValid) {
                data.Insert(author);
                data.Save();
                validate.ClearAuthor();
                TempData["message"] = $"{author.FullName} added to Authors.";
                return RedirectToAction("Index");  // PRG pattern
            }
            else {
                return View("Author", author);
            }
        }

        // edit
        [HttpGet]
        public ViewResult Edit(int id) => View("Author", data.Get(id)); 

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            // no remote validation of author on edit
            if (ModelState.IsValid) {
                data.Update(author);
                data.Save();
                TempData["message"] = $"{author.FullName} updated.";
                return RedirectToAction("Index");  // PRG pattern
            }
            else {
                return View("Author", author);
            }
        }

        // delete
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var author = data.Get(new QueryOptions<Author> {
                Where = a => a.AuthorId == id,
                Includes = "Books"
            });

            if (author != null && author.Books.Count > 0) 
            {
                TempData["message"] = $"Can't delete author {author.FullName} " +
                                      "because they have related books.";
                return RedirectToAction("Related", "Book", 
                    new { id = "author-" + id });
            }
            else {
                return View("Author", author);
            }
        }

        [HttpPost]
        public RedirectToActionResult Delete(Author author)
        {
            data.Delete(author);
            data.Save();
            TempData["message"] = $"{author.FullName} removed from Authors.";
            return RedirectToAction("Index");  // PRG pattern
        }
    }
}