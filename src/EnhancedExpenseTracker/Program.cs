using EnhancedExpenseTracker.Repository;
using EnhancedExpenseTracker.Services;
using EnhancedExpenseTracker.View;

namespace EnhancedExpenseTracker
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            TransactionRepository repository = new TransactionRepository();
            TransactionServices services = new TransactionServices(repository);
            TransactionView view = new TransactionView(services);
        }
    }
}
