namespace Expense_Tracker.Models
{
    internal class Expense
    {
        public string Id { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public ExpenseCategory Category { get; set; }
    }
}