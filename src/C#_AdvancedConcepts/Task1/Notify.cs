namespace Task1
{
    internal static class Notify
    {
        public delegate void NotificationHandler(string message);

        public static event NotificationHandler? OnAction;

        public static void NotifyUser(string message)
        {
            OnAction?.Invoke(message);
        }
    }
}