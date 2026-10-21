using System.Reflection;

namespace Reflection.Task1
{
    /// <summary>
    /// Inspects executing assembly data.
    /// </summary>
    internal class AssemblyInspector
    {
        /// <summary>
        /// Displays the current assembly data.
        /// </summary>
        public void DisplayAssemblyData()
        {
            Assembly assembly = Assembly.LoadFile(Assembly.GetExecutingAssembly().Location);
            foreach (Type type in assembly.GetTypes())
            {
                Console.WriteLine("\nType: " + type.Name);
                foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static))
                {
                    Console.WriteLine("Method: " + method.Name);
                }

                foreach (PropertyInfo property in type.GetProperties())
                {
                    Console.WriteLine("Method: " + property.Name);
                }

                foreach (FieldInfo field in type.GetFields(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static))
                {
                    Console.WriteLine("Method: " + field.Name);
                }

                foreach (EventInfo eventInfo in type.GetEvents())
                {
                    Console.WriteLine("Method: " + eventInfo.Name);
                }
            }

            ConsoleHelper.CleanConsole();
        }
    }
}
