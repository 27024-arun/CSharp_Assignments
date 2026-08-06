using Expense_Tracker.Models;
using Expense_Tracker.Services;

namespace Expense_Tracker.View
{
    internal class FinanceView
    {
        private readonly FinanceServices _services = new ();

        internal void AddExpense()
        {
            throw new NotImplementedException();
        }

        internal void AddIncome()
        {
            Console.WriteLine("Enter the income amount:");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Enter the category of income: ");
            foreach (var i in Enum.GetValues(typeof(IncomeCategory)))
            {
                Console.WriteLine(i);
            }

            IncomeCategory category = 0;
            DateTime date = DateTime.Today;
            this._services.AddIncome(amount, date, category);
        }

        internal void DeleteExpense()
        {
            throw new NotImplementedException();
        }

        internal void DeleteIncome()
        {
            throw new NotImplementedException();
        }

        internal void EditExpense()
        {
            throw new NotImplementedException();
        }

        internal void EditIncome()
        {
            throw new NotImplementedException();
        }

        internal void ShowSummary()
        {
            throw new NotImplementedException();
        }

        internal void ViewExpense()
        {
            throw new NotImplementedException();
        }

        internal void ViewIncome()
        {
            List<Income> income = this._services.ViewIncome();
            foreach (Income value in income)
            {
                Console.WriteLine(value.Id);
                Console.WriteLine(value.Amount);
                Console.WriteLine(value.Date);
                Console.WriteLine(value.Category);
            }
        }
    }
}
