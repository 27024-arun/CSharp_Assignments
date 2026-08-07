using Expense_Tracker.Models;
using Expense_Tracker.Services;

namespace Expense_Tracker.View
{
    internal class FinanceView
    {
        private readonly FinanceServices _services = new ();

        internal void AddExpense()
        {
            decimal amount = ViewHelper.GetDecimalData("Amount");

            if (amount <= 0)
            {
                return;
            }

            Console.WriteLine("\nCategories of Expense: ");
            foreach (var i in Enum.GetValues(typeof(ExpenseCategory)))
            {
                Console.WriteLine($"{(int)i}. {i}");
            }

            int categoryData = ViewHelper.GetIntData("Enter the type of Expense [1-7]: ");
            ExpenseCategory category = (ExpenseCategory)categoryData;

            DateOnly date = DateOnly.FromDateTime(DateTime.Now);
            this._services.AddExpense(amount, date, category);
            ViewHelper.WriteColored("Expense Added Successfully.", ConsoleColor.Green);
        }

        internal void AddIncome()
        {
            decimal amount = ViewHelper.GetDecimalData("Amount");

            if (amount <= 0)
            {
                return;
            }

            Console.WriteLine("\nCategories of Income: ");
            foreach (var i in Enum.GetValues(typeof(IncomeCategory)))
            {
                Console.WriteLine($"{(int)i}. {i}");
            }

            int categoryData = ViewHelper.GetIntData("Enter the type of Income [1-7]: ");
            IncomeCategory category = (IncomeCategory)categoryData;

            DateOnly date = DateOnly.FromDateTime(DateTime.Now);
            this._services.AddIncome(amount, date, category);
            ViewHelper.WriteColored("Income Added Successfully.", ConsoleColor.Green);
        }

        internal void DeleteExpense()
        {
            if (this._services.ExpenseIsEmpty())
            {
                ViewHelper.WriteColored("No Expense Records.", ConsoleColor.Red);
                return;
            }

            string id = ViewHelper.GetStringData("Enter Expense Id: ");

            if (this._services.DeleteExpense(id))
            {
                ViewHelper.WriteColored("Expense Deleted Successfully.", ConsoleColor.Green);
            }
            else
            {
                ViewHelper.WriteColored("Expense ID Not Found.", ConsoleColor.Red);
            }
        }

        internal void DeleteIncome()
        {
            if (this._services.IncomeIsEmpty())
            {
                ViewHelper.WriteColored("No Income Records.", ConsoleColor.Red);
                return;
            }

            string id = ViewHelper.GetStringData("Enter Income Id: ");

            if (this._services.DeleteIncome(id))
            {
                ViewHelper.WriteColored("Income Deleted Successfully.", ConsoleColor.Green);
            }
            else
            {
                ViewHelper.WriteColored("Income ID Not Found.", ConsoleColor.Red);
            }
        }

        internal void EditExpense()
        {
            if (this._services.ExpenseIsEmpty())
            {
                ViewHelper.WriteColored("No Expense Records.", ConsoleColor.Red);
                return;
            }

            string? id = ViewHelper.GetStringData("Id:");
            if (string.IsNullOrEmpty(id) || this._services.IsExpenseIdValid(id))
            {
                return;
            }

            decimal amount = ViewHelper.GetDecimalData("Amount");

            Console.WriteLine("\nCategories of Expense: ");
            foreach (var i in Enum.GetValues(typeof(ExpenseCategory)))
            {
                Console.WriteLine($"{(int)i}. {i}");
            }

            int categoryData = ViewHelper.GetIntData("Enter the type of expense [1-7]:");
            ExpenseCategory category = (ExpenseCategory)categoryData;

            DateOnly date = DateOnly.FromDateTime(DateTime.Now);
            this._services.EditExpense(id, amount, date, category);
        }

        internal void EditIncome()
        {
            if (this._services.IncomeIsEmpty())
            {
                ViewHelper.WriteColored("No Income Records.", ConsoleColor.Red);
                return;
            }

            string? id = ViewHelper.GetStringData("Id");

            decimal amount = ViewHelper.GetDecimalData("Income");

            Console.WriteLine("\nCategories of Income: ");
            foreach (var i in Enum.GetValues(typeof(IncomeCategory)))
            {
                Console.WriteLine($"{(int)i}. {i}");
            }

            int categoryData = ViewHelper.GetIntData("Enter the type of Income[1 - 7]:");
            IncomeCategory category = (IncomeCategory)categoryData;
            DateOnly date = DateOnly.FromDateTime(DateTime.Now);
            this._services.EditIncome(id, amount, date, category);
        }

        internal void ShowSummary()
        {
            decimal income = this._services.GetTotalIncome();
            decimal expense = this._services.GetTotalExpense();
            decimal balance = this._services.GetBalance();

            Console.WriteLine();

            Console.WriteLine($"Total Income  : {income}");
            Console.WriteLine($"Total Expense : {expense}");
            Console.WriteLine($"Balance       : {balance}");
        }

        internal void ViewExpense()
        {
            if (this._services.ExpenseIsEmpty())
            {
                ViewHelper.WriteColored("No Expense Records.", ConsoleColor.Red);
                return;
            }

            List<Expense> expense = this._services.ViewExpense();
            ViewHelper.PrintExpenseTabledFormat(expense);
        }

        internal void ViewIncome()
        {
            if (this._services.IncomeIsEmpty())
            {
                ViewHelper.WriteColored("No Income Records.", ConsoleColor.Red);
                return;
            }

            List<Income> income = this._services.ViewIncome();
            ViewHelper.PrintIncomeTabledFormat(income);
        }
    }
}