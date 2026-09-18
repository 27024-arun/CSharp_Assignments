using AdvancedConcepts;

namespace Task1
{
    internal class EventSubscriber
    {
        public void SubscribeNotification()
        {
            Notify notify = new Notify();
            notify.NotifierEvent += UserNotification;

            Console.Write("===========Delegates and Events===========\nEnter your name: ");
            string? userName = Console.ReadLine();

            notify.NotifyUser($"Welcome to application {userName}!");
            Helper.CleanConsole();
        }

        private void UserNotification(string message)
        {
            Console.WriteLine(message);
        }
    }
}
