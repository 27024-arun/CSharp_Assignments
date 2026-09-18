namespace AdvancedConcepts
{
    internal static class Helper
    {
        public static void CleanConsole()
        {
            Console.Write($"\nEnter a key to continue.");
            Console.ReadKey();
            Console.Clear();
        }
    }
}