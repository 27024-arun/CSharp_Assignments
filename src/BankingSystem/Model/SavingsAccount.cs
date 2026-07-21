namespace BankingSystem.Model
{
    /// <summary>
    /// SavingsAccount class is the class used by the user for saving amount
    /// </summary>
    internal class SavingsAccount : BankModel
    {
        private readonly double _minimumBalance;

        /// <summary>
        /// Initializes a new instance of the <see cref="SavingsAccount"/> class.
        /// SavingsAccount method is the constructor for class
        /// </summary>
        /// <param name="accountNumber">AccountNumber is the unique account number of the user</param>
        /// <param name="initialBalance">InitialBalance is the amount that resides in the user account</param>
        /// <param name="minimumBalance">MinimumBalance is the amount that should be in SavingsAccount</param>
        public SavingsAccount(string accountNumber, double initialBalance, double minimumBalance)
            : base(accountNumber, initialBalance)
        {
            this._minimumBalance = minimumBalance;
        }

        /// <summary>
        /// Withdraw method is used to withdraw amount from the banking system
        /// </summary>
        /// <param name="amount">Amount is the amount needed to be withdrawn</param>
        /// <returns>Returns whether the amount is withdrawn or not</returns>
        public override bool Withdraw(double amount)
        {
            if (amount <= 0)
            {
                return false;
            }

            if (this.Balance - amount < this._minimumBalance)
            {
                return false;
            }

            this.Balance -= amount;
            return true;
        }
    }
}
