using System.Security.Cryptography;

namespace Task6
{
    internal record Book
    {
        public Book(string title, string author, long isbn)
        {
            this.Title = title;
            this.Author = author;
            this.bookNumber = isbn;
        }

        public void Deconstruct(out string title, out string author, out long isbn)
        {
            title = this.Title;
            author = this.Author;
            isbn = this.bookNumber;
        }

        public string Title { get; init; } = string.Empty;

        public string Author { get; init; } = string.Empty;

        public long bookNumber { get; init; }
    }
}
