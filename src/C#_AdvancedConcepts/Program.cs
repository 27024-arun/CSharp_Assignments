using Task1;
using Task2;
using Task3;
using Task4;
using Task5;
using Task6;
using Task7;

namespace AdvancedConcepts
{
    /// <summary>
    /// Program is the entry level class.
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            while (true)
            {
                BookObserver bookObserver = new BookObserver();
                ShapeAccessor shapeModifier = new ShapeAccessor();
                string userMenu = $@"
===========C# Advanced Concepts===========
1. Delegate and Events
2. Keyword Usage (var and dynamic)
3. Anonymous method Usage (Sort Array)
4. Lambda expression and statement
5. Sorting using delegate
6. Record Usage (Book details)
7. Pattern Matching (Shapes) 
8. Exit

Enter Choice: ";
                Console.Write(userMenu);
                int.TryParse(Console.ReadLine(), out int userChoice);
                Console.Clear();
                switch (userChoice)
                {
                    case 1:
                        EventSubscriber.SubscribeNotification();
                        break;
                    case 2:
                        AdvancedKeywordUser.PerformVariableChange();
                        break;
                    case 3:
                        ArraySorter.SortArray();
                        break;
                    case 4:
                        LambdaProvider.PerformFiltering();
                        break;
                    case 5:
                        ProductSorter.PerformProductSort();
                        break;
                    case 6:
                        bookObserver.ViewBooks();
                        break;
                    case 7:
                        shapeModifier.DisplayShape();
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