namespace Collections
{
    /// <summary>
    /// Performs arithmetic operation for multiple collections.
    /// </summary>
    internal class ArithmeticOperator
    {
        /// <summary>
        /// Asks user choice for collection usage.
        /// </summary>
        internal static void PerformAddition()
        {
            while (true)
            {
                Console.Clear();
                string userMenu = $@"
============Arithmetic Sum============
[A]rray
[L]ist
[Q]ueue
[R]eturn to main menu

Enter Choice: ";
                Console.Write(userMenu);
                ConsoleKey userChoice = Console.ReadKey().Key;
                Console.Clear();
                switch (userChoice)
                {
                    case ConsoleKey.A:
                        AddArray();
                        break;
                    case ConsoleKey.L:
                        AddList();
                        break;
                    case ConsoleKey.Q:
                        AddQueue();
                        break;
                    case ConsoleKey.R:
                        return;
                    default:
                        Helper.WriteColored("Invalid Choice", ConsoleColor.Red);
                        Thread.Sleep(1000);
                        break;
                }
            }
        }

        private static void AddQueue()
        {
            Console.Write($@"============Queue============
Enter the length of queue: ");
            int.TryParse(Console.ReadLine(), out int queueSize);
            if (queueSize <= 0)
            {
                Helper.WriteColored($"Operation cannot be performed", ConsoleColor.Red);
                Thread.Sleep(1000);
                return;
            }

            Queue<int> userQueue = new Queue<int>();
            for (int iterator = 1; iterator <= queueSize; iterator++)
            {
                int data = GetNumber($"\nEnter number {iterator}");
                userQueue.Enqueue(data);
            }

            decimal arrayAdditionResult = SumOfElements(userQueue);
            Helper.WriteColored($"\nAddition result of user queue is : {arrayAdditionResult}", ConsoleColor.Green);
            Helper.CleanConsole();
        }

        private static void AddList()
        {
            Console.Write($@"============List============
Enter the length of list: ");
            int.TryParse(Console.ReadLine(), out int listSize);
            if (listSize <= 0)
            {
                Helper.WriteColored($"Operation cannot be performed", ConsoleColor.Red);
                Thread.Sleep(1000);
                return;
            }

            List<int> userList = new List<int>();
            for (int iterator = 1; iterator <= listSize; iterator++)
            {
                int data = GetNumber($"\nEnter number {iterator}");
                userList.Add(data);
            }

            decimal arrayAdditionResult = SumOfElements(userList);
            Helper.WriteColored($"\nAddition result of user list is : {arrayAdditionResult}", ConsoleColor.Green);
            Helper.CleanConsole();
        }

        private static void AddArray()
        {
            Console.Write($@"============Array============
Enter the length of array: ");
            int.TryParse(Console.ReadLine(), out int arrayLength);
            if (arrayLength <= 0)
            {
                Helper.WriteColored($"Operation cannot be performed", ConsoleColor.Red);
                Thread.Sleep(1000);
                return;
            }

            int[] userArray = new int[arrayLength];
            for (int index = 1; index <= arrayLength; index++)
            {
                int data = GetNumber($"\nEnter number {index}");
                userArray[index - 1] = data;
            }

            decimal arrayAdditionResult = SumOfElements(userArray);
            Helper.WriteColored($"\nAddition result of user array is : {arrayAdditionResult}", ConsoleColor.Green);
            Helper.CleanConsole();
        }

        private static int SumOfElements(IEnumerable<int> integerData)
        {
            int sum = 0;
            foreach (var integer in integerData)
            {
                sum += integer;
            }

            return sum;
        }

        private static int GetNumber(string message)
        {
            int defaultValue = 0;
            int maxTries = 3;
            string? userInput;
            for (int iterator = 1; iterator <= maxTries; iterator++)
            {
                Console.Write($"{message}: ");
                userInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(userInput) && int.TryParse(userInput, out int value))
                {
                    return value;
                }
                else
                {
                    Helper.WriteColored($"Data entered is invalid\n{3 - iterator} Tries left", ConsoleColor.Red);
                }
            }

            Helper.WriteColored($"Default value ({defaultValue}) is returned", ConsoleColor.Yellow);
            return defaultValue;
        }
    }
}