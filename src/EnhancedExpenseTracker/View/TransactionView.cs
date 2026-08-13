using EnhancedExpenseTracker.Model;
using EnhancedExpenseTracker.Services;

namespace EnhancedExpenseTracker.View
{
    internal class TransactionView
    {
        private readonly TransactionServices services;

        public TransactionView(TransactionServices services)
        {
            this.services = services;
        }

        internal void IncomeOptions()
        {
            while (true)
            {
                Console.Write(@"
Income Options
 
1. Add Income
2. View Income
3. Edit Income
4. Delete Income
5. Return to Main Menu
Enter Choice: ");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AddTransaction(TransactionTypes.Income);
                            break;

                        case 2:
                            ViewTransaction(TransactionTypes.Income);
                            break;

                        case 3:
                            EditTransaction(TransactionTypes.Income);
                            break;

                        case 4:
                            DeleteTransaction(TransactionTypes.Income);
                            break;

                        case 5:
                            Console.Clear();
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

        internal void ExpenseOptions()
        {
            while (true)
            {
                Console.Write(@"
Expense Options
 
1. Add Expense
2. View Expense
3. Edit Expense
4. Delete Expense
5. Return to Main Menu
Enter Choice: ");

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            AddTransaction(TransactionTypes.Expense);
                            break;

                        case 2:
                            ViewTransaction(TransactionTypes.Expense);
                            break;

                        case 3:
                            EditTransaction(TransactionTypes.Expense);
                            break;

                        case 4:
                            DeleteTransaction(TransactionTypes.Expense);
                            break;

                        case 5:
                            Console.Clear();
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

        private void AddTransaction(TransactionTypes type)
        {
            decimal amount = ViewHelper.GetAmount();

            if (amount <= 0)
            {
                return;
            }
            string category = ViewHelper.GetCategory(type);

            if (string.IsNullOrEmpty(category))
            {
                return;
            }

            DateOnly date = ViewHelper.GetDate();

            this.services.AddTransaction(amount, date, category, type);

            ViewHelper.WriteColored( $"{type} Added Successfully.", ConsoleColor.Green);
        }

        private void ViewTransaction(TransactionTypes type)
        {
            if (this.services.IsTransactionEmpty())
            {
                ViewHelper.WriteColored("No Transaction Records.", ConsoleColor.Red);

                return;
            }

            List<TransactionModel> transactions = this.services.ViewTransaction().Where(transaction => transaction.TransactionType == type).ToList();

            if (transactions.Count == 0)
            {
                ViewHelper.WriteColored($"No {type} Records.", ConsoleColor.Red);
                return;
            }

            ViewHelper.PrintTransactionTable(transactions);
        }

        private void EditTransaction(TransactionTypes type)
        {
            if (this.services.IsTransactionEmpty())
            {
                ViewHelper.WriteColored("No Transaction Records.", ConsoleColor.Red);
                return;
            }

            string id = ViewHelper.GetTransactionId($"{type} ID", this.services, type);

            if (string.IsNullOrEmpty(id))
            {
                return;
            }

            decimal amount = ViewHelper.GetAmount();
            if (amount <= 0)
            {
                return;
            }

            string category = ViewHelper.GetCategory(type);
            if (string.IsNullOrEmpty(category))
            {
                return;
            }

            DateOnly date = ViewHelper.GetDate();

            if (this.services.EditTransaction(id, amount, date, category, type))
            {
                ViewHelper.WriteColored($"{type} Updated Successfully.",
                    ConsoleColor.Green);
            }
            else
            {
                ViewHelper.WriteColored(
                    $"{type} ID Not Found.",
                    ConsoleColor.Red);
            }
        }

        private void DeleteTransaction(TransactionTypes type)
        {
            if (this.services.IsTransactionEmpty())
            {
                ViewHelper.WriteColored(
                    "No Transaction Records.",
                    ConsoleColor.Red);

                return;
            }

            string id = ViewHelper.GetTransactionId(
                $"{type} ID",
                this.services,
                type);

            if (string.IsNullOrEmpty(id))
            {
                return;
            }

            if (this.services.DeleteTransaction(id))
            {
                ViewHelper.WriteColored(
                    $"{type} Deleted Successfully.",
                    ConsoleColor.Green);
            }
            else
            {
                ViewHelper.WriteColored(
                    $"{type} ID Not Found.",
                    ConsoleColor.Red);
            }
        }

        internal void ShowSummary()
        {
            decimal totalIncome =
                this.services.GetTotal(
                    TransactionTypes.Income);

            decimal totalExpense =
                this.services.GetTotal(
                    TransactionTypes.Expense);

            decimal balance =
                this.services.GetBalance();

            Console.WriteLine();
            Console.WriteLine($"Total Income  : {totalIncome}");
            Console.WriteLine($"Total Expense : {totalExpense}");
            Console.WriteLine($"Balance       : {balance}");
        }
    }
}