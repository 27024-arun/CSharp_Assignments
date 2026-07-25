using BankingSystem.Repository;
using BankingSystem.Services;

namespace BankingSystem
{
    /// <summary>
    /// Program is the entry level class of the program (It is the view level).
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main function is the entry level function of the program.
        /// </summary>
        public static void Main()
        {
            BankServices service = new BankServices(new BankRepository());

            while (true)
            {
                string verbatimString = @"
Banking System
1. Create Account
2. Deposit
3. Withdraw
4. View Account
5. Exit
Enter your choice: ";
                Console.WriteLine(verbatimString);
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateAccount(service);
                        break;

                    case "2":
                        DepositAmount(service);
                        break;

                    case "3":
                        WithdrawAmount(service);
                        break;

                    case "4":
                        ViewAccount(service);
                        break;

                    case "5":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option.");
                        break;
                }
            }
        }

        private static void ViewAccount(BankServices service)
        {
            Console.Write("Enter Account Number: ");
            string? viewAccount = Console.ReadLine();
            if (viewAccount == null)
            {
                return;
            }

            var account = service.GetAccountDetails(viewAccount);
            if (account == null)
            {
              Console.WriteLine("Account not found.");
            }
            else
            {
              Console.WriteLine($"\nAccount Details\nAccount Number: {account.AccountNumber}\nBalance: {account.Balance}\nAccount Type: {account.GetType().Name}");
            }
        }

        private static void WithdrawAmount(BankServices service)
        {
            Console.Write("Enter Account Number: ");
            string? withdrawAccount = Console.ReadLine();
            if (withdrawAccount == null)
            {
                return;
            }

            Console.Write("Enter Withdrawal Amount: ");
            if (!double.TryParse(Console.ReadLine(), out double withdrawAmount) || withdrawAmount <= 0)
            {
                Console.WriteLine("Invalid amount.");
                return;
            }

            Console.WriteLine(service.Withdraw(withdrawAccount, withdrawAmount)
                ? "Withdrawal successful."
                : "Withdrawal failed (check balance or account).");
        }

        private static void DepositAmount(BankServices service)
        {
            Console.Write("Enter Account Number: ");
            string? depositAccount = Console.ReadLine();
            if (depositAccount == null)
            {
                return;
            }

            Console.Write("Enter Deposit Amount: ");
            if (!double.TryParse(Console.ReadLine(), out double depositAmount) || depositAmount <= 0)
            {
                Console.WriteLine("Invalid amount.");
                return;
            }

            Console.WriteLine(service.Deposit(depositAccount, depositAmount)
                ? "Deposit successful."
                : "Deposit failed (account not found).");
        }

        private static void CreateAccount(BankServices service)
        {
            Console.WriteLine("Enter the type of account you want to create: \n(Minimum Balance for Savings Account is 1000, Checking Account does not need minimum balance)\nSaving Account -> S, CheckingAccount - > C :");
            string? accountType = Console.ReadLine();

            bool isAccountValidated = BankServices.AccountValidation(accountType!);
            if (!isAccountValidated)
            {
                Console.WriteLine("Enter a Valid account type (S for Savings Account, C for Checking Account)");
                return;
            }

            string accountNumber = BankServices.GenerateAccountNumber();

            Console.WriteLine("Your account number is: " + accountNumber);
            Console.Write("Enter Initial Balance: ");
            if (!double.TryParse(Console.ReadLine(), out double initialBalance) || initialBalance < 0)
            {
                Console.WriteLine("Invalid balance.");
                return;
            }

            bool created = service.CreateAccount(accountNumber, initialBalance, accountType!.ToLower());
            Console.WriteLine(created ? "Account created successfully." : "Failed to create account (duplicate or invalid data).");
        }
    }
}
