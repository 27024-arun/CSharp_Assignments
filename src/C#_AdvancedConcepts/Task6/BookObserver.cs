using AdvancedConcepts;

namespace Task6
{
    internal class BookObserver
    {
        private List<Book> _books = new List<Book>();

        public void ViewBooks()
        {
            this.PopulateBooks();

            Console.WriteLine($@"
===========Record Usage===========
Details in the book record");
            int index = 0;
            foreach (var book in this._books)
            {
                Console.WriteLine($@"{++index}. Name: {book.Title}
Author:{book.Author}
ISBN: {book.bookNumber}" + Environment.NewLine);
            }

            Console.WriteLine($"Are book 5 and book 6 same? : {this._books[4] == this._books[5]}\n");

            Book sampleBook = this._books[0] with { Author = "Arun" };

            Console.WriteLine($@"Created a new book with modified book 1 author name
Name: {sampleBook.Title} 
Author:{sampleBook.Author} 
ISBN: {sampleBook.bookNumber}");

            Console.Write("\nDeconstruction Processed data");
            var (deconstructedTitle, deconstructedAuthor, deconstructedBookNumber) = sampleBook;
            Console.WriteLine($@"
Name: {deconstructedTitle} 
Author:{deconstructedAuthor} 
ISBN: {deconstructedBookNumber}");

            Helper.CleanConsole();
        }

        private void PopulateBooks()
        {
            this._books.Add(new Book("Ponniyin Selvan", "Kalki", 193473834));
            this._books.Add(new Book("Harry Potter", "Rowling", 495784578));
            this._books.Add(new Book("Thirukkural", "Thiruvalluvar", 834787473));
            this._books.Add(new Book("Ramayanam", "Vaalmiki", 985748934));
            this._books.Add(new Book("Tenet", "Christopher Nolan", 638463732));
            this._books.Add(new Book("Tenet", "Christopher Nolan", 638463732));
        }
    }
}
