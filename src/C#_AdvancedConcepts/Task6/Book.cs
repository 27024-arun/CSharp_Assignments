using System.Security.Cryptography;

namespace Task6
{
    internal record Book
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="title">Title of the book</param>
        /// <param name="author">Author name of the book</param>
        /// <param name="bookNumber">International book number of the book</param>
        public Book(string title, string author, long bookNumber)
        {
            this.Title = title;
            this.Author = author;
            this.BookNumber = bookNumber;
        }

        /// <summary>
        /// Helps to deconstruct data.
        /// </summary>
        /// <param name="title">Title of the book</param>
        /// <param name="author">Author name of the book</param>
        /// <param name="bookNumber">International book number of the book</param>
        public void Deconstruct(out string title, out string author, out long bookNumber)
        {
            title = this.Title;
            author = this.Author;
            bookNumber = this.BookNumber;
        }

        /// <summary>
        /// Gets the title of the book.
        /// </summary>
        /// <value>Title of the product.</value>
        public string Title { get; init; } = string.Empty;

        /// <summary>
        /// Gets the author name of the book.
        /// </summary>
        /// <value>Author name of the book.</value>
        public string Author { get; init; } = string.Empty;

        /// <summary>
        /// Gets the book number..
        /// </summary>
        /// <value>book number of the book.</value>
        public long BookNumber { get; init; }
    }
}
