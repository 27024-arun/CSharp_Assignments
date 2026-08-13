using EnhancedExpenseTracker.Model;
using EnhancedExpenseTracker.Repository;

namespace EnhancedExpenseTracker.Services
{
    internal class TransactionServices
    {
        private static int _incomeId = 100;
        private static int _expenseId = 200;

        private readonly TransactionRepository repository;

        public TransactionServices(TransactionRepository repository)
        {
            this.repository = repository;
        }

        internal void AddTransaction(decimal amount, DateOnly date, string category, TransactionTypes transactionType)
        {
            string id;
            if (transactionType == TransactionTypes.Income)
            {
                id = (_incomeId++).ToString();
            }
            else
            {
                id = (_expenseId++).ToString();
            }

            TransactionModel transaction = new()
            {
                Id = id,
                Amount = amount,
                Date = date,
                Category = category,
                TransactionType = transactionType,
            };

            this.repository.AddTransaction(transaction);
        }

        internal List<TransactionModel> ViewTransaction()
        {
            return this.repository.GetAllTransaction();
        }

        internal bool EditTransaction(string id, decimal amount, DateOnly date, string category, TransactionTypes transactionType)
        {
            TransactionModel transaction = new()
            {
                Id = id,
                Amount = amount,
                Date = date,
                Category = category,
                TransactionType = transactionType
            };

            return this.repository.UpdateTransaction(transaction);
        }

        internal bool DeleteTransaction(string id)
        {
            return this.repository.DeleteTransaction(id);
        }

        internal bool IsTransactionEmpty()
        {
            return this.repository.GetAllTransaction().Count == 0;
        }

        internal bool IsIdValid(string id)
        {
            return this.repository.GetTransactionById(id) != null;
        }

        internal TransactionModel? GetTransactionById(string id)
        {
            return this.repository.GetTransactionById(id);
        }

        internal decimal GetTotal(TransactionTypes transactionType)
        {
            return this.repository.GetAllTransaction().Where(transaction => transaction.TransactionType == transactionType).Sum(transaction => transaction.Amount);
        }

        internal decimal GetBalance()
        {
            return this.GetTotal(TransactionTypes.Income) - this.GetTotal(TransactionTypes.Expense);
        }
    }
}
