using AsyncProgramming.Task1;
using AsyncProgramming.Task2;
using AsyncProgramming.Task3;
using AsyncProgramming.Task4;
using AsyncProgramming.Task5;
using AsyncProgramming.Task6;
using AsyncProgramming.Task7;

namespace Assignments
{
    /// <summary>
    /// Program is the initialising Class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main is the initialising function.
        /// </summary>
        private static void Main()
        {
            BasicAsyncProgram basicAsync = new BasicAsyncProgram();
            TaskParallelLibrary taskParallelLibrary = new TaskParallelLibrary();
            Operator operate = new Operator();
            ChainOperator chainOperator = new ChainOperator();
            DeadlockSimulater deadlockSimulater = new DeadlockSimulater();
            AwaitConfigure awaitConfigurer = new AwaitConfigure();
            ExceptionHandler exceptionHandler = new ExceptionHandler();

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
7. Handle Exception
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
                        chainOperator.OperateAsync().GetAwaiter().GetResult();
                        break;
                    case 5:
                        deadlockSimulater.DeadlockPerformer();
                        break;
                    case 6:
                        awaitConfigurer.PerformAsync().GetAwaiter().GetResult();
                        break;
                    case 7:
                        exceptionHandler.HandleException();
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