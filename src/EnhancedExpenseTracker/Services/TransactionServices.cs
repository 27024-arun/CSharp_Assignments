using EnhancedExpenseTracker.Model;
using EnhancedExpenseTracker.Repository;

namespace EnhancedExpenseTracker.Services
{
    internal class TransactionServices
    {
        private TransactionRepository repository;

        public TransactionServices(TransactionRepository repository)
        {
            this.repository = repository;
        }

        private static int _incomeId = 100;
        private static int _expenseId = 200;

        internal void AddTransaction(decimal amount, DateOnly date)
        {
            TransactionModel transaction = new ()
            {
                Id = ,
                Amount = amount,
                Date = date,
                Category = category,
            };

            this.repository.AddTransaction(transaction);
        }

        internal List<TransactionModel> ViewTransaction()
        {

        }

        internal bool EditTransaction(string id, decimal amount, DateOnly date, ExpenseCategory category)
        {
            
        }

        internal bool DeleteTransaction(string id)
        {
           
        }

        internal bool IsExpenseEmpty()
        {
            
        }

        internal bool IsIncomeEmpty()
        {

        }

        internal decimal GetTotalExpense()
        {
            
        }

        internal bool IsIdValid(string id)
        {
            
        }
    }
}
