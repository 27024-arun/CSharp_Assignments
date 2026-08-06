using Expense_Tracker.Models;

namespace Expense_Tracker.Interfaces
{
    internal interface IExpenseRepository
    {
        public void AddExpense(Expense expense);

        public List<Expense> GetAllExpense();

        public bool UpdateExpense(Expense expense);

        public bool DeleteExpense(string id);
    }
}