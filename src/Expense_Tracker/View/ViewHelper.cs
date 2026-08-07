using ConsoleTables;
using Expense_Tracker.Models;

namespace Expense_Tracker.View
{
    internal class ViewHelper
    {
        private static readonly FinanceView View = new ();

        public static void WriteColored(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        internal static void ExpenseOptions()
        {
            Console.Clear();
            while (true)
            {
                string expenseMenu = $@"
Expense Options

1. Add Expense
2. View Expense
3. Edit Expense
4. Delete Expense
5. Return to Main menu
Enter Choice: ";
                Console.WriteLine(expenseMenu);
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case (int)ExpenseMenu.AddExpense:
                        View.AddExpense();
                        break;
                    case (int)ExpenseMenu.ViewExpense:
                        View.ViewExpense();
                        break;
                    case (int)ExpenseMenu.EditExpense:
                        View.EditExpense();
                        break;
                    case (int)ExpenseMenu.DeleteExpense:
                        View.DeleteExpense();
                        break;
                    case (int)ExpenseMenu.ReturnToMainMenu:
                        Console.Clear();
                        return;
                    default:
                        ViewHelper.WriteColored("Invalid Choice", ConsoleColor.Red);
                        break;
                }
            }
        }

        internal static void IncomeOptions()
        {
            Console.Clear();
            while (true)
            {
                string incomeMenu = $@"
Expense Options

1. Add Income
2. View Income
3. Edit Income
4. Delete Income
5. Return to Main menu
Enter Choice: ";
                Console.WriteLine(incomeMenu);
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case (int)IncomeMenu.AddIncome:
                        View.AddIncome();
                        break;
                    case (int)IncomeMenu.ViewIncome:
                        View.ViewIncome();
                        break;
                    case (int)IncomeMenu.EditIncome:
                        View.EditIncome();
                        break;
                    case (int)IncomeMenu.DeleteIncome:
                        View.DeleteIncome();
                        break;
                    case (int)IncomeMenu.ReturnToMainMenu:
                        Console.Clear();
                        return;
                    default:
                        ViewHelper.WriteColored("Invalid Choice", ConsoleColor.Red);
                        break;
                }
            }
        }

        internal static void PrintExpenseTabledFormat(List<Expense> expenses)
        {
            var table = new ConsoleTable("Id", "Income Amount", "Date", "Category");
            foreach (Expense expense in expenses)
            {
                table.AddRow(expense.Id, expense.Amount, expense.Date, expense.Category);
            }

            table.Write(Format.Alternative);
        }

        internal static void PrintIncomeTabledFormat(List<Income> incomes)
        {
            var table = new ConsoleTable("Id", "Income Amount", "Date", "Category");
            foreach (Income income in incomes)
            {
                table.AddRow(income.Id, income.Amount, income.Date, income.Category);
            }

            table.Write(Format.Alternative);
        }

        public static decimal GetDecimalData(string variableName)
        {
            int tries = 3;
            decimal data;
            for (int i = 1; i <= tries; i++)
            {
                Console.Write($"{variableName}: ");
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

        public static int GetIntData(string messageName)
        {
            int tries = 3;
            int data;
            for (int i = 1; i <= tries; i++)
            {
                Console.Write($"{messageName}");
                data = Convert.ToInt32(Console.ReadLine());
                if (data >= 1 && data <= 7)
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

        public static string GetStringData(string variableName)
        {
            int tries = 3;
            string? data;
            for (int i = 1; i <= tries; i++)
            {
                Console.Write($"{variableName}: ");
                data = Console.ReadLine();
                if (!string.IsNullOrEmpty(data))
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
    }
}
