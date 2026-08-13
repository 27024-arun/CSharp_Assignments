using ConsoleTables;
using EnhancedExpenseTracker.Model;
using EnhancedExpenseTracker.Services;

namespace EnhancedExpenseTracker.View
{
    internal class ViewHelper
    {
        internal static void WriteColored(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        internal static decimal GetAmount()
        {
            for (int i = 1; i <= 3; i++)
            {
                Console.Write("Amount: ");
                if (decimal.TryParse(Console.ReadLine(), out decimal amount) && amount > 0)
                {
                    return amount;
                }

                WriteColored($"Data entered is invalid\n{3 - i} Tries left", ConsoleColor.Red);
            }

            WriteColored("Returning to menu.", ConsoleColor.Yellow);
            return 0;
        }

        internal static string GetCategory(TransactionTypes type)
        {
            string[] categories;

            if (type == TransactionTypes.Income)
            {
                categories = [ "Salary", "Freelancing", "Bonus", "Interest", "Rental", "Stipend", "Others"];
            }
            else
            {
                categories = ["Food", "Transport", "Shopping", "Bills", "Entertainment", "Healthcare", "Others"];
            }

            Console.WriteLine($"\n{type} Categories:");

            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {categories[i]}");
            }

            for (int i = 1; i <= 3; i++)
            {
                Console.Write("Enter Category [1-7]: ");

                if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= 7)
                {
                    return categories[choice - 1];
                }

                WriteColored($"Data entered is invalid\n{3 - i} Tries left", ConsoleColor.Red);
            }

            WriteColored("Returning to menu.", ConsoleColor.Yellow);
            return string.Empty;
        }

        internal static DateOnly GetDate()
        {
            for (int i = 1; i <= 3; i++)
            {
                Console.Write("Date (DD/MM/YYYY): ");

                if (DateOnly.TryParse(Console.ReadLine(), out DateOnly date) && date <= DateOnly.FromDateTime(DateTime.Now))
                {
                    return date;
                }

                WriteColored($"Data entered is invalid\n{3 - i} Tries left", ConsoleColor.Red);
            }

            WriteColored("Today's date is set as default.", ConsoleColor.Yellow);
            return DateOnly.FromDateTime(DateTime.Now);
        }

        internal static string GetTransactionId(string message, TransactionServices services, TransactionTypes type)
        {
            for (int i = 1; i <= 3; i++)
            {
                Console.Write($"{message}: ");
                string? id = Console.ReadLine();
                if (!string.IsNullOrEmpty(id) && services.IsIdValid(id))
                {
                    TransactionModel? transaction = services.GetTransactionById(id);
                    if (transaction != null && transaction.TransactionType == type)
                    {
                        return id;
                    }
                }

                WriteColored($"Data entered is invalid\n{3 - i} Tries left", ConsoleColor.Red);
            }

            WriteColored("Returning to menu.", ConsoleColor.Yellow);
            return string.Empty;
        }

        internal static void PrintTransactionTable(List<TransactionModel> transactions)
        {
            var table = new ConsoleTable("ID", "Amount", "Date", "Category");
            foreach (TransactionModel transaction in transactions)
            {
                table.AddRow(transaction.Id, transaction.Amount, transaction.Date, transaction.Category);
            }
            table.Write(Format.Alternative);
        }
    }
}
