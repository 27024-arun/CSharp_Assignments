namespace Collections
{
    /// <summary>
    /// Performs operation in IReadOnlyDictionary Collection.
    /// </summary>
    internal static class OperateDictionary
    {
        /// <summary>
        /// Performs function call for modifying dictionary.
        /// </summary>
        public static void ModifyDictionary()
        {
            GetUserData();
            Helper.CleanConsole();
        }

        private static void GetUserData()
        {
            Console.Write($@"============Dictionary Modifier============
Enter the count of user data to be added in dictionary: ");
            int.TryParse(Console.ReadLine(), out int userDataCount);
            if (userDataCount <= 0)
            {
                Helper.WriteColored($"Operation cannot be performed", ConsoleColor.Red);
                Helper.CleanConsole();
                return;
            }

            for (int iterator = 1;  iterator <= userDataCount; iterator++)
            {
                string name = GetName($"Enter user {iterator} name");
                int age = GetAge($"Enter user {iterator} age");
                IReadOnlyDictionary<string, int> dictionaryData = GenerateDictionary(name, age);
                PrintDictionary(dictionaryData);
            }
        }

        private static IReadOnlyDictionary<string, int> GenerateDictionary(string key, int value)
        {
            Dictionary<string, int> userData = new Dictionary<string, int>();
            userData.Add(key, value);
            return userData;
        }

        private static void PrintDictionary(IReadOnlyDictionary<string, int> dictionaryData)
        {
            foreach (var data in dictionaryData)
            {
                Console.WriteLine($"\nName: {data.Key}\nAge: {data.Value}\n");
            }
        }

        private static string GetName(string message)
        {
            string defaultName = "Parker";
            int maxTries = 3;
            string? userInput;
            for (int iterator = 1; iterator <= maxTries; iterator++)
            {
                Console.Write($"{message}: ");
                userInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(userInput))
                {
                    return userInput;
                }
                else
                {
                    Helper.WriteColored($"Data entered is invalid\n{3 - iterator} Tries left", ConsoleColor.Red);
                }
            }

            Helper.WriteColored($"Default name ({defaultName}) is returned", ConsoleColor.Yellow);
            return defaultName;
        }

        private static int GetAge(string message)
        {
            int defaultAge = 25;
            int maxTries = 3;
            string? userInput;
            for (int iterator = 1; iterator <= maxTries; iterator++)
            {
                Console.Write($"{message}: ");
                userInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(userInput) && int.TryParse(userInput, out int age) && age >= 1 && age <= 100)
                {
                    return age;
                }
                else
                {
                    Helper.WriteColored($"Data entered is invalid\n{3 - iterator} Tries left (Range: 1 - 100)", ConsoleColor.Red);
                }
            }

            Helper.WriteColored($"Default age ({defaultAge}) is returned", ConsoleColor.Yellow);
            return defaultAge;
        }
    }
}