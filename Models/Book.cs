using System;
using System.ComponentModel.DataAnnotations;

namespace Homemade.Models
{

    /// <summary>
    /// Standard book
    /// </summary>
    public class Book {

        /// <summary>
        /// Unique Identifier for books in libraries
        /// </summary>
        /// <returns>Book Id</returns>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Title of the book
        /// </summary>
        /// <returns>The title of the book</returns>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// The Author of the book
        /// </summary>
        /// <returns>The Author</returns>
        [Required]
        public string Author { get; set; }

        /// <summary>
        /// The date the book was published
        /// </summary>
        /// <returns>Publish Date</returns>
        [Required]
        public DateTime PublishDate { get; set; }

        /// <summary>
        /// Creates new instance of a standard book
        /// </summary>
        /// <param name="id">Unique Identifier for Library</param>
        /// <param name="title">Title of the book</param>
        /// <param name="author">Author of the book</param>
        /// <param name="publishDate">Publish date of the book</param>
        public Book (int id, string title, string author, DateTime publishDate)
        {
            this.Id = id;
            this.Title = title;
            this.Author = author;
            this.PublishDate = publishDate;
        }

        public Book () {

        }
    }

}