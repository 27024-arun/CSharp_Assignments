namespace Task1
{
    internal class Notify
    {
        public delegate void NotificationHandler(string message);

        public event NotificationHandler? NotifierEvent;

        public void NotifyUser(string message)
        {
            NotifierEvent?.Invoke(message);
        }
    }
}
