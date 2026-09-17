namespace AdvancedConcepts
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            EventSubscriber subscriber = new EventSubscriber();
            while (true)
            {
                string userMenu = $@"
===========C# Advanced Concepts===========
1. Delegate and Events
6. Exit

Enter Choice: ";
                Console.Write(userMenu);
                int.TryParse(Console.ReadLine(), out int userChoice);
                Console.Clear();
                switch (userChoice)
                {
                    case 1:
                        subscriber.SubscribeNotification();
                        break;
                    case 6:
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