using IGreetPlugin;

namespace GreetingPlugin
{
    /// <summary>
    /// Displays the greeting message.
    /// </summary>
    public class GreetingPlugin : IPlugin
    {
        /// <inheritdoc/>
        public void Greet()
        {
            Console.WriteLine($"Hello!");
        }
    }
}
