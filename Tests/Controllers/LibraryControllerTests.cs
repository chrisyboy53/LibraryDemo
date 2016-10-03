using System;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Homemade.Controllers;
using Homemade.Services;
using Homemade.Models;
using Moq;

namespace Homemade.Tests.Controllers
{
    public class LibraryControllerTests {

        Mock<ILibrary> _mockedLibrary = null;
        Book[] books = new Book[] { new Book(1, "First Book", "First Author", new DateTime(2016, 09, 21)) };

        /// <summary>
        /// Setups the mocked version of ILibrary
        /// </summary>
        public LibraryControllerTests() {
            _mockedLibrary = new Mock<ILibrary>();
            
            _mockedLibrary.Setup(repo => repo.BookCollection).Returns(books.ToList());
        }

        [Fact]
        public void GetBooksInLibrary() {
            /*
             * Create the Controller passing in ILibrary Service
             */
            LibraryController controller = new LibraryController(_mockedLibrary.Object);

            var bookResults = controller.GetBooks() as JsonResult;
            
            Assert.NotNull(bookResults);
            Assert.NotEmpty(bookResults.Value as IList<Book>);
            
            var firstBook = ((IList<Book>)bookResults.Value).First();
            var expectedTitle = "First Book  ddd";
            Assert.Equal(expectedTitle, firstBook.Title);

        }

        [Fact]
        public void GetNonExistingBookInLibrary() {
            /*
             * Create the Controller passing in ILibrary Service
             */
            LibraryController controller = new LibraryController(_mockedLibrary.Object);
            var results = controller.GetBookById(500) as StatusCodeResult;
            // Ensure we get a not found http status code 404
            Assert.Equal((int)HttpStatusCode.NotFound, results.StatusCode);
        }

        [Fact]
        public void GetExistingBookInLibrary() {
            int id = 1;
            LibraryController controller = new LibraryController(_mockedLibrary.Object);
            var results = controller.GetBookById(id) as JsonResult;

            // Ensure we get a OK Message Code
            Assert.Equal((int)HttpStatusCode.OK, results.StatusCode);

            // Make sure its the same book as our mocked version
            Assert.Equal(results.Value as Book, books.First(T => T.Id == id));
        }

        [Fact]
        public void DeleteABookInLibrary() {
            int id = 1;

            _mockedLibrary.Setup(repo => repo.RemoveBook(It.IsAny<Book>())).Returns(true);

            LibraryController controller = new LibraryController(_mockedLibrary.Object);
            var results = controller.RemoveBook(id) as StatusCodeResult;

            Assert.True(results.StatusCode == (int)HttpStatusCode.OK);
        }

        [Fact]
        public void DeleteABookThatIsNotInLibrary() {
            int id = 1;

            _mockedLibrary.Setup(repo => repo.RemoveBook(It.IsAny<Book>())).Returns(false);

            LibraryController controller = new LibraryController(_mockedLibrary.Object);
            var results = controller.RemoveBook(id) as StatusCodeResult;

            Assert.True(results.StatusCode == (int)HttpStatusCode.NotFound);
        }

    }
}