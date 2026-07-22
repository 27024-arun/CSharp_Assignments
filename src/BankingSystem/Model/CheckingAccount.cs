namespace BankingSystem.Model
{
    /// <summary>
    /// CheckingAccount is the class where the data checking is made easier.
    /// </summary>
    internal class CheckingAccount : BankModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckingAccount"/> class.
        /// CheckingAccount method is the constructor for the class CheckingAccount
        /// </summary>
        /// <param name="accountNumber">AccountNumber is the unique account number of the user</param>
        /// <param name="initialBalance">InitialBalance is the amount that resides in the user account</param>
        public CheckingAccount(string accountNumber, double initialBalance)
            : base(accountNumber, initialBalance)
        {
        }

        /// <summary>
        /// Withdraw method is used to withdraw amount from the banking system.
        /// </summary>
        /// <param name="amount">Amount is the amount needed to be withdrawn</param>
        /// <returns>Returns whether the amount is withdrawn or not</returns>
        public override bool Withdraw(double amount)
        {
            if (amount <= 0)
            {
                return false;
            }

            if (amount > this.Balance)
            {
                return false;
            }

            this.Balance -= amount;
            return true;
        }
    }
}
