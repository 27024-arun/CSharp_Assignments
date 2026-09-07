namespace Assignments
{
    internal class StackModifier
    {
        private static Stack<char> _characterStack = new Stack<char>();

        internal static void ModifyStack()
        {
            Console.WriteLine("============Enter a word============");
            string word = GetWord();
            int wordLength = word.Length;
            Console.WriteLine($"\nEntered word is {word}");

            AddIntoStack(word, wordLength);

            ReverseWord(wordLength);

            CleanConsole();
        }

        private static void ReverseWord(int wordLength)
        {
            string reversedWord = string.Empty;
            for (int index = 1; index <= wordLength; index++)
            {
                reversedWord += _characterStack.Pop();
            }

            Console.WriteLine($"\nReversed word is {reversedWord}");
        }

        private static void AddIntoStack(string word, int wordLength)
        {
            Console.WriteLine("\n============Adding letters of word into stack============");
            for (int index = 1; index <= wordLength; index++)
            {
                Thread.Sleep(1000);
                _characterStack.Push(word[index - 1]);
                Console.WriteLine($"Letter {word[index - 1]} is pushed into stack");
            }
        }

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
                    Console.WriteLine($"Data entered is invalid\n{3 - iterator} Tries left");
                }
            }

            Console.WriteLine($"Default word ({defaultWord}) is returned");
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