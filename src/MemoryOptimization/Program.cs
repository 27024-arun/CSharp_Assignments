namespace MemoryOptimization
{
    /// <summary>
    /// Application entry point.
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            MemoryEater memoryEater = new MemoryEater();
            while (true)
            {
                string mainMenu = $@"
1. Memory Eater Task
2. Memory Optimization Task
3. Exit
Enter Choice: ";
                Console.Write(mainMenu);
                int.TryParse(Console.ReadLine(), out int userChoice);
                switch (userChoice)
                {
                    case 1:
                        memoryEater.Allocate();
                        break;
                    case 2:
                        using (MemoryModifier memoryModifier = new MemoryModifier())
                        {
                            memoryModifier.Allocate();
                        }

                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
        }
    }
}