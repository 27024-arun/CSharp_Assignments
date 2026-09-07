namespace Assignments
{
    internal class ListModifier
    {
        private static List<string> _books = new List<string>();

        private static int maxBooks = 5;

        internal static void ModifyList()
        {
            AddBooks();

            DisplayBooks();

            RemoveBook();

            DisplayBooks();

            CheckBook();

            CleanConsole();
        }

        private static void CheckBook()
        {
            Console.WriteLine("\n============Check whether a book exists============");

            string bookName = GetBookName("Book Name");
            if (_books.Contains(bookName, StringComparer.OrdinalIgnoreCase))
            {
                Console.WriteLine("Book exists in the list");
            }
            else
            {
                Console.WriteLine("Book doesn't exist is the list");
            }
        }

        private static void DisplayBooks()
        {
            int incrementor = 1;
            Console.WriteLine("\n============Books in the list============");
            foreach (string bookName in _books)
            {
                Console.WriteLine($"{incrementor++}. {bookName}");
            }
        }

        private static void RemoveBook()
        {
            Console.WriteLine("\n============Remove Book============");

            string bookName = GetBookName("Book Name");
            if (_books.Contains(bookName))
            {
                _books.Remove(bookName);
                Console.WriteLine("Book is removed successfully");
            }
            else
            {
                Console.WriteLine("Book doesn't exist is the list");
            }
        }

        private static void AddBooks()
        {
            Console.WriteLine("============Add Books============");
            Console.WriteLine("Enter 5 book names:");

            for (int iterator = 1; iterator <= maxBooks; iterator++)
            {
                string bookName = GetBookName($"Book {iterator} Name");
                _books.Add(bookName);
            }
        }

        private static string GetBookName(string bookName)
        {
            string defaultBookName = "SampleBook";
            int maxTries = 3;
            string? userInput;
            for (int iterator = 1; iterator <= maxTries; iterator++)
            {
                Console.Write($"{bookName}: ");
                userInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    return userInput.Trim();
                }
                else
                {
                    Console.WriteLine($"Data entered is invalid\n{3 - iterator} Tries left");
                }
            }

            Console.WriteLine("Default book name added");
            return defaultBookName;
        }

        private static void CleanConsole()
        {
            Console.WriteLine("\nEnter a key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}