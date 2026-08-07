using Expense_Tracker.Models;
using Expense_Tracker.View;

namespace Assignments
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            FinanceView view = new FinanceView();

            while (true)
            {
                string mainInventoryMenu = $@"
Expense Tracker

1. Income Options
2. Expense Options
3. Show Summary
4. Exit
Enter Choice: ";
                Console.WriteLine(mainInventoryMenu);
                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case (int)MainMenuOptions.IncomeOptions:
                            ViewHelper.IncomeOptions();
                            break;
                        case (int)MainMenuOptions.ExpenseOptions:
                            ViewHelper.ExpenseOptions();
                            break;
                        case (int)MainMenuOptions.ShowSummary:
                            view.ShowSummary();
                            break;
                        case (int)MainMenuOptions.Exit:
                            ViewHelper.WriteColored("Exiting...", ConsoleColor.Cyan);
                            Thread.Sleep(1000);
                            return;
                        default:
                            ViewHelper.WriteColored("Invalid Choice", ConsoleColor.Red);
                            break;
                    }
                }
                catch (FormatException)
                {
                    ViewHelper.WriteColored("Enter a numeric value in the menu\nReturning to Main Menu", ConsoleColor.Red);
                }
                catch (Exception ex)
                {
                    ViewHelper.WriteColored(ex.Message, ConsoleColor.Red);
                }
            }
        }
    }
}