using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Homemade.Models;
using Homemade.DataAccess;

namespace Homemade.Services
{
    /// <summary>
    /// Standard Library able to add, remove, and update books
    /// </summary>
    public class Library : ILibrary
    {
        IDataAccess<Book> _dbAccess = null;
        ILogger<Library> _logger = null;

        /// <summary>
        /// The current state of the Library collection of books
        /// </summary>
        /// <returns>Collection of books</returns>
        public IList<Book> BookCollection { 
            get 
            {
                var books = _dbAccess.GetList();
                _logger.LogTrace("Getting List of books:\r\n" + JsonConvert.SerializeObject(books));
                return books; 
            } 
        }

        public Library(IDataAccess<Book> bookDataAccess, ILogger<Library> logger) {
            _dbAccess = bookDataAccess;
            _logger = logger;
        }

        /// <summary>
        /// Adds a new book to the Library
        /// </summary>
        /// <param name="book">New Book to add to Library</param>
        /// <returns>True or False if the book is added successfully</returns>
        public bool AddBook(Book book) {
            _logger.LogTrace("Adding book:\r\n" + JsonConvert.SerializeObject(book));
            return _dbAccess.Insert(book);
        }

        /// <summary>
        /// Remove a existing book in the library
        /// </summary>
        /// <param name="book">Book to remove in library</param>
        /// <returns>True or False if the book is removed successfully</returns>
        public bool RemoveBook(Book book) {
            _logger.LogTrace("Removing book:\r\n" + JsonConvert.SerializeObject(book));
            return _dbAccess.Delete(book);
        }

        /// <summary>
        /// Updates the book in the library collection
        /// </summary>
        /// <param name="book">Existing book to update</param>
        /// <returns>True or false to see if the book is updated successfully</returns>
        public bool UpdateBook(Book book) {
            _logger.LogTrace("Updating book:\r\n" + JsonConvert.SerializeObject(book));
            return _dbAccess.Update(book);
        }

    }
}