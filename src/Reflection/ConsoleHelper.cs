namespace Reflection
{
    /// <summary>
    /// Performs console clearing operations.
    /// </summary>
    public static class ConsoleHelper
    {
        /// <summary>
        /// Clears console for clean interface and smooth user experience.
        /// </summary>
        public static void CleanConsole()
        {
            Console.Write($"\nEnter a key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
