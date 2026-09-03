using ValueAndReferenceTypes.Task1;
using ValueAndReferenceTypes.Task2;

namespace ValueAndReferenceTypes
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ValueAndReferenceTask typeTask = new ValueAndReferenceTask();
            StackAndHeapTask stackAndHeapTask = new StackAndHeapTask();
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
                        break;
                    case 4:
                        Console.Clear();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid Choice\n");
                        break;
                }
            }
        }
    }
}