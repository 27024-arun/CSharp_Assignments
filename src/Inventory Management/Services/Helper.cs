using System.Text;
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
        /// ValidateData method is used to validate the user input given by the user.
        /// </summary>
        /// <param name="product">Product is the details of the product.</param>
        /// <returns>Returns whether the data given by user is valid or not.</returns>
        public static bool ValidateData(InventoryModel product)
        {
            string trimmedName = product.ProductName.Trim();
            if (!trimmedName.All(c => char.IsLetter(c)))
            {
                return true;
            }

            if ((product.ProductID <= 0) || (product.Price <= 0) || (product.Quantity < 0) 
                || (string.IsNullOrWhiteSpace(product.ProductName)))
            {
                return true;
            }

            return false;
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
    }
}
