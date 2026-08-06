using Expense_Tracker.Models;
using Expense_Tracker.View;

namespace Assignments
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            FinanceView view = new FinanceView();
            try
            {
                while (true)
                {
                    string inventoryMenu = $@"
Expense Tracker
1. Add Income
2. View Income
3. Edit Income
4. Delete Income
5. Add Expense
6. View Expenses
7. Edit Expenses
8. Delete Expenses
9. Show Summary
10. Exit
Enter Choice: ";
                    Console.WriteLine(inventoryMenu);
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case (int)MenuOptions.AddIncome:
                            view.AddIncome();
                            break;
                        case (int)MenuOptions.ViewIncome:
                            view.ViewIncome();
                            break;
                        case (int)MenuOptions.EditIncome:
                            view.EditIncome();
                            break;
                        case (int)MenuOptions.DeleteIncome:
                            view.DeleteIncome();
                            break;
                        case (int)MenuOptions.AddExpense:
                            view.AddExpense();
                            break;
                        case (int)MenuOptions.ViewExpense:
                            view.ViewExpense();
                            break;
                        case (int)MenuOptions.EditExpense:
                            view.EditExpense();
                            break;
                        case (int)MenuOptions.DeleteExpense:
                            view.DeleteExpense();
                            break;
                        case (int)MenuOptions.ShowSummary:
                            view.ShowSummary();
                            break;
                        case (int)MenuOptions.Exit:
                            return;
                        default:
                            ViewHelper.WriteColored("Invalid Choice", ConsoleColor.Red);
                            break;
                    }
                }
            }
            catch (FormatException)
            {
                ViewHelper.WriteColored("Enter a numeric value in the menu", ConsoleColor.Red);
            }
            catch (Exception ex)
            {
                ViewHelper.WriteColored(ex.Message, ConsoleColor.Red);
            }
        }
    }
}