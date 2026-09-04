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
        public static void Main()
        {
            ValueAndReferenceTask typeTask = new ValueAndReferenceTask();
            StackAndHeapTask stackAndHeapTask = new StackAndHeapTask();
            GarbageCollectorTask garbageCollectorTask = new GarbageCollectorTask();
            DisposableTask disposableTask = new DisposableTask();
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
                        Console.Clear();
                        typeTask.MemoryTask();
                        break;
                    case 2:
                        Console.Clear();
                        stackAndHeapTask.MemoryTask();
                        break;
                    case 3:
                        Console.Clear();
                        garbageCollectorTask.MemoryTask();
                        break;
                    case 4:
                        Console.Clear();
                        disposableTask.MemoryTask();
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