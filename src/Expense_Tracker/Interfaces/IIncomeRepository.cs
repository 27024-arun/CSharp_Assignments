using Expense_Tracker.Models;

namespace Expense_Tracker.Interfaces
{
    internal interface IIncomeRepository
    {
        public void AddIncome(Income income);

        public List<Income> GetAllIncome();

        Income? GetIncomeById(string id);

        public bool UpdateIncome(Income income);

        public bool DeleteIncome(string id);
    }
}