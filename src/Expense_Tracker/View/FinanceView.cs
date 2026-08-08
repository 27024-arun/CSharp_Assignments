using Expense_Tracker.Models;
using Expense_Tracker.Services;

namespace Expense_Tracker.View
{
    /// <summary>
    /// FinanceView class is the class where view level methods are defined.
    /// </summary>
    public class FinanceView
    {
        private readonly FinanceServices _services = new ();

        /// <summary>
        /// AddExpense method is used to get expense details from the user.
        /// </summary>
        public void AddExpense()
        {
            decimal amount = ViewHelper.GetAmount();

            if (amount <= 0)
            {
                return;
            }

            Console.WriteLine("\nCategories of Expense: ");
            foreach (var i in Enum.GetValues(typeof(ExpenseCategory)))
            {
                Console.WriteLine($"{(int)i}. {i}");
            }

            int categoryData = ViewHelper.GetCategory("Enter the type of Expense [1-7]: ");
            if (categoryData < 1 || categoryData > 7)
            {
                return;
            }

            DateOnly date = ViewHelper.GetDate();
            this._services.AddExpense(amount, date, (ExpenseCategory)categoryData);
            ViewHelper.WriteColored("Expense Added Successfully.", ConsoleColor.Green);
        }

        /// <summary>
        /// AddIncome method is used to get income details from the user.
        /// </summary>
        internal void AddIncome()
        {
            decimal amount = ViewHelper.GetAmount();

            if (amount <= 0)
            {
                return;
            }

            Console.WriteLine("\nCategories of Income: ");
            foreach (var i in Enum.GetValues(typeof(IncomeCategory)))
            {
                Console.WriteLine($"{(int)i}. {i}");
            }

            int categoryData = ViewHelper.GetCategory("Enter the type of Income [1-7]: ");
            if (categoryData < 1 || categoryData > 7)
            {
                return;
            }

            DateOnly date = ViewHelper.GetDate();
            this._services.AddIncome(amount, date, (IncomeCategory)categoryData);
            ViewHelper.WriteColored("Income Added Successfully.", ConsoleColor.Green);
        }

        /// <summary>
        /// DeleteExpense is used to get expense detail of the method that should be deleted.
        /// </summary>
        internal void DeleteExpense()
        {
            if (this._services.IsExpenseEmpty())
            {
                ViewHelper.WriteColored("No Expense Records.", ConsoleColor.Red);
                return;
            }

            string id = ViewHelper.GetExpenseID("Expense Id", this._services);
            if (string.IsNullOrEmpty(id))
            {
                return;
            }

            if (this._services.DeleteExpense(id))
            {
                ViewHelper.WriteColored("Expense Deleted Successfully.", ConsoleColor.Green);
            }
            else
            {
                ViewHelper.WriteColored("Expense ID Not Found.", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// DeleteExpense is used to get income detail of the method that should be deleted.
        /// </summary>
        internal void DeleteIncome()
        {
            if (this._services.IsIncomeEmpty())
            {
                ViewHelper.WriteColored("No Income Records.", ConsoleColor.Red);
                return;
            }

            string id = ViewHelper.GetIncomeID("Income Id", this._services);

            if (string.IsNullOrEmpty(id))
            {
                return;
            }

            if (this._services.DeleteIncome(id))
            {
                ViewHelper.WriteColored("Income Deleted Successfully.", ConsoleColor.Green);
            }
            else
            {
                ViewHelper.WriteColored("Income ID Not Found.", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// EditExpense method is used to get the details of expense that should be edited.
        /// </summary>
        internal void EditExpense()
        {
            if (this._services.IsExpenseEmpty())
            {
                ViewHelper.WriteColored("No Expense Records.", ConsoleColor.Red);
                return;
            }

            string? id = ViewHelper.GetExpenseID("Expense Id", this._services);
            if (string.IsNullOrEmpty(id))
            {
                return;
            }

            decimal amount = ViewHelper.GetAmount();

            Console.WriteLine("\nCategories of Expense: ");
            foreach (var i in Enum.GetValues(typeof(ExpenseCategory)))
            {
                Console.WriteLine($"{(int)i}. {i}");
            }

            int categoryData = ViewHelper.GetCategory("Enter the type of expense [1-7]:");
            if (categoryData < 1 || categoryData > 7)
            {
                return;
            }

            DateOnly date = ViewHelper.GetDate();
            this._services.EditExpense(id, amount, date, (ExpenseCategory)categoryData);
        }

        /// <summary>
        /// EditIncome method is used to get details of the income that should be edited.
        /// </summary>
        internal void EditIncome()
        {
            if (this._services.IsIncomeEmpty())
            {
                ViewHelper.WriteColored("No Income Records.", ConsoleColor.Red);
                return;
            }

            string? id = ViewHelper.GetIncomeID("Income Id", this._services);
            if (string.IsNullOrEmpty(id))
            {
                return;
            }

            decimal amount = ViewHelper.GetAmount();

            Console.WriteLine("\nCategories of Income: ");
            foreach (var i in Enum.GetValues(typeof(IncomeCategory)))
            {
                Console.WriteLine($"{(int)i}. {i}");
            }

            int categoryData = ViewHelper.GetCategory("Enter the type of Income[1 - 7]:");
            if (categoryData < 1 || categoryData > 7)
            {
                return;
            }

            DateOnly date = ViewHelper.GetDate();
            this._services.EditIncome(id, amount, date, (IncomeCategory)categoryData);
        }

        /// <summary>
        /// ShowSummary method is used to display overall summary of the income and expenses.
        /// </summary>
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

        /// <summary>
        /// ViewExpense method is used to display details of the expense.
        /// </summary>
        internal void ViewExpense()
        {
            if (this._services.IsExpenseEmpty())
            {
                ViewHelper.WriteColored("No Expense Records.", ConsoleColor.Red);
                return;
            }

            List<Expense> expense = this._services.ViewExpense();
            ViewHelper.PrintExpenseTabledFormat(expense);
        }

        /// <summary>
        /// ViewIncome method is used to display details of the income.
        /// </summary>
        internal void ViewIncome()
        {
            if (this._services.IsIncomeEmpty())
            {
                ViewHelper.WriteColored("No Income Records.", ConsoleColor.Red);
                return;
            }

            List<Income> income = this._services.ViewIncome();
            ViewHelper.PrintIncomeTabledFormat(income);
        }
    }
}