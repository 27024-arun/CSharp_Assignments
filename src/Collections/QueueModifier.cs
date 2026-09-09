namespace Collections
{
    /// <summary>
    /// Performs display and manipulation of queue data.
    /// </summary>
    /// <typeparam name="T">Generic type.</typeparam>
    internal class QueueModifier<T>
        where T : class
    {
        private static Queue<T> _personQueue = new Queue<T>();
        private static int maxQueueSize = 5;

        /// <summary>
        /// Calls methods to modify the queue.
        /// </summary>
        internal static void ModifyQueue()
        {
            EnqueuePeople();

            DisplayPeople();

            DequeuePeople();

            Helper.CleanConsole();
        }

        /// <summary>
        /// Dequeue data from the queue.
        /// </summary>
        private static void DequeuePeople()
        {
            Console.WriteLine("\n============Dequeue list============");
            for (int iterator = 1; iterator <= maxQueueSize; iterator++)
            {
                Thread.Sleep(1000);
                T personName = _personQueue.Dequeue();
                Helper.WriteColored($"{personName} is Dequeued", ConsoleColor.Green);
            }
        }

        /// <summary>
        /// Displays the data in the queue.
        /// </summary>
        private static void DisplayPeople()
        {
            int incrementor = 1;

            Console.WriteLine("\n============The name of persons in the queue============");
            foreach (T person in _personQueue)
            {
                Console.WriteLine($"{incrementor++}. {person}");
            }
        }

        /// <summary>
        /// Enqueues data into the queue.
        /// </summary>
        private static void EnqueuePeople()
        {
            Console.WriteLine("============Enter name of people to enqueue============");
            for (int iterator = 1; iterator <= maxQueueSize; iterator++)
            {
                T personName = GetPersonName($"\nPerson {iterator} Name");
                _personQueue.Enqueue(personName);
                Helper.WriteColored($"{personName} is Enqueued", ConsoleColor.Green);
            }
        }

        /// <summary>
        /// Retrieves data from user and performs validation.
        /// </summary>
        /// <param name="message">Message to be displayed to user for retrieving data.</param>
        /// <returns>Data to be inserted into queue.</returns>
        private static T GetPersonName(string message)
        {
            string defaultWord = "Peter";
            int maxTries = 3;
            string? userInput;
            for (int iterator = 1; iterator <= maxTries; iterator++)
            {
                Console.Write($"{message}: ");
                userInput = Console.ReadLine();
                if (typeof(T) == typeof(string) && !string.IsNullOrWhiteSpace(userInput) && !_personQueue.Contains((T)(object)userInput.Trim()))
                {
                    return (T)(object)userInput.Trim();
                }
                else
                {
                    Helper.WriteColored($"Data entered is invalid\n{3 - iterator} Tries left", ConsoleColor.Red);
                }
            }

            Helper.WriteColored($"Default name ({defaultWord}) is returned", ConsoleColor.Yellow);
            return (T)(object)defaultWord;
        }
    }
}