using Expense_Tracker.Models;
using Expense_Tracker.Repository;

namespace Expense_Tracker.Services
{
    /// <summary>
    /// FinanceServices class is used to handle business logic of the application.
    /// </summary>
    internal class FinanceServices
    {
        private static int incomeId = 100;
        private static int _expenseId = 200;

        private readonly FinanceRepository _repository = new ();

        /// <summary>
        /// AddIncome method is used to assign user given details to income model.
        /// </summary>
        /// <param name="amount">Amount of Income.</param>
        /// <param name="date">Date of Income.</param>
        /// <param name="category">Category of Income.</param>
        internal void AddIncome(decimal amount, DateOnly date, IncomeCategory category)
        {
            Income income = new ()
            {
                Id = (incomeId++).ToString(),
                Amount = amount,
                Date = date,
                Category = category,
            };

            this._repository.AddIncome(income);
        }

        /// <summary>
        /// AddExpense method is used to assign user given details to expense model.
        /// </summary>
        /// <param name="amount">Amount of expense.</param>
        /// <param name="date">Date of expense.</param>
        /// <param name="category">Category of expense.</param>
        internal void AddExpense(decimal amount, DateOnly date, ExpenseCategory category)
        {
            Expense expense = new ()
            {
                Id = (_expenseId++).ToString(),
                Amount = amount,
                Date = date,
                Category = category,
            };

            this._repository.AddExpense(expense);
        }

        /// <summary>
        /// ViewIncome method is used to return list of income to view level.
        /// </summary>
        /// <returns>Returns list of income.</returns>
        internal List<Income> ViewIncome()
        {
            return this._repository.GetAllIncome();
        }

        /// <summary>
        /// ViewExpense method is used to return list of expense to view level.
        /// </summary>
        /// <returns>Returns list of expense.</returns>
        internal List<Expense> ViewExpense()
        {
            return this._repository.GetAllExpense();
        }

        /// <summary>
        /// EditIncome method is used to validate income details and assign new income details to existing income.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the income.</param>
        /// <param name="amount">Amount is the amount of income.</param>
        /// <param name="date">Date is the date of income.</param>
        /// <param name="category">Category is the income category.</param>
        /// <returns>Returns whether the income is edited or not.</returns>
        internal bool EditIncome(string id, decimal amount, DateOnly date, IncomeCategory category)
        {
            List<Income> incomes = this.ViewIncome();
            if (incomes.Count == 0)
            {
                Console.WriteLine("No income records found.");
                return false;
            }

            Income newIncome = new ()
            {
                Id = id,
                Amount = amount,
                Date = date,
                Category = category,
            };
            this._repository.UpdateIncome(newIncome);
            return true;
        }

        /// <summary>
        /// EditExpense method is used to validate expense details and assign new expense details to existing expense.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the expense.</param>
        /// <param name="amount">Amount is the expense amount.</param>
        /// <param name="date">Date is the date of expense.</param>
        /// <param name="category">Category is the expense category.</param>
        /// <returns>Returns whether the expense is updated or not.</returns>
        internal bool EditExpense(string id, decimal amount, DateOnly date, ExpenseCategory category)
        {
            List<Expense> expenses = this.ViewExpense();
            if (expenses.Count == 0)
            {
                Console.WriteLine("No expense records found.");
                return false;
            }

            Expense expense = new ()
            {
                Id = id,
                Amount = amount,
                Date = date,
                Category = category,
            };

            return this._repository.UpdateExpense(expense);
        }

        /// <summary>
        /// DeleteIncome method is used to pass the id of the income to repository for deletion.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the income.</param>
        /// <returns>Returns whether the income is deleted or not.</returns>
        internal bool DeleteIncome(string id)
        {
            return this._repository.DeleteIncome(id);
        }

        /// <summary>
        /// DeleteExpense method is used to pass the id of the expense to repository for deletion.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the expense.</param>
        /// <returns>Returns whether the expense is deleted or not.</returns>
        internal bool DeleteExpense(string id)
        {
            return this._repository.DeleteExpense(id);
        }

        /// <summary>
        /// IsIncomeEmpty method is used to pass the detail whether the income is empty or not.
        /// </summary>
        /// <returns>Returns whether the income is empty or not.</returns>
        internal bool IsIncomeEmpty()
        {
            return this._repository.IsIncomeEmpty();
        }

        /// <summary>
        /// IsExpenseEmpty method is used to pass the detail whether the expense is empty or not.
        /// </summary>
        /// <returns>Returns whether the expense is empty or not.</returns>
        internal bool IsExpenseEmpty()
        {
            return this._repository.IsExpenseEmpty();
        }

        /// <summary>
        /// GetTotalIncome method is used to get the total of income.
        /// </summary>
        /// <returns>Returns the income total.</returns>
        internal decimal GetTotalIncome()
        {
            return this._repository.GetTotalIncome();
        }

        /// <summary>
        /// GetTotalExpense method is used to get the total of expense.
        /// </summary>
        /// <returns>Returns the expense total.</returns>
        internal decimal GetTotalExpense()
        {
            return this._repository.GetTotalExpense();
        }

        /// <summary>
        /// GetBalance method is used to return the remaining balance to the user.
        /// </summary>
        /// <returns>Returns the balance to user.</returns>
        internal decimal GetBalance()
        {
            return this.GetTotalIncome() - this.GetTotalExpense();
        }

        /// <summary>
        /// IsExpenseIdValid method is used to check whether expense id exists or not.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the expense.</param>
        /// <returns>Returns whether the expense exists or not.</returns>
        internal bool IsExpenseIdValid(string id)
        {
            return this._repository.IsExpenseExists(id);
        }

        /// <summary>
        /// IsIncomeIdValid method is used to check whether income id exists or not.
        /// </summary>
        /// <param name="id">Id is the unique identifier of the income.</param>
        /// <returns>Returns whether the income exists or not.</returns>
        internal bool IsIncomeIdValid(string id)
        {
            return this._repository.IsIncomeExists(id);
        }
    }
}
