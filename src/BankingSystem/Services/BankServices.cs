using BankingSystem.Model;
using BankingSystem.Repository;

namespace BankingSystem.Services
{
    /// <summary>
    /// BankServices is the service level for the Banking System
    /// </summary>
    internal class BankServices
    {
        private readonly BankRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BankServices"/> class.
        /// BankServices method is the constructor of BankServices class
        /// </summary>
        /// <param name="repository">Repository is the repository of the banking system</param>
        public BankServices(BankRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// CreateAccount method is used to create account in the banking system
        /// </summary>
        /// <param name="accountNumber">AccountNumber is the unique number for the user</param>
        /// <param name="initialBalance">InitialBalance is the initial amount deposited in the account</param>
        /// <returns>Returns whether the account is created or not</returns>
        public bool CreateAccount(string accountNumber, double initialBalance)
        {
            if (string.IsNullOrWhiteSpace(accountNumber) || initialBalance < 0)
            {
                return false;
            }

            if (this._repository.AccountExists(accountNumber))
            {
                return false;
            }

            BankModel account;

            if (initialBalance >= 5000)
            {
                account = new SavingsAccount(accountNumber, initialBalance, 1000);
            }
            else
            {
                account = new CheckingAccount(accountNumber, initialBalance);
            }

            this._repository.AddAccount(account);
            return true;
        }

        /// <summary>
        /// Deposit method is used to deposit the amount
        /// </summary>
        /// <param name="accountNumber">AccountNumber is the unique number for the user</param>
        /// <param name="amount">Amount is the amount needed to be deposited in the banking system</param>
        /// <returns>Returns the amount is deposited or not</returns>
        public bool Deposit(string accountNumber, double amount)
        {
            var account = this._repository.GetAccount(accountNumber);
            if (account == null)
            {
                return false;
            }

            return account.Deposit(amount);
        }

        /// <summary>
        /// Withdraw method is used to withdraw amount from the banking system
        /// </summary>
        /// <param name="accountNumber">AccountNumber is the unique number for the user</param>
        /// <param name="amount">Amount is the amount needed to be withdrawn from the banking system</param>
        /// <returns>Returns whether the amount is withdrawn or not</returns>
        public bool Withdraw(string accountNumber, double amount)
        {
            var account = this._repository.GetAccount(accountNumber);
            if (account == null)
            {
                return false;
            }

            return account.Withdraw(amount);
        }

        /// <summary>
        /// GetAccountDetails method is used to view the account details
        /// </summary>
        /// <param name="accountNumber">AccountNumber is the unique number for the user</param>
        /// <returns>Returns the bank account details</returns>
        public BankModel? GetAccountDetails(string accountNumber)
        {
            return this._repository.GetAccount(accountNumber);
        }
    }
}
