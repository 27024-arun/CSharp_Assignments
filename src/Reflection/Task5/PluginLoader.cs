using System.Reflection;
using IGreetPlugin;

namespace Reflection.Task5
{
    /// <summary>
    /// Loads the plugin dynamically.
    /// </summary>
    internal class PluginLoader
    {
        /// <summary>
        /// Performs plugin loading operation.
        /// </summary>
        public void Load()
        {
            Console.Write($"Enter Plugin DLL path: ");
            string? path = Console.ReadLine();
            if (!File.Exists(path))
            {
                Console.WriteLine($"Plugin file not found");
                return;
            }

            Assembly assembly = Assembly.Load(Path.GetFullPath(path));
            foreach (Type type in assembly.GetTypes())
            {
                if (type != null && type.IsClass && !type.IsAbstract && typeof(IPlugin).IsAssignableFrom(type))
                {
                    IPlugin? plugin = Activator.CreateInstance(type) as IPlugin;
                    if (plugin != null)
                    {
                        plugin.Greet();
                    }
                }
            }
        }
    }
}
