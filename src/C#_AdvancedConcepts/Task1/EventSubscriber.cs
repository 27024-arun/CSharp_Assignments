using AdvancedConcepts;

namespace Task1
{
    /// <summary>
    /// Subscriber event to display notification to user.
    /// </summary>
    internal static class EventSubscriber
    {
        /// <summary>
        /// Notifies user by subscribing to an event.
        /// </summary>
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