using Expense_Tracker.Interfaces;
using Expense_Tracker.Models;

namespace Expense_Tracker.Repository
{
    internal class FinanceRepository : IIncomeRepository, IExpenseRepository
    {
        private readonly List<Income> _incomes = new ();
        private readonly List<Expense> _expenses = new ();

        public void AddIncome(Income income)
        {
            this._incomes.Add(income);
        }

        public void AddExpense(Expense expense)
        {
            this._expenses.Add(expense);
        }

        public List<Income> GetAllIncome()
        {
            return this._incomes;
        }

        public List<Expense> GetAllExpense()
        {
            return this._expenses;
        }

        public Income? GetIncomeById(string id)
        {
            return this._incomes.FirstOrDefault(i => i.Id == id);
        }

        public Expense? GetExpenseById(string id)
        {
            return this._expenses.FirstOrDefault(e => e.Id == id);
        }

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

        internal bool IsIncomeEmpty()
        {
            return this._incomes.Count == 0;
        }

        internal bool IsExpenseEmpty()
        {
            return this._expenses.Count == 0;
        }

        internal decimal GetTotalIncome()
        {
            return this._incomes.Sum(i => i.Amount);
        }

        internal decimal GetTotalExpense()
        {
            return this._expenses.Sum(e => e.Amount);
        }

        internal bool IsIncomeExists(string id)
        {
            if (this._expenses.Any(e => e.Id == id))
            {
                return true;
            }

            return this._expenses.Any(e => e.Id == id);
        }

        internal bool IsExpenseExists(string id)
        {
            if (this._expenses.Any(e => e.Id == id))
            {
                return true;
            }

            return false;
        }
    }
}