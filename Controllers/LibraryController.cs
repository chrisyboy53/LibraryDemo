using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Homemade.Models;
using Homemade.Services;

namespace Homemade.Controllers
{
    /// <summary>
    /// Allows access to the Library Collection;
    /// </summary>
    [Route("/api/Book")]
    public class LibraryController : Controller {

        private ILibrary _library;
        
        public LibraryController(ILibrary Library) {
            _library = Library;
        }

        [HttpGet]
        public IActionResult GetBooks() {
            return new JsonResult(_library.BookCollection);
        }

        [HttpGet("{id}")]
        public IActionResult GetBookById(int id) {
            var result = _library.BookCollection.FirstOrDefault(T => T.Id == id);

            if (result == null) {
                return new StatusCodeResult((int)HttpStatusCode.NotFound);
            }
            
            return new JsonResult(result) { StatusCode = (int)HttpStatusCode.OK };
        }

        [HttpPost]
        public IActionResult AddBook([FromBodyAttribute]Book book) {
            // Ensure we have content in the body
            if (book == null) {
                return new StatusCodeResult((int)HttpStatusCode.NoContent);
            }

            // Attempt to add the Book in the collection
            if (_library.AddBook(book)) {
                return new StatusCodeResult((int)HttpStatusCode.Created);
            }
            else {
                return new StatusCodeResult((int)HttpStatusCode.NotModified);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveBook(int id) {
            // Find the book and attempt to delete
            var book = _library.BookCollection.FirstOrDefault(T=> T.Id == id);

            if (_library.RemoveBook(book))
            {
                return new StatusCodeResult((int)HttpStatusCode.OK);
            }
            else {
                return new StatusCodeResult((int)HttpStatusCode.NotFound);
            }
        }

        [HttpPut()]
        public IActionResult UpdateBook([FromBodyAttribute]Book book) {
            // Ensure we have content in the body
            if (book == null) {
                return new StatusCodeResult((int)HttpStatusCode.NoContent);
            }

            // Attempt to update the Book in the collection
            if (_library.UpdateBook(book)) {
                return new StatusCodeResult((int)HttpStatusCode.OK);
            }
            else {
                return new StatusCodeResult((int)HttpStatusCode.NotFound);
            }
        }
    }
}