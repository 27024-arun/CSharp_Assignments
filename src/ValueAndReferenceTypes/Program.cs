using ValueAndReferenceTypes.Task1;
using ValueAndReferenceTypes.Task2;
using ValueAndReferenceTypes.Task3;
using ValueAndReferenceTypes.Task4;

namespace ValueAndReferenceTypes
{
    /// <summary>
    /// Program is the entry class of the application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method is the entry point of the application.
        /// </summary>
        private static void Main()
        {
            while (true)
            {
                string mainMenu = $@"
1. Value and Reference Type Object Handling Task
2. Stack and Heap Memory Task
3. Garbage Collector Task
4. Dispose Usage Task
5. Exit
Enter Choice: ";
                Console.Write(mainMenu);
                int.TryParse(Console.ReadLine(), out int userChoice);
                switch (userChoice)
                {
                    case 1:
                        ValueAndReferenceTask.MemoryTask();
                        break;
                    case 2:
                        StackAndHeapTask.MemoryTask();
                        break;
                    case 3:
                        GarbageCollectorTask.MemoryTask();
                        break;
                    case 4:
                        DisposableTask.MemoryTask();
                        break;
                    case 5:
                        Console.WriteLine("Exiting...");
                        Thread.Sleep(1000);
                        return;
                    default:
                        Console.WriteLine("Invalid Choice\n");
                        break;
                }
            }
        }
    }
}