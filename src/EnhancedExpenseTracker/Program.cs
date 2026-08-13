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

            while (true)
            {
                string? mainMenuOptions = $@"Expense Tracker
 
1. Income Options
2. Expense Options
3. Show Summary
4. Exit
Enter Choice: ";
                Console.Write(mainMenuOptions);
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            view.IncomeOptions();
                            break;

                        case 2:
                            view.ExpenseOptions();
                            break;

                        case 3:
                            view.ShowSummary();
                            break;

                        case 4:
                            ViewHelper.WriteColored("Exiting...", ConsoleColor.Cyan);
                            Thread.Sleep(1000);
                            return;

                        default:
                            ViewHelper.WriteColored("Invalid Choice.", ConsoleColor.Red);
                            break;
                    }
                }
                catch (FormatException)
                {
                    ViewHelper.WriteColored("Enter a numeric value.", ConsoleColor.Red);
                }
            }
        }
    }
}