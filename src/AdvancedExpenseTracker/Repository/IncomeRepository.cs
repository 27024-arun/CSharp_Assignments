using AdvancedExpenseTracker.Interfaces;
using AdvancedExpenseTracker.Models;

namespace AdvancedExpenseTracker.Repository
{
    /// <summary>
    /// IncomeRepository class is the class where storage of income data is defined.
    /// </summary>
    internal class IncomeRepository : IIncomeRepository
    {
        private readonly List<Income> _incomes = new ();

        /// <inheritdoc/>
        public void AddIncome(Income income)
        {
            this._incomes.Add(income);
        }

        /// <inheritdoc/>
        public List<Income> GetAllIncome()
        {
            return this._incomes;
        }

        /// <inheritdoc/>
        public Income? GetIncomeById(Guid id)
        {
            return this._incomes.FirstOrDefault(i => i.Id == id);
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public bool DeleteIncome(Guid id)
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
        /// IsIncomeEmpty method is used to check whether the income is empty.
        /// </summary>
        /// <returns>Returns whether the income is empty or not.</returns>
        internal bool IsIncomeEmpty()
        {
            return this._incomes.Count == 0;
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
        /// IsIncomeExists method is used to check whether the income already exists in repository or not.
        /// </summary>
        /// <param name="id">Id is the unqiue identifier of the income.</param>
        /// <returns>Returns whether the income exists or not.</returns>
        internal bool IsIncomeExists(Guid id)
        {
            return this._incomes.Any(e => e.Id == id);
        }

        /// <summary>
        /// IncomeCount method is used to return the number of income in the repository.
        /// </summary>
        /// <returns>Returns the number of incomes.</returns>
        internal int IncomeCount()
        {
            return this._incomes.Count;
        }
    }
}