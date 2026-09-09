namespace Collections
{
    /// <summary>
    /// Performs display and manipulation list data.
    /// </summary>
    /// <typeparam name="T">Generic type.</typeparam>
    internal class ListModifier<T>
        where T : class
    {
        private static List<T> _books = new List<T>();

        private static int maxBooks = 5;

        /// <summary>
        /// Calls methods to modify the list.
        /// </summary>
        internal static void ModifyList()
        {
            AddBooks();

            DisplayBooks();

            RemoveBook();

            DisplayBooks();

            CheckBook();

            Helper.CleanConsole();
        }

        /// <summary>
        /// Checks whether a book exists in the list and display the result.
        /// </summary>
        private static void CheckBook()
        {
            Console.WriteLine("\n============Check whether a book exists============");

            T bookName = GetBookName("Book Name");
            if (_books.Contains(bookName))
            {
                Helper.WriteColored("Book exists in the list", ConsoleColor.Green);
            }
            else
            {
                Helper.WriteColored("Book doesn't exist is the list", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Displays the books in the list in console.
        /// </summary>
        private static void DisplayBooks()
        {
            int incrementor = 1;
            Console.WriteLine("\n============Books in the list============");
            foreach (T bookName in _books)
            {
                Console.WriteLine($"{incrementor++}. {bookName}");
            }
        }

        /// <summary>
        /// Removes a particular book in the list and indicates the process result.
        /// </summary>
        private static void RemoveBook()
        {
            Console.WriteLine("\n============Remove Book============");

            T bookName = GetBookName("Book Name");
            if (_books.Contains(bookName))
            {
                _books.Remove(bookName);
                Helper.WriteColored("Book is removed successfully", ConsoleColor.Green);
            }
            else
            {
                Helper.WriteColored("Book doesn't exist is the list", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Retrieves book names from user and adds the data to the list.
        /// </summary>
        private static void AddBooks()
        {
            Console.WriteLine("============Add Books============");
            Console.WriteLine("Enter 5 book names:");

            for (int iterator = 1; iterator <= maxBooks; iterator++)
            {
                T bookName = GetBookName($"\nBook {iterator} Name");
                _books.Add(bookName);
                Helper.WriteColored($"{bookName} is added into the list", ConsoleColor.Green);
            }
        }

        /// <summary>
        /// Retrieves the name of the book from user and performs validation.
        /// </summary>
        /// <param name="bookName">Name of the book.</param>
        /// <returns>Book name</returns>
        private static T GetBookName(string bookName)
        {
            string defaultBookName = "SampleBook";
            int maxTries = 3;
            string? userInput;
            for (int iterator = 1; iterator <= maxTries; iterator++)
            {
                Console.Write($"{bookName}: ");
                userInput = Console.ReadLine();
                if (typeof(T) == typeof(string) && !string.IsNullOrWhiteSpace(userInput))
                {
                    return (T)(object)userInput.Trim();
                }
                else
                {
                    Helper.WriteColored($"Data entered is invalid\n{3 - iterator} Tries left", ConsoleColor.Red);
                }
            }

            Helper.WriteColored($"Default book name ({defaultBookName}) returned", ConsoleColor.Yellow);
            return (T)(object)defaultBookName;
        }
    }
}