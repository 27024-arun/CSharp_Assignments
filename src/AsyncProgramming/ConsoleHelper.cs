namespace AsyncProgramming
{
    internal static class ConsoleHelper
    {
        public static void WriteColored(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write($"{message}");
            Console.ResetColor();
        }

        public static void CleanConsole()
        {
            ConsoleHelper.WriteColored($"\nEnter any key to continue.", ConsoleColor.Yellow);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
