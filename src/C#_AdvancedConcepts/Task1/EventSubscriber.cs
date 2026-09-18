using AdvancedConcepts;

namespace Task1
{
    internal static class EventSubscriber
    {
        public static void SubscribeNotification()
        {
            Notify.OnAction += UserNotification;

            Console.Write("===========Delegates and Events===========\nEnter your name: ");
            string? userName = Console.ReadLine();

            Notify.NotifyUser($"Welcome to application {userName}!");
            Helper.CleanConsole();
        }

        private static void UserNotification(string message)
        {
            Console.WriteLine(message);
        }
    }
}