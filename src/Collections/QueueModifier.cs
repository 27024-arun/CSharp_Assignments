namespace Assignments
{
    internal class QueueModifier
    {
        private static Queue<string> _personQueue = new Queue<string>();
        private static int maxQueueSize = 5;

        internal static void ModifyQueue()
        {
            EnqueuePeople();

            DisplayPeople();

            DequeuePeople();

            CleanConsole();
        }

        private static void DequeuePeople()
        {
            Console.WriteLine("\n============Dequeue list============");
            for (int iterator = 1; iterator <= maxQueueSize; iterator++)
            {
                Thread.Sleep(1000);
                string personName = _personQueue.Dequeue();
                Console.WriteLine($"{personName} is Dequeued");
            }
        }

        private static void DisplayPeople()
        {
            int incrementor = 1;

            Console.WriteLine("\n============The name of persons in the queue============");
            foreach (string person in _personQueue)
            {
                Console.WriteLine($"{incrementor++}. {person}");
            }
        }

        private static void EnqueuePeople()
        {
            Console.WriteLine("============Enter name of people to enqueue============");
            for (int iterator = 1; iterator <= maxQueueSize; iterator++)
            {
                string personName = GetPersonName($"\nPerson {iterator} Name");
                _personQueue.Enqueue(personName);
                Console.WriteLine($"{personName} is Enqueued");
            }
        }

        private static string GetPersonName(string message)
        {
            string defaultWord = "Peter";
            int maxTries = 3;
            string? userInput;
            for (int iterator = 1; iterator <= maxTries; iterator++)
            {
                Console.Write($"{message}: ");
                userInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(userInput) && !_personQueue.Contains(userInput.Trim(), StringComparer.OrdinalIgnoreCase))
                {
                    return userInput.Trim();
                }
                else
                {
                    Console.WriteLine($"Data entered is invalid\n{3 - iterator} Tries left");
                }
            }

            Console.WriteLine($"Default name ({defaultWord}) is returned");
            return defaultWord;
        }

        private static void CleanConsole()
        {
            Console.WriteLine("\nEnter a key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}