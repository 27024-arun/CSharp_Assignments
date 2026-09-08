namespace Assignments
{
    internal class ListModifier<T>
        where T : class
    {
        private static List<T> _books = new List<T>();

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

            T bookName = GetBookName("Book Name");
            if (_books.Contains(bookName))
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
            foreach (T bookName in _books)
            {
                Console.WriteLine($"{incrementor++}. {bookName}");
            }
        }

        private static void RemoveBook()
        {
            Console.WriteLine("\n============Remove Book============");

            T bookName = GetBookName("Book Name");
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
                T bookName = GetBookName($"Book {iterator} Name");
                _books.Add(bookName);
            }
        }

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
                    Console.WriteLine($"Data entered is invalid\n{3 - iterator} Tries left");
                }
            }

            Console.WriteLine("Default book name added");
            return (T)(object)defaultBookName;
        }

        private static void CleanConsole()
        {
            Console.WriteLine("\nEnter a key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}