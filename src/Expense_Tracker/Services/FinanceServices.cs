using Expense_Tracker.Models;
using Expense_Tracker.Repository;

namespace Expense_Tracker.Services
{
    internal class FinanceServices
    {
        private static int value = 100;
        private readonly FinanceRepository _repository = new ();

        public FinanceServices()
        {
        }

        internal void AddIncome(decimal amount, DateTime date, IncomeCategory category)
        {
            Income income = new Income();
            income.Id = $"{value++}";
            income.Amount = amount;
            income.Date = date;
            income.Category = category;
            this._repository.AddIncome(income);
        }

        internal List<Income> ViewIncome()
        {
            return this._repository.GetAllIncome();
        }
    }
}
