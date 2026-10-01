using AsyncProgramming.Task1;
using AsyncProgramming.Task2;
using AsyncProgramming.Task3;
using AsyncProgramming.Task4;
using AsyncProgramming.Task5;
using AsyncProgramming.Task6;

namespace Assignments
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            BasicAsyncProgram basicAsync = new BasicAsyncProgram();
            TaskParallelLibrary taskParallelLibrary = new TaskParallelLibrary();
            Operator operate = new Operator();
            ChainOperator chainOperator = new ChainOperator();
            DeadlockSimulater deadlockSimulater = new DeadlockSimulater();
            AwaitConfigurer awaitConfigurer = new AwaitConfigurer();

            while (true)
            {
                string mainMenu = $@"
=====================================
            Async Tasks
=====================================
1. Basic Async Program (Download content)
2. Task Parallel Library
3. Multi-threading
4. Multi-layered async/await
5. Deadlock codes
6. Configure Await
7. 
8. Exit

Enter Choice: ";
                Console.Write(mainMenu);
                int.TryParse(Console.ReadLine(), out int userChoice);
                Console.Clear();
                switch (userChoice)
                {
                    case 1:
                        basicAsync.ExecuteAsync().GetAwaiter().GetResult();
                        break;
                    case 2:
                        taskParallelLibrary.Execute();
                        break;
                    case 3:
                        operate.Operate();
                        break;
                    case 4:
                        chainOperator.Operate().GetAwaiter().GetResult();
                        break;
                    case 5:
                        deadlockSimulater.DeadlockPerformer();
                        break;
                    case 6:
                        awaitConfigurer.Perform().GetAwaiter().GetResult();
                        break;
                    case 7:
                        break;
                    case 8:
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