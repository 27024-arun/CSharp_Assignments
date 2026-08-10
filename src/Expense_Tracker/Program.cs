using Expense_Tracker.Models;
using Expense_Tracker.View;

namespace ExpenseTracker
{
    /// <summary>
    /// Program is the entry class of the application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method is the entry point of the application.
        /// </summary>
        public static void Main()
        {
            FinanceView view = new FinanceView();

            while (true)
            {
                string mainMenu = @"
Expense Tracker
 
1. Income Options
2. Expense Options
3. Show Summary
4. Exit
Enter Choice: ";

                Console.WriteLine(mainMenu);

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case (int)MainMenuOptions.IncomeOptions:
                            ViewHelper.IncomeOptions(view);
                            break;

                        case (int)MainMenuOptions.ExpenseOptions:
                            ViewHelper.ExpenseOptions(view);
                            break;

                        case (int)MainMenuOptions.ShowSummary:
                            view.ShowSummary();
                            break;

                        case (int)MainMenuOptions.Exit:
                            ViewHelper.WriteColored("Exiting...", ConsoleColor.Cyan);
                            Thread.Sleep(1000);
                            return;

                        default:
                            ViewHelper.WriteColored("Invalid Choice.", ConsoleColor.Red);
                            break;
                    }
                }
                catch (FormatException)
                {
                    ViewHelper.WriteColored("Enter a numeric value.", ConsoleColor.Red);
                }
                catch (Exception ex)
                {
                    ViewHelper.WriteColored(ex.Message, ConsoleColor.Red);
                }
            }
        }
    }
}
