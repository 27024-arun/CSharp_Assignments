using Inventory_Management.Model;
using Spectre.Console;

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

        /// <summary>
        /// StringDataValidation method is used to validate the string input given by the user.
        /// </summary>
        /// <param name="data">Data is the string data given by the user.</param>
        /// <returns>Returns whether the data given by user is valid or not.</returns>
        public static bool StringDataValidation(string data)
        {
            if (string.IsNullOrEmpty(data) || string.IsNullOrWhiteSpace(data))
            {
                return false;
            }

            string trimmedName = data.Trim();
            if (!trimmedName.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// PrintingTable method is used to print the data in tabular format.
        /// </summary>
        /// <param name="products">Products are the products in the inventory.</param>
        public static void PrintingTable(List<InventoryModel> products)
        {
            var table = new Table()
                .Border(TableBorder.Rounded)
                .BorderColor(Color.White)
                .Title("[white]Inventory Products[/]\n");

            table.AddColumn(new TableColumn("[white]Product ID[/]").Centered());
            table.AddColumn(new TableColumn("[white]Product Name[/]").Centered());
            table.AddColumn(new TableColumn("[white]Price[/]").Centered());
            table.AddColumn("[white]Quantity[/]");

            foreach (InventoryModel product in products)
            {
                table.AddRow($"{product.ProductID}", $"{product.ProductName}", $"{product.Price}", $"{product.Quantity}");
            }

            AnsiConsole.Write(table);
        }

        /// <summary>
        /// GetIntData method is used to get integer input data from the user.
        /// </summary>
        /// <param name="variableName">It is the variable name for which the user input is assigned.</param>
        /// <returns>Returns the integer data got from the user.</returns>
        public static int GetIntData(string variableName)
        {
            int tries = 3;
            int data;
            for (int i = 1; i <= tries; i++)
            {
                Console.Write($"{variableName}: ");
                data = Convert.ToInt32(Console.ReadLine());
                if (data > 0)
                {
                    return data;
                }
                else
                {
                    WriteColored($"Data entered is invalid\n{3 - i} Tries left", ConsoleColor.Red);
                }
            }

            return 0;
        }

        /// <summary>
        /// GetStringData method is used to get string input data from the user.
        /// </summary>
        /// <param name="variableName">It is the variable name for which the user input is assigned.</param>
        /// <returns>Returns the string data got from the user.</returns>
        public static string GetStringData(string variableName)
        {
            int tries = 3;
            string data;
            for (int i = 1; i <= tries; i++)
            {
                Console.Write($"{variableName}: ");
                data = Console.ReadLine() !;
                if (StringDataValidation(data))
                {
                    return data;
                }
                else
                {
                    WriteColored($"Data entered is invalid\n{3 - i} Tries left", ConsoleColor.Red);
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// GetDecimalData method is used to get decimal input data from the user.
        /// </summary>
        /// <param name="v"> is the variable name for which the user input is assigned.</param>
        /// <returns>Returns the decimal data got from the user.</returns>
        public static decimal GetDecimalData(string v)
        {
            int tries = 3;
            decimal data;
            for (int i = 1; i <= tries; i++)
            {
                Console.Write($"{v}: ");
                data = Convert.ToDecimal(Console.ReadLine());
                if (data > 0)
                {
                    return data;
                }
                else
                {
                    WriteColored($"Data entered is invalid\n{3 - i} Tries left", ConsoleColor.Red);
                }
            }

            return 0;
        }
    }
}
