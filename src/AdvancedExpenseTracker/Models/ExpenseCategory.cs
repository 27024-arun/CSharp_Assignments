namespace AdvancedExpenseTracker.Models
{
    /// <summary>
    /// ExpenseCategory is the enum which consists of expense categories.
    /// </summary>
    internal enum ExpenseCategory
    {
        /// <summary>
        /// Expenses related to Food, Juices, Snacks.
        /// </summary>
        Food = 1,

        /// <summary>
        /// Expenses related to using different modes of transport.
        /// </summary>
        Transport = 2,

        /// <summary>
        /// Expenses related to Purchasing items from stores and malls.
        /// </summary>
        Shopping = 3,

        /// <summary>
        /// Expenses related to Filing taxes and paying bills like Electricity, Gas and others.
        /// </summary>
        Bills = 4,

        /// <summary>
        /// Expense related to movies, games, concerts.
        /// </summary>
        Entertainment = 5,

        /// <summary>
        /// Expense realted to medical checkups and doctor consultancy.
        /// </summary>
        Healthcare = 6,

        /// <summary>
        /// Expenses related to activities that are not predefined.
        /// </summary>
        Others = 7,
    }
}