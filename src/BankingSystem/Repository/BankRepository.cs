using System.Collections.Generic;
using System.Linq;
using BankingSystem.Model;

namespace BankingSystem.Repository
{
    /// <summary>
    /// BankRepository is the repository for the banking system
    /// </summary>
    internal class BankRepository
    {
        private readonly List<BankModel> _accounts = new List<BankModel>();

        /// <summary>
        /// AddAccount method is used to create account in banking system
        /// </summary>
        /// <param name="account">Account is the account details</param>
        public void AddAccount(BankModel account)
        {
            this._accounts.Add(account);
        }

        /// <summary>
        /// GetAccount method is used to return the account of the user
        /// </summary>
        /// <param name="accountNumber">AccountNumber is the unique account number of the user</param>
        /// <returns>Returns the account of the user</returns>
        public BankModel? GetAccount(string accountNumber)
        {
            return this._accounts.FirstOrDefault(a => a.AccountNumber == accountNumber);
        }

        /// <summary>
        /// AccountExists method tells whether the user whether the account is already in the repository or not
        /// </summary>
        /// <param name="accountNumber">AccountNumber is the unique account number of the user</param>
        /// <returns>Returns whether account already exists or not</returns>
        public bool AccountExists(string accountNumber)
        {
            return this._accounts.Any(a => a.AccountNumber == accountNumber);
        }
    }
}
