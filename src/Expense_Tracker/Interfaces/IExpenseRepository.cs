using Expense_Tracker.Models;

namespace Expense_Tracker.Interfaces
{
    /// <summary>
    /// IExpenseRepository is the interface for the method of expense categories.
    /// </summary>
    internal interface IExpenseRepository
    {
        /// <summary>
        /// AddExpense method is the blueprint for adding expense in repository.
        /// </summary>
        /// <param name="expense">Expense details of the user.</param>
        public void AddExpense(Expense expense);

        /// <summary>
        /// GetAllExpense method is the blueprint for returning all the expense from repository.
        /// </summary>
        /// <returns>Returns the list of expenses of user.</returns>
        public List<Expense> GetAllExpense();

        /// <summary>
        /// GetExpenseById method is the blueprint for returning a particular expense by using their id.
        /// </summary>
        /// <param name="id">Id of the Expense.</param>
        /// <returns>Returns a particular</returns>
        Expense? GetExpenseById(string id);

        public bool UpdateExpense(Expense expense);

        public bool DeleteExpense(string id);
    }
}