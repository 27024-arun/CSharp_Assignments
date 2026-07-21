namespace BankingSystem.Model
{
    /// <summary>
    /// BankModel is the abstract class with
    /// </summary>
    internal abstract class BankModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankModel"/> class.
        /// BankModel method is the constructor for the class BankModel
        /// </summary>
        /// <param name="accountNumber">AccountNumber is the unique account number of the user</param>
        /// <param name="initialBalance">InitialBalance is the amount that resides in the user account</param>
        protected BankModel(string accountNumber, double initialBalance)
        {
            this.AccountNumber = accountNumber;
            this.Balance = initialBalance;
        }

        /// <summary>
        /// Gets or sets the account number of the user
        /// </summary>
        /// <value>
        /// AccountNumber of the user
        /// </value>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or sets balance of the user in their account
        /// </summary>
        /// <value>
        /// Amount that resides in the user account
        /// </value>
        public double Balance { get; protected set; }

        /// <summary>
        /// Deposit method is used to deposit amount in the user account
        /// </summary>
        /// <param name="amount">Amount that needs to be deposited</param>
        /// <returns>Returns whether the amount is deposited or not</returns>
        public virtual bool Deposit(double amount)
        {
            if (amount <= 0)
            {
                return false;
            }

            this.Balance += amount;
            return true;
        }

        /// <summary>
        /// Withdraw method is used to withdraw amount from the banking system
        /// </summary>
        /// <param name="amount">Amount that needs to be withdrawn</param>
        /// <returns>Returns whether the amount is withdrawn or not</returns>
        public abstract bool Withdraw(double amount);
    }
}
