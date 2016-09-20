using System.Collections.Generic;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Homemade.Controllers;
using Homemade.Services;
using Homemade.Models;

namespace Homemade.Tests.Controllers
{
    public class LibraryControllerTests {

        [Fact]
        public void GetBooksInLibrary() {
            ILibrary service = null;
            LibraryController controller = new LibraryController(service);

            var books = controller.GetBooks() as JsonResult;
            
            Assert.NotNull(books);
            Assert.NotEmpty(books.Value as IList<Book>);
        }

    }
}