using System.Runtime.CompilerServices;
using AdvancedExpenseTracker.Models;
using AdvancedExpenseTracker.Repository;

namespace AdvancedExpenseTracker.Services
{
    /// <summary>
    /// SummaryServices class is used to do the business logics of the summary.
    /// </summary>
    internal class SummaryServices
    {
        private readonly CSVIncomeRepository _incomeRepository;
        private readonly CSVExpenseRepository _expenseRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SummaryServices"/> class.
        /// </summary>
        /// <param name="incomeRepository">IncomeRepository is the income repository instance.</param>
        /// <param name="expenseRepository">ExpenseRepository is the expense repository instance.</param>
        public SummaryServices(CSVIncomeRepository incomeRepository, CSVExpenseRepository expenseRepository)
        {
            this._incomeRepository = incomeRepository;
            this._expenseRepository = expenseRepository;
        }

        /// <summary>
        /// CalculateBalance method is used to calculate total balance of user.
        /// </summary>
        /// <param name="incomeRepository">IncomeRepository is the income repository instance.</param>
        /// <param name="expenseRepository">ExpenseRepository is the expense repository instance.</param>
        /// <returns>Returns the balance.</returns>
        internal decimal CalculateBalance()
        {
            return this.GetTotalIncome() - this.GetTotalExpense();
        }

        /// <summary>
        /// GetTotalExpense is used to get the total expense from repository.
        /// </summary>
        /// <param name="expenseRepository">ExpenseRepository is the expense repository instance.</param>
        /// <returns>Returns the total expense.</returns>
        internal decimal GetTotalExpense()
        {
            return this._expenseRepository.GetTotalExpense();
        }

        /// <summary>
        /// GetTotalIncome is used to get the total income from repository.
        /// </summary>
        /// <param name="incomeRepository">IncomeRepository is the income repository instance.</param>
        /// <returns>Returns the expense total.</returns>
        internal decimal GetTotalIncome()
        {
            return this._incomeRepository.GetTotalIncome();
        }

        /// <summary>
        /// ExpenseSummary method is used to calculate the total amount used in a particular category of expense.
        /// </summary>
        /// <returns>Returns a dictionary with key-pair value as expense category and total amount spent in that particular category.</returns>
        internal Dictionary<ExpenseCategory, decimal> ExpenseSummary()
        {
            Dictionary<ExpenseCategory, decimal> expenseSummary = Enum.GetValues(typeof(ExpenseCategory)).Cast<ExpenseCategory>().ToDictionary(category => category, value => decimal.Zero);
            List<Expense> expenses = this._expenseRepository.GetAllExpense();
            foreach (Expense expense in expenses)
            {
                expenseSummary[expense.Category] += expense.Amount;
            }

            return expenseSummary;
        }

        /// <summary>
        /// IncomeSummary method is used to calculate the total amount used in a particular category of income.
        /// </summary>
        /// <returns>Returns a dictionary with key-pair value as income category and total amount spent in that particular category.</returns>
        internal Dictionary<IncomeCategory, decimal> IncomeSummary()
        {
            Dictionary<IncomeCategory, decimal> incomeSummary = Enum.GetValues(typeof(IncomeCategory)).Cast<IncomeCategory>().ToDictionary(category => category, value => decimal.Zero);
            List<Income> incomes = this._incomeRepository.GetAllIncome();
            foreach (Income income in incomes)
            {
                incomeSummary[income.Category] += income.Amount;
            }

            return incomeSummary;
        }
    }
}