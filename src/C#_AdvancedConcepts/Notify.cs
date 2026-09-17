namespace AdvancedConcepts
{
    internal class Notify
    {
        public delegate void NotificationHandler(string message);

        public event NotificationHandler? NotifierEvent;

        public void NotifyUser(string message)
        {
            this.NotifierEvent?.Invoke(message);
        }
    }
}
