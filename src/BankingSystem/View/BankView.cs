using BankingSystem.Services;

namespace BankingSystem.View
{
    /// <summary>
    /// BankView method consists of the View level methods of the Program.
    /// </summary>
    internal class BankView
    {
        /// <summary>
        /// ViewAccount method is used to view the datas in the account.
        /// </summary>
        /// <param name="service">Service is the service provided by the bank.</param>
        internal static void ViewAccount(BankServices service)
        {
            Console.Write("Enter Account Number: ");
            string? viewAccount = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(viewAccount))
            {
                Console.WriteLine("Account number is not valid.");
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

        /// <summary>
        /// WithdrawAmount method is used to withdraw amount from the account.
        /// </summary>
        /// <param name="service">Service is the service provided by the bank.</param>
        internal static void WithdrawAmount(BankServices service)
        {
            Console.Write("Enter Account Number: ");
            string? withdrawAccount = Console.ReadLine();
            if (string.IsNullOrEmpty(withdrawAccount))
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

        /// <summary>
        /// DepositAmount method is used to add amount in the user account.
        /// </summary>
        /// <param name="service">Service is the service provided by the bank.</param>
        internal static void DepositAmount(BankServices service)
        {
            Console.Write("Enter Account Number: ");
            string? depositAccount = Console.ReadLine();
            if (string.IsNullOrEmpty(depositAccount))
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

        /// <summary>
        /// CreateAccount method is used to create account in the bank.
        /// </summary>
        /// <param name="service">Service is the service provided by the bank.</param>
        internal static void CreateAccount(BankServices service)
        {
            Console.WriteLine("Enter the type of account you want to create: \n(Minimum Balance for Savings Account is 1000, Checking Account does not need minimum balance)\nSaving Account -> S, CheckingAccount - > C :");
            string? accountType = Console.ReadLine();
            if (string.IsNullOrEmpty(accountType))
            {
                Console.WriteLine("Account Type is cannot is empty.");
                return;
            }

            bool isAccountValidated = service.AccountValidation(accountType.ToLower());
            if (!isAccountValidated)
            {
                Console.WriteLine("Enter a Valid account type (S for Savings Account, C for Checking Account)");
                return;
            }

            string accountNumber = service.GenerateAccountNumber();

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
