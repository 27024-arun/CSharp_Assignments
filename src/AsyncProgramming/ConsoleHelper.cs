namespace AsyncProgramming
{
    /// <summary>
    /// Enhances console writing and displaying activities.
    /// </summary>
    internal static class ConsoleHelper
    {
        /// <summary>
        /// Displays data in console in colored format.
        /// </summary>
        /// <param name="message">Message to displayed in console.</param>
        /// <param name="color">Color in which the message needs to be displayed.</param>
        public static void WriteColored(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write($"{message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Clears console for better user experience.
        /// </summary>
        public static void CleanConsole()
        {
            ConsoleHelper.WriteColored($"\nEnter any key to continue.", ConsoleColor.Yellow);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
