using Calculator;
using CalculatorUtility;

namespace Assignments
{
    /// <summary>
    /// Program class is the entry class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method is the (starting) entry point of the application.
        /// </summary>
        public static void Main()
        {
            MathUtils mathUtils = new MathUtils();
            UserView retrieveData = new UserView(mathUtils);
            while (true)
            {
                try
                {
                    string mainMenu = $@"
Calculator Menu Options
[A]dd Numbers:
[S]ubtract Numbers:
[M]ultiple Numbers
[D]ivide Numbers
[E]xit
Enter Choice: ";
                    Console.Write(mainMenu);
                    ConsoleKey userChoice = Console.ReadKey().Key;
                    switch (userChoice)
                    {
                        case ConsoleKey.A:
                            retrieveData.AddUserData();
                            break;
                        case ConsoleKey.S:
                            retrieveData.SubtractUserData();
                            break;
                        case ConsoleKey.M:
                            retrieveData.MultiplyUserData();
                            break;
                        case ConsoleKey.D:
                            retrieveData.DivideUserData();
                            break;
                        case ConsoleKey.E:
                            Console.WriteLine("\nExiting...");
                            Thread.Sleep(1200);
                            return;
                        default:
                            Console.Clear();
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}