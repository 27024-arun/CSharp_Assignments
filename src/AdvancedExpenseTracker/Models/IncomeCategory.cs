namespace AdvancedExpenseTracker.Models
{
    /// <summary>
    /// IncomeCategory is the enum which consists of income categories.
    /// </summary>
    internal enum IncomeCategory
    {
        /// <summary>
        /// Income earned from regular paychecks.
        /// </summary>
        Salary = 1,

        /// <summary>
        /// Incomes earned from doing projects and prototypes.
        /// </summary>
        Freelancing = 2,

        /// <summary>
        /// Extra Income earned from any income activites.
        /// </summary>
        Bonus = 3,

        /// <summary>
        /// Income earned from interest collection from individuals.
        /// </summary>
        Interest = 4,

        /// <summary>
        /// Income earned from rental amount collection from individuals.
        /// </summary>
        Rental = 5,

        /// <summary>
        /// Income earned from doing work as a part-time employee.
        /// </summary>
        Stipend = 6,

        /// <summary>
        /// Other income which is not predefined.
        /// </summary>
        Others = 7,
    }
}