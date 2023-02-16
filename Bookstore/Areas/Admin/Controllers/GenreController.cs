using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Bookstore.Models;

namespace Bookstore.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class GenreController : Controller
    {
        private Repository<Genre> data { get; set; }
        public GenreController(BookstoreContext ctx) => data = new Repository<Genre>(ctx);

        public ViewResult Index()
        {
            var genres = data.List(new QueryOptions<Genre> {
                OrderBy = g => g.Name
            });
            return View(genres);
        }

        // select (posted from genre drop down on Index page). 
        [HttpPost]
        public RedirectToActionResult Select(string id, string operation)
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
        public ViewResult Add() => View("Genre", new Genre());

        [HttpPost]
        public IActionResult Add(Genre genre)
        {
            // server-side version of remote validation 
            var validate = new Validate(TempData);
            if (!validate.IsGenreChecked) {
                validate.CheckGenre(genre.GenreId, data);
                if (!validate.IsValid) {
                    ModelState.AddModelError(nameof(genre.GenreId), validate.ErrorMessage);
                }     
            }

            if (ModelState.IsValid) {
                data.Insert(genre);
                data.Save();
                validate.ClearGenre();
                TempData["message"] = $"{genre.Name} added to Genres.";
                return RedirectToAction("Index");  // PRG pattern
            }
            else {
                return View("Genre", genre);
            }
        }

        // edit
        [HttpGet]
        public ViewResult Edit(string id) => View("Genre", data.Get(id));

        [HttpPost]
        public IActionResult Edit(Genre genre)
        {
            // no remote validation of genre id on edit
            if (ModelState.IsValid) {
                data.Update(genre);
                data.Save();
                TempData["message"] = $"{genre.Name} updated.";
                return RedirectToAction("Index");  // PRG pattern
            }
            else {
                return View("Genre", genre);
            }
        }

        // delete
        [HttpGet]
        public IActionResult Delete(string id) {
            var genre = data.Get(new QueryOptions<Genre> {
                Where = g => g.GenreId == id,
                Includes = "Books"
            });

            if (genre != null && genre.Books.Count > 0) 
            {
                TempData["message"] = $"Can't delete genre {genre.Name} " + 
                                      "because it has related books.";
                return RedirectToAction("Related", "Book", 
                    new { id = "genre-" + id });
            }
            else {
                return View("Genre", genre);
            }
        }

        [HttpPost]
        public IActionResult Delete(Genre genre)
        {
            data.Delete(genre);
            data.Save();
            TempData["message"] = $"{genre.Name} removed from Genres.";
            return RedirectToAction("Index");  // PRG pattern
        }
    }
}