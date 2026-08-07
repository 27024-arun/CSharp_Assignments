namespace Expense_Tracker.Models
{
    internal class Expense : CommonModel
    {
        public ExpenseCategory Category { get; set; }
    }
}