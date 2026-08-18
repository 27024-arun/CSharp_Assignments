using AdvancedExpenseTracker.Models;
using AdvancedExpenseTracker.Services;

namespace AdvancedExpenseTracker.View
{
    /// <summary>
    /// SummaryView class is used to do the console level activities of summary.
    /// </summary>
    internal class SummaryView
    {
        private readonly SummaryServices _summaryServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="SummaryView"/> class.
        /// </summary>
        /// <param name="summaryServices">SummaryServices is the service instance of summary.</param>
        public SummaryView(SummaryServices summaryServices)
        {
            this._summaryServices = summaryServices;
        }

        /// <summary>
        /// SummaryOptions method is used to display the menu option provided for summary and gets the user choice from the menu.
        /// </summary>
        internal void SummaryOptions()
        {
            while (true)
            {
                Console.Clear();
                string summaryOptions = $@"
Summary Options
1. Show Expense Summary
2. Show Income Summary
3. Show Overall Summary
4. Return to Main Menu
Enter Choice: ";
                Console.Write("\n" + summaryOptions);
                int userData = Convert.ToInt32(Console.ReadLine());
                switch (userData)
                {
                    case 1:
                        this.ExpenseSummary();
                        break;
                    case 2:
                        this.IncomeSummary();
                        break;
                    case 3:
                        this.ShowSummary();
                        break;
                    case 4:
                        Console.Clear();
                        return;
                    default:
                        ViewHelper.WriteColored("Invalid option.", ConsoleColor.Red);
                        break;
                }
            }
        }

        /// <summary>
        /// IncomeSummary method is used to show the total amount used in the particular category of income.
        /// </summary>
        internal void IncomeSummary()
        {
            Console.Clear();
            ViewHelper.WriteColored("\nIncome Summary", ConsoleColor.Blue);
            Dictionary<IncomeCategory, decimal> incomeSummary = this._summaryServices.IncomeSummary();
            foreach (KeyValuePair<IncomeCategory, decimal> keyValuePair in incomeSummary)
            {
                Console.Write($"\n{keyValuePair.Key}: {keyValuePair.Value}");
            }

            Console.WriteLine("\nEnter any key to return in Summary Options.");
            Console.ReadKey();
        }

        /// <summary>
        /// ExpenseSummary method is used to show the total amount used in the particular category of expense.
        /// </summary>
        internal void ExpenseSummary()
        {
            Console.Clear();
            ViewHelper.WriteColored("\nExpense Summary", ConsoleColor.Blue);
            Dictionary<ExpenseCategory, decimal> expenseSummary = this._summaryServices.ExpenseSummary();
            foreach (KeyValuePair<ExpenseCategory, decimal> keyValuePair in expenseSummary)
            {
                Console.Write($"\n{keyValuePair.Key}: {keyValuePair.Value}");
            }

            Console.WriteLine("\nEnter any key to return in Summary Options.");
            Console.ReadKey();
        }

        /// <summary>
        /// ShowSummary method is used to display the summary details to the user.
        /// </summary>
        /// <param name="incomeRepository">IncomeRepository is the instance of incomeRepository.</param>
        /// <param name="expenseRepository">ExpenseRepository is the instance of expenseRepository.</param>
        internal void ShowSummary()
        {
            Console.Clear();
            ViewHelper.WriteColored("Overall Summary", ConsoleColor.Blue);
            decimal income = this._summaryServices.GetTotalIncome();
            decimal expense = this._summaryServices.GetTotalExpense();
            decimal balance = this._summaryServices.CalculateBalance();
            Console.WriteLine($"\nTotal Income  : {income}\nTotal Expense : {expense}\nBalance       : {balance}");
            Console.WriteLine("Enter any key to return in Summary Options.");
            Console.ReadKey();
        }
    }
}