using BankingSystem.Repository;
using BankingSystem.Services;
using BankingSystem.View;

namespace BankingSystem
{
    /// <summary>
    /// Program is the entry level class of the program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main function is the entry level function of the program.
        /// </summary>
        public static void Main()
        {
            try
            {
                BankServices service = new BankServices(new BankRepository());

                while (true)
                {
                    string bankingMenu = @"
Banking System
1. Create Account
2. Deposit
3. Withdraw
4. View Account
5. Exit
Enter your choice: ";
                    Console.WriteLine(bankingMenu);
                    string? choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            BankView.CreateAccount(service);
                            break;

                        case "2":
                            BankView.DepositAmount(service);
                            break;

                        case "3":
                            BankView.WithdrawAmount(service);
                            break;

                        case "4":
                            BankView.ViewAccount(service);
                            break;

                        case "5":
                            Console.WriteLine("Exiting...");
                            Thread.Sleep(1000);
                            return;

                        default:
                            Console.WriteLine("Invalid choice. Please select a valid option.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
