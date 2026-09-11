namespace Collections
{
    /// <summary>
    /// Performs display and manipulation of stack data.
    /// </summary>
    /// <typeparam name="T">Generic type</typeparam>
    internal class StackModifier<T>
        where T : struct
    {
        private static Stack<T> _characterStack = new Stack<T>();

        /// <summary>
        /// Calls methods to operate stack data.
        /// </summary>
        internal static void OperateStack()
        {
            Console.WriteLine("============Enter a word============");
            string word = GetWord();
            int wordLength = word.Length;
            Console.WriteLine($"\nEntered word is {word}");

            AddIntoStack(word, wordLength);

            ReverseWord(wordLength);

            Helper.CleanConsole();
        }

        /// <summary>
        /// Pops the data from stack and displays it to user.
        /// </summary>
        /// <param name="wordLength">Length of the word to be reversed.</param>
        private static void ReverseWord(int wordLength)
        {
            string reversedWord = string.Empty;
            for (int index = 1; index <= wordLength; index++)
            {
                reversedWord += _characterStack.Pop();
            }

            Console.Write($"\nReversed word is ");
            Helper.WriteColored($"\"{reversedWord}\"", ConsoleColor.Yellow);
        }

        /// <summary>
        /// Adds data into the stack
        /// </summary>
        /// <param name="word">Word in which letters are pushed into the stack.</param>
        /// <param name="wordLength">Length of the word to be reversed.</param>
        private static void AddIntoStack(string word, int wordLength)
        {
            Console.WriteLine("\n============Adding letters of word into stack============");
            for (int index = 1; index <= wordLength; index++)
            {
                Thread.Sleep(1000);
                _characterStack.Push((T)(object)word[index - 1]);
                Helper.WriteColored($"Letter \"{word[index - 1]}\" is pushed into stack", ConsoleColor.Green);
            }
        }

        /// <summary>
        /// Retrieves a work from user and performs validation.
        /// </summary>
        /// <returns>Word to be reversed.</returns>
        private static string GetWord()
        {
            string defaultWord = "Catastrophe";
            int maxTries = 3;
            string? userInput;
            for (int iterator = 1; iterator <= maxTries; iterator++)
            {
                Console.Write($"Word: ");
                userInput = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(userInput))
                {
                    return userInput.Trim();
                }
                else
                {
                    Helper.WriteColored($"Data entered is invalid\n{3 - iterator} Tries left", ConsoleColor.Red);
                }
            }

            Helper.WriteColored($"Default word ({defaultWord}) is returned", ConsoleColor.Yellow);
            return defaultWord;
        }
    }
}