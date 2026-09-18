using Task1;
using Task2;
using Task3;
using Task4;

namespace AdvancedConcepts
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            EventSubscriber subscriber = new EventSubscriber();
            AdvancedKeywordUser keywordUser = new AdvancedKeywordUser();
            ArraySorter arraySorter = new ArraySorter();
            LambdaProvider lambdaProvider = new LambdaProvider();

            while (true)
            {
                string userMenu = $@"
===========C# Advanced Concepts===========
1. Delegate and Events
2. Keyword Usage (var and dynamic)
3. Anonymous method Usage (Sort Array)
4. Lambda expression and statement
5. Sorting using delegate
6. 
7. 
8. Exit

Enter Choice: ";
                Console.Write(userMenu);
                int.TryParse(Console.ReadLine(), out int userChoice);
                Console.Clear();
                switch (userChoice)
                {
                    case 1:
                        subscriber.SubscribeNotification();
                        break;
                    case 2:
                        keywordUser.PerformVariableChange();
                        break;
                    case 3:
                        arraySorter.SortArray();
                        break;
                    case 4:
                        lambdaProvider.PerformFiltering();
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        Console.WriteLine($"Exiting...");
                        Thread.Sleep(1200);
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine($"Invalid Choice");
                        Helper.CleanConsole();
                        break;
                }
            }
        }
    }
}