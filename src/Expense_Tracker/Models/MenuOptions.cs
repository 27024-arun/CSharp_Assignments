namespace Expense_Tracker.Models
{
    internal enum MainMenuOptions
    {
        IncomeOptions = 1,
        ExpenseOptions = 2,
        ShowSummary = 3,
        Exit = 4,
        /*AddIncome = 1,
        ViewIncome,
        EditIncome,
        DeleteIncome,
        AddExpense,
        ViewExpense,
        EditExpense,
        DeleteExpense,
        ShowSummary,
        Exit,*/
    }

    internal enum IncomeMenu
    {
        AddIncome = 1,
        ViewIncome = 2,
        EditIncome = 3,
        DeleteIncome = 4,
        ReturnToMainMenu = 5,
    }

    internal enum ExpenseMenu
    {
        AddExpense = 1,
        ViewExpense = 2,
        EditExpense = 3,
        DeleteExpense = 4,
        ReturnToMainMenu = 5,
    }
}