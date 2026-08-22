using AdvancedExpenseTracker.Models;

namespace AdvancedExpenseTracker.Interfaces
{
    /// <summary>
    /// Defines the data modification and retrieval operations of Expenses.
    /// </summary>
    internal interface IExpenseRepository
    {
        /// <summary>
        /// Adds new expense to the repository.
        /// </summary>
        /// <param name="expense">Expense details of the user.</param>
        public void AddExpense(Expense expense);

        /// <summary>
        /// Retrieves all the expense in the repository.
        /// </summary>
        /// <returns>The list of expenses of user.</returns>
        public List<Expense> GetAllExpense();

        /// <summary>
        /// Retrieves a particular Expense by matching the ID.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the Expense.</param>
        /// <returns>Returns a particular User's expense if exists otherwise returns null.</returns>
        Expense? GetExpenseById(Guid id);

        /// <summary>
        /// Updates a particular Expense details of the user.
        /// </summary>
        /// <param name="expense">Expense details of the user.</param>
        /// <returns>Returns true if expense is updated otherwise returns false.</returns>
        public bool UpdateExpense(Expense expense);

        /// <summary>
        /// Deletes a particular Expense of the user.
        /// </summary>
        /// <param name="id">Id the unique identifier of the expense.</param>
        /// <returns>Returns true if expense is deleted otherwise returns false.</returns>
        public bool DeleteExpense(Guid id);
    }
}