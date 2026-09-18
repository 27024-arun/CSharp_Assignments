namespace Task1
{
    /// <summary>
    /// Notify class contains delegates and event for notification to user.
    /// </summary>
    internal static class Notify
    {
        /// <summary>
        /// NotificationHandler is the type safe method reference.
        /// </summary>
        /// <param name="message">Message to be displayed to user.</param>
        public delegate void NotificationHandler(string message);

        /// <summary>
        /// Event which triggers notification to user.
        /// </summary>
        public static event NotificationHandler? OnAction;

        /// <summary>
        /// Notifies user with message.
        /// </summary>
        /// <param name="message">Message to be displayed to user.</param>
        public static void NotifyUser(string message)
        {
            OnAction?.Invoke(message);
        }
    }
}