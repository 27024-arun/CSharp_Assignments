using Expense_Tracker.Models;

namespace Expense_Tracker.Interfaces
{
    internal interface IIncomeRepository
    {
        public void AddIncome(Income income);

        public List<Income> GetAllIncome();

        public bool UpdateIncome(Income income);

        public bool DeleteIncome(string id);
    }
}