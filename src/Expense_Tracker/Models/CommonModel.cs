namespace Expense_Tracker.Models
{
    internal abstract class CommonModel
    {
        public string Id { get; set; }

        public decimal Amount { get; set; }

        public DateOnly Date { get; set; }
    }
}
