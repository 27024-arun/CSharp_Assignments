using Reflection.Task1;
using Reflection.Task2;
using Reflection.Task3;
using Reflection.Task4;
using Reflection.Task5;

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

            while (true)
            {
                string mainMenu = $@"
1. Assembly Metadata
2. Object Inspector
3. Method Invoker
4. Dynamic Type Builder
5. Plugin Loader
6.
7.
8. Exit
Enter Choice: ";
                Console.Write(mainMenu);
                int.TryParse(Console.ReadLine(), out int userChoice);
                Console.Clear();
                switch (userChoice)
                {
                    case 1:
                        assemblyInspector.DisplayAssemblyData();
                        break;
                    case 2:
                        objectInspector.PerformInspection();
                        break;
                    case 3:
                        methodInvoker.GetDetails();
                        break;
                    case 4:
                        dynamicTypeBuilder.Build();
                        break;
                    case 5:
                        pluginLoader.Load();
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        return;
                    default:
                        Console.WriteLine("Invalid Choice\n");
                        break;
                }
            }
        }
    }
}