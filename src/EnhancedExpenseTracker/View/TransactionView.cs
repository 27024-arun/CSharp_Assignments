using EnhancedExpenseTracker.Services;

namespace EnhancedExpenseTracker.View
{
    internal class TransactionView
    {
        private TransactionServices services;

        public TransactionView(TransactionServices services)
        {
            this.services = services;
        }
    }
}
