using EnhancedExpenseTracker.Model;

namespace EnhancedExpenseTracker.Interfaces
{
    internal interface IRepository
    {
        public void AddTransaction(TransactionModel transaction);

        public List<TransactionModel> GetAllTransaction();

        TransactionModel? GetTransactionById(string id);

        public bool UpdateTransaction(TransactionModel transaction);

        public bool DeleteTransaction(string id);
    }
}
