namespace AdvancedConcepts
{
    /// <summary>
    /// Performs console operation for interactive user experience.
    /// </summary>
    internal static class Helper
    {
        /// <summary>
        /// Performs clearing console for user experience.
        /// </summary>
        public static void CleanConsole()
        {
            Console.Write($"\nEnter a key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}