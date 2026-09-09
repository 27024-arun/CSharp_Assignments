namespace Collections
{
    /// <summary>
    /// Performs console display operations.
    /// </summary>
    public static class Helper
    {
        /// <summary>
        /// Displays the data to user in console in colored format.
        /// </summary>
        /// <param name="message">Message to be displayed to user.</param>
        /// <param name="color">Color in which message need to be displayed.</param>
        public static void WriteColored(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        /// <summary>
        /// Performs clearing console for clean user experience.
        /// </summary>
        public static void CleanConsole()
        {
            Console.WriteLine("\nEnter a key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
