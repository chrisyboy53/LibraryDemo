using System.Collections.Generic;
using Homemade.Models;

namespace Homemade.Services
{
    /// <summary>
    /// Common interface for libraries
    /// </summary>
    public interface ILibrary {

        /// <summary>
        /// The books that are stored in the Library
        /// </summary>
        IList<Book> BookCollection { get; }

        /// <summary>
        /// Adds a new book to the Library
        /// </summary>
        /// <param name="book">New Book to add to Library</param>
        /// <returns>True or False if the book is added successfully</returns>
        bool AddBook(Book book);

        /// <summary>
        /// Remove a existing book in the library
        /// </summary>
        /// <param name="book">Book to remove in library</param>
        /// <returns>True or False if the book is removed successfully</returns>
        bool RemoveBook(Book book);

        /// <summary>
        /// Updates the book in the library collection
        /// </summary>
        /// <param name="book">Existing book to update</param>
        /// <returns>True or false to see if the book is updated successfully</returns>
        bool UpdateBook(Book book);
    }
}