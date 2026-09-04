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
1. Task 1
2. Task 2
3. Task 3
4. Task 4
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