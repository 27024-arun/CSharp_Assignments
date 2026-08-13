namespace EnhancedExpenseTracker.Model
{
    /// <summary>
    /// TransactionModel is the abstract class whether the properties and field of transaction is declared.
    /// </summary>
    internal class TransactionModel
    {
        public TransactionModel ()
        {
        }

        public TransactionModel(string Id, decimal Amount, DateOnly Date, string Category, TransactionTypes TransactionTypes)
        {
            this.Id = Id;
            this.Amount = Amount;
            this.Date = Date;
            this.Category = Category;
            this.TransactionType = TransactionTypes;
        }
        /// <summary>
        /// Gets or Sets the Id of the transaction.
        /// </summary>
        /// <value>Id is the unique identifier for the transaction.</value>
        public string Id{ get; set; }

        /// <summary>
        /// Gets or Sets the amount of the transaction.
        /// </summary>
        /// <value>Amount is the transaction amount.</value>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or Sets the Date of the transaction.
        /// </summary>
        /// <value>Date is the date of transaction..</value>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Gets or Sets the category of the transaction.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or Sets the transaction type of the transaction.
        /// </summary>
        public TransactionTypes TransactionType { get; set; }
    }
}
