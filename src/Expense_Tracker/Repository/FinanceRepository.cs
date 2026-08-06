using Expense_Tracker.Interfaces;
using Expense_Tracker.Models;

namespace Expense_Tracker.Repository
{
    internal class FinanceRepository : IIncomeRepository, IExpenseRepository
    {
        private readonly List<Income> _incomes = new List<Income> { };
        private readonly List<Expense> _expenses = new List<Expense> { };

        public void AddExpense(Expense expense)
        {
            this._expenses.Add(expense);
        }

        public void AddIncome(Income income)
        {
            this._incomes.Add(income);
        }

        public bool DeleteExpense(string id)
        {
            var expense = this.GetExpenseById(id);

            if (expense == null)
            {
                return false;
            }

            this._expenses.Remove(expense);
            return true;
        }

        public bool DeleteIncome(string id)
        {
            var income = this.GetIncomeByID(id);
            if (income == null)
            {
                return false;
            }

            this._incomes.Remove(income);
            return true;
        }

        public List<Expense> GetAllExpense()
        {
            return this._expenses;
        }

        public List<Income> GetAllIncome()
        {
            return this._incomes;
        }

        public bool UpdateExpense(Expense expense)
        {
            var existing = this.GetExpenseById(expense.Id);

            if (existing != null)
            {
                existing.Amount = expense.Amount;
                existing.Date = expense.Date;
                existing.Category = expense.Category;
                return true;
            }

            return false;
        }

        public bool UpdateIncome(Income income)
        {
            var existing = this.GetIncomeByID(income.Id);

            if (existing != null)
            {
                existing.Amount = income.Amount;
                existing.Date = income.Date;
                existing.Category = income.Category;
                return true;
            }

            return false;
        }

        public Income? GetIncomeByID(string id)
        {
            return this._incomes.FirstOrDefault(income => income.Id == id);
        }

        public Expense? GetExpenseById(string id)
        {
            return this._expenses.FirstOrDefault(expense => expense.Id == id);
        }
    }
}
