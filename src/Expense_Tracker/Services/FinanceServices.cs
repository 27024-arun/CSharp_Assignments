using Expense_Tracker.Models;
using Expense_Tracker.Repository;

namespace Expense_Tracker.Services
{
    internal class FinanceServices
    {
        private static int incomeId = 100;
        private static int _expenseId = 200;

        private readonly FinanceRepository _repository = new ();

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

        internal List<Income> ViewIncome()
        {
            return this._repository.GetAllIncome();
        }

        internal List<Expense> ViewExpense()
        {
            return this._repository.GetAllExpense();
        }

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

        internal bool DeleteIncome(string id)
        {
            return this._repository.DeleteIncome(id);
        }

        internal bool DeleteExpense(string id)
        {
            return this._repository.DeleteExpense(id);
        }

        internal bool IncomeIsEmpty()
        {
            return this._repository.IsIncomeEmpty();
        }

        internal bool ExpenseIsEmpty()
        {
            return this._repository.IsExpenseEmpty();
        }

        internal decimal GetTotalIncome()
        {
            return this._repository.GetTotalIncome();
        }

        internal decimal GetTotalExpense()
        {
            return this._repository.GetTotalExpense();
        }

        internal decimal GetBalance()
        {
            return this.GetTotalIncome() - this.GetTotalExpense();
        }

        internal bool IsExpenseIdValid(string id)
        {
            return this._repository.IsExpenseExists(id);
        }

        internal bool IsIncomeIdValid(string id)
        {
            return this._repository.IsIncomeExists(id);
        }
    }
}
