// Controllers/BookController.cs
using LAB13_TASK1.Models;
using LAB13_TASK1.Models.Database;
using Microsoft.AspNetCore.Mvc;
using LAB13_TASK1.Models;
using LAB13_TASK1.Models.Database;

namespace LAB13_TASK1.Controllers
{
    public class BookController : Controller
    {
        private readonly LibraryDbContext _context;

        public BookController(LibraryDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var list = _context.books.ToList();
            return View(list);
        }

        public IActionResult ViewAll()
        {
            var list = _context.books.ToList();
            return View("Index", list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.books.Add(book);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        public IActionResult Edit(int id)
        {
            var item = _context.books.Find(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Book model)
        {
            if (id != model.BookId) return BadRequest();

            if (ModelState.IsValid)
            {
                _context.books.Update(model);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var item = _context.books.Find(id);
            if (item == null) return NotFound();
            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var item = _context.books.Find(id);
            if (item == null) return NotFound();

            _context.books.Remove(item);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
