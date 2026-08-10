using Expense_Tracker.Interfaces;
using Expense_Tracker.Models;

namespace Expense_Tracker.Repository
{
    /// <summary>
    /// FinanceRepository is the persistance level where the data are stored.
    /// </summary>
    internal class FinanceRepository : IIncomeRepository, IExpenseRepository
    {
        private readonly List<Income> _incomes = new ();
        private readonly List<Expense> _expenses = new ();

        /// <summary>
        /// AddIncome method is used to add income to the repository.
        /// </summary>
        /// <param name="income">Income is the details of income.</param>
        public void AddIncome(Income income)
        {
            this._incomes.Add(income);
        }

        /// <summary>
        /// AddExpense method is used to add expense to the repository.
        /// </summary>
        /// <param name="expense">Expense is the details of expense.</param>
        public void AddExpense(Expense expense)
        {
            this._expenses.Add(expense);
        }

        /// <summary>
        /// GetAllIncome method is used to retrieve list of incomes from repository.
        /// </summary>
        /// <returns>Returns the list of income in repository.</returns>
        public List<Income> GetAllIncome()
        {
            return this._incomes;
        }

        /// <summary>
        /// GetAllExpense method is used to retrieve list of expense from repository.
        /// </summary>
        /// <returns>Returns the list of expense in repository.</returns>
        public List<Expense> GetAllExpense()
        {
            return this._expenses;
        }

        /// <summary>
        /// GetIncomeById method is used to retrieve a particular income from repository.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the income.</param>
        /// <returns>Returns the income from repository.</returns>
        public Income? GetIncomeById(string id)
        {
            return this._incomes.FirstOrDefault(i => i.Id == id);
        }

        /// <summary>
        /// GetExpenseById method is used to retrieve a particular expense from repository.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the expense.</param>
        /// <returns>Returns the expense from repository.</returns>
        public Expense? GetExpenseById(string id)
        {
            return this._expenses.FirstOrDefault(e => e.Id == id);
        }

        /// <summary>
        /// UpdateIncome method is used update income details in the repository.
        /// </summary>
        /// <param name="income">Income is the income details.</param>
        /// <returns>Returns whether the income is updated or not.</returns>
        public bool UpdateIncome(Income income)
        {
            Income? existing = this.GetIncomeById(income.Id);

            if (existing == null)
            {
                return false;
            }

            existing.Amount = income.Amount;
            existing.Date = income.Date;
            existing.Category = income.Category;

            return true;
        }

        /// <summary>
        /// UpdateExpense method is used to update the expense details in the repository.
        /// </summary>
        /// <param name="expense">Expense is the expense details.</param>
        /// <returns>Returns whether the expense is updated or not.</returns>
        public bool UpdateExpense(Expense expense)
        {
            Expense? existing = this.GetExpenseById(expense.Id);

            if (existing == null)
            {
                return false;
            }

            existing.Amount = expense.Amount;
            existing.Date = expense.Date;
            existing.Category = expense.Category;

            return true;
        }

        /// <summary>
        /// DeleteIncome method is used to delete a particular income in the repository.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the income.</param>
        /// <returns>Returns whether the income is deleted or not.</returns>
        public bool DeleteIncome(string id)
        {
            Income? income = this.GetIncomeById(id);

            if (income == null)
            {
                return false;
            }

            this._incomes.Remove(income);
            return true;
        }

        /// <summary>
        /// DeleteExpense method is used to delete a particular expense in the repository.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the expense.</param>
        /// <returns>Returns whether the expense is deleted or not.</returns>
        public bool DeleteExpense(string id)
        {
            Expense? expense = this.GetExpenseById(id);

            if (expense == null)
            {
                return false;
            }

            this._expenses.Remove(expense);
            return true;
        }

        /// <summary>
        /// IsIncomeEmpty method is used to check whether the income is empty.
        /// </summary>
        /// <returns>Returns whether the income is empty or not.</returns>
        internal bool IsIncomeEmpty()
        {
            return this._incomes.Count == 0;
        }

        /// <summary>
        /// IsExpenseEmpty method is used to check whether the expense is empty.
        /// </summary>
        /// <returns>Returns whether the income is empty or not.</returns>
        internal bool IsExpenseEmpty()
        {
            return this._expenses.Count == 0;
        }

        /// <summary>
        /// GetTotalIncome method is used get the income total.
        /// </summary>
        /// <returns>Returns the income total.</returns>
        internal decimal GetTotalIncome()
        {
            return this._incomes.Sum(i => i.Amount);
        }

        /// <summary>
        /// GetTotalExpense method is used get the expense total.
        /// </summary>
        /// <returns>Returns the expense total.</returns>
        internal decimal GetTotalExpense()
        {
            return this._expenses.Sum(e => e.Amount);
        }

        /// <summary>
        /// IsIncomeExists method is used to check whether the income already exists in repository or not.
        /// </summary>
        /// <param name="id">Id is the unqiue identifier of the income.</param>
        /// <returns>Returns whether the income exists or not.</returns>
        internal bool IsIncomeExists(string id)
        {
            return this._incomes.Any(e => e.Id == id);
        }

        /// <summary>
        /// IsExpenseExists method is used to check whether the expense already exists in repository or not.
        /// </summary>
        /// <param name="id">Id is the unqiue identifier of the expense.</param>
        /// <returns>Returns whether the expense exists or not.</returns>
        internal bool IsExpenseExists(string id)
        {
            return this._expenses.Any(e => e.Id == id);
        }
    }
}