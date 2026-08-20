using AdvancedExpenseTracker.Models;
using AdvancedExpenseTracker.Repository;
using AdvancedExpenseTracker.Services;
using AdvancedExpenseTracker.View;

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
            JSONIncomeRepository incomeRepository = new JSONIncomeRepository();
            IncomeServices incomeServices = new IncomeServices(incomeRepository);
            IncomeView incomeView = new IncomeView(incomeServices);

            JSONExpenseRepository expenseRepository = new JSONExpenseRepository();
            ExpenseServices expenseServices = new ExpenseServices(expenseRepository);
            ExpenseView expenseView = new ExpenseView(expenseServices);

            SummaryServices summaryServices = new SummaryServices(incomeRepository, expenseRepository);
            SummaryView summaryView = new SummaryView(summaryServices);
            while (true)
            {
                string mainMenu = @"
Expense Tracker
 
1. Income Options
2. Expense Options
3. Show Summary
4. Exit
Enter Choice: ";

                Console.Write(mainMenu);

                try
                {
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)
                    {
                        case (int)MainMenuOptions.IncomeOptions:
                            ViewHelper.IncomeOptions(incomeView);
                            break;

                        case (int)MainMenuOptions.ExpenseOptions:
                            ViewHelper.ExpenseOptions(expenseView);
                            break;

                        case (int)MainMenuOptions.ShowSummary:
                            summaryView.SummaryOptions();
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
                catch (FormatException e)
                {
                    Console.WriteLine(e.StackTrace);
                    ViewHelper.WriteColored("Enter a numeric value.", ConsoleColor.Red);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    ViewHelper.WriteColored(ex.Message, ConsoleColor.Red);
                }
            }
        }
    }
}