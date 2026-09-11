using AdvancedExpenseTracker.Models;

namespace AdvancedExpenseTracker.Interfaces
{
    /// <summary>
    /// Defines the data modification and retrieval operations of Incomes.
    /// </summary>
    internal interface IIncomeRepository
    {
        /// <summary>
        /// Adds new Income to the repository.
        /// </summary>
        /// <param name="income">Income details of the user.</param>
        public void AddIncome(Income income);

        /// <summary>
        /// Retrieves all the Income from Repository.
        /// </summary>
        /// <returns>The list of incomes of user.</returns>
        public List<Income> GetAllIncome();

        /// <summary>
        /// Retrieves a particular Users income by matching ID.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the Income.</param>
        /// <returns>Returns a particular User's income if exists otherwise returns null.</returns>
        Income? GetIncomeById(Guid id);

        /// <summary>
        /// Updates a particular User's Income with the new data.
        /// </summary>
        /// <param name="income">Income details of the user.</param>
        /// <returns>Returns true if Income is updated otherwise returns false.</returns>
        public bool UpdateIncome(Income income);

        /// <summary>
        /// Deletes a particular User's Income data from the repository.
        /// </summary>
        /// <param name="id">Id the unique identifier of the income.</param>
        /// <returns>Returns true if Income is deleted otherwise returns false.</returns>
        public bool DeleteIncome(Guid id);
    }
}