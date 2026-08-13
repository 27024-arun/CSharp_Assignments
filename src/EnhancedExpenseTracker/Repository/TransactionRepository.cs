using EnhancedExpenseTracker.Interfaces;
using EnhancedExpenseTracker.Model;

namespace EnhancedExpenseTracker.Repository
{
    internal class TransactionRepository : IRepository
    {
        private readonly List<TransactionModel> _repository = new();

        public void AddTransaction(TransactionModel transaction)
        {
            this._repository.Add(transaction);
        }

        public List<TransactionModel> GetAllTransaction()
        {
            return this._repository;
        }

        public TransactionModel? GetTransactionById(string id)
        {
            return this._repository.FirstOrDefault(transaction => transaction.Id == id);
        }

        public bool UpdateTransaction(TransactionModel transaction)
        {
            TransactionModel? existing = this.GetTransactionById(transaction.Id);

            if (existing == null)
            {
                return false;
            }

            existing.Amount = transaction.Amount;
            existing.Date = transaction.Date;
            existing.Category = transaction.Category;
            existing.TransactionType = transaction.TransactionType;
            return true;
        }

        public bool DeleteTransaction(string id)
        {
            TransactionModel? transaction = this.GetTransactionById(id);
            if (transaction == null)
            {
                return false;
            }

            this._repository.Remove(transaction);
            return true;
        }
    }
}