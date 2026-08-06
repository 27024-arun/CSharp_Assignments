namespace Expense_Tracker.Models
{
    internal class Income
    {
        public string Id { get; set; }

        public decimal Amount { get; set; }

        public DateTime? Date { get; set; }

        public IncomeCategory Category { get; set; }
    }
}