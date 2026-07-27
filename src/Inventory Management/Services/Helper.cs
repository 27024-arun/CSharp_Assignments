namespace Inventory_Management.Services
{
    /// <summary>
    /// Helper class is used to perform additional operations in the project.
    /// </summary>
    public class Helper
    {
        /// <summary>
        /// WriteColored method is used to print colored message.
        /// </summary>
        /// <param name="message">Message is the text that is needed to be displayed.</param>
        /// <param name="color">Color is color in what the message needed to be displayed.</param>
        public static void WriteColored(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
