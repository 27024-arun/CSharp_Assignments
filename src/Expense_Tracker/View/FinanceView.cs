using Expense_Tracker.Models;
using Expense_Tracker.Services;
using Expense_Tracker.View;

namespace Expense_Tracker.View
{
    internal class FinanceView
    {
        private readonly FinanceServices _services = new ();

        internal void AddExpense()
        {
            Console.WriteLine("Enter the expense amount:");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter the category of expense: ");
            foreach (var i in Enum.GetValues(typeof(ExpenseCategory)))
            {
                Console.WriteLine($"{(int)i}. {i}");
            }

            Console.WriteLine("Enter the type of Expense [1-7]:");
            ExpenseCategory category = (ExpenseCategory)Convert.ToInt32(Console.ReadLine());
            DateTime date = DateTime.Today;
            this._services.AddExpense(amount, date, category);
        }

        internal void AddIncome()
        {
            Console.WriteLine("Enter the income amount:");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter the category of income: ");
            foreach (var i in Enum.GetValues(typeof(IncomeCategory)))
            {
                Console.WriteLine($"{(int)i}. {i}");
            }

            Console.WriteLine("Enter the type of Income [1-6]:");
            IncomeCategory category = (IncomeCategory)Convert.ToInt32(Console.ReadLine());
            DateTime date = DateTime.Today;
            this._services.AddIncome(amount, date, category);
        }

        internal void DeleteExpense()
        {
            if (this._services.ExpenseIsEmpty())
            {
                ViewHelper.WriteColored("No Expense Records.", ConsoleColor.Red);
                return;
            }

            Console.Write("Enter Expense ID: ");
            string id = Console.ReadLine() !;

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

            Console.Write("Enter Income ID: ");
            string id = Console.ReadLine() !;

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

            Console.WriteLine("Enter the Id of the Expense you want to edit:");
            string? id = Console.ReadLine();
            Console.WriteLine("Enter the expense amount:");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter the category of expense: ");
            foreach (var i in Enum.GetValues(typeof(ExpenseCategory)))
            {
                Console.WriteLine($"{(int)i}. {i}");
            }

            Console.WriteLine("Enter the type of expense [1-7]:");
            ExpenseCategory category = (ExpenseCategory)Convert.ToInt32(Console.ReadLine());
            DateTime date = DateTime.Today;
            this._services.EditExpense(id, amount, date, category);
        }

        internal void EditIncome()
        {
            if (this._services.IncomeIsEmpty())
            {
                ViewHelper.WriteColored("No Income Records.", ConsoleColor.Red);
                return;
            }

            Console.WriteLine("Enter the Id of the Income you want to edit: ");
            string? id = Console.ReadLine();
            Console.WriteLine("Enter the income amount:");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter the category of income: ");
            foreach (var i in Enum.GetValues(typeof(IncomeCategory)))
            {
                Console.WriteLine($"{(int)i}. {i}");
            }

            Console.WriteLine("Enter the type of Income [1-6]:");
            IncomeCategory category = (IncomeCategory)Convert.ToInt32(Console.ReadLine());
            DateTime date = DateTime.Today;
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
            List<Expense> expense = this._services.ViewExpense();
            foreach (Expense value in expense)
            {
                Console.WriteLine($"Id : {value.Id}  Amount : {value.Amount}\tDate : {value.Date}\tCategory : {value.Category}");
            }
        }

        internal void ViewIncome()
        {
            List<Income> income = this._services.ViewIncome();
            foreach (Income value in income)
            {
                Console.WriteLine($"Id : {value.Id}  Amount : {value.Amount}\tDate : {value.Date}\tCategory : {value.Category}");
            }
        }
    }
}