using Reflection.Task1;
using Reflection.Task2;
using Reflection.Task3;
using Reflection.Task4;
using Reflection.Task5;
using Reflection.Task7;

namespace Reflection
{
    /// <summary>
    /// Entry class of the application.
    /// </summary>
    internal class Program
    {
        private static void Main(string[] args)
        {
            AssemblyInspector assemblyInspector = new AssemblyInspector();
            ObjectInspector objectInspector = new ObjectInspector();
            MethodInvoker methodInvoker = new MethodInvoker();
            DynamicTypeBuilder dynamicTypeBuilder = new DynamicTypeBuilder();
            PluginLoader pluginLoader = new PluginLoader();
            Serializer serializer = new Serializer();

            while (true)
            {
                string mainMenu = $@"
[A]ssembly Metadata
[O]bject Inspector
[M]ethod Invoker
[D]ynamic Type Builder
[P]lugin Loader
[S]erialization API
[E]xit
Enter Choice: ";
                Console.Write(mainMenu);
                ConsoleKey userChoice = Console.ReadKey().Key;
                Console.Clear();
                switch (userChoice)
                {
                    case ConsoleKey.A:
                        assemblyInspector.DisplayAssemblyData();
                        break;
                    case ConsoleKey.O:
                        objectInspector.PerformInspection();
                        break;
                    case ConsoleKey.M:
                        methodInvoker.GetDetails();
                        break;
                    case ConsoleKey.D:
                        dynamicTypeBuilder.Build();
                        break;
                    case ConsoleKey.P:
                        pluginLoader.Load();
                        break;
                    case ConsoleKey.S:
                        serializer.PerformOperation();
                        break;
                    case ConsoleKey.E:
                        Console.Write("\nExiting...");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Choice\n");
                        break;
                }
            }
        }
    }
}