using ErrorHandlerApplication.ErrorHandlingTasks;

namespace Assignments
{
    /// <summary>
    /// Program class is the entry class of the program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method is the entry point of the program.
        /// </summary>
        public static void Main()
        {
            DivisionTask division = new DivisionTask();
            ArrayTask arrayTask = new ArrayTask();
            CustomExceptionTask customExceptionTask = new CustomExceptionTask();
            UnhandledExceptionTask unhandledExceptionTask = new UnhandledExceptionTask();
            GlobalExceptionHandler globalExceptionHandler = new GlobalExceptionHandler();

            while (true)
            {
                try
                {
                    string menuOptions = $@"Main Menu Options
[1] Task 1 : Simple try-catch
[2] Task 2 : Types of Exceptions
[3] Task 3 : Custom Exception
[4] Task 4 : Unhandled Exception
[5] Task 5 : Global Exception Stack trace
[6] Exit.";

                    Console.WriteLine(menuOptions);
                    int userMenuInput = Convert.ToInt32(Console.ReadLine());
                    switch (userMenuInput)
                    {
                        case 1:
                            division.Divide();
                            break;
                        case 2:
                            arrayTask.Array();
                            break;
                        case 3:
                            customExceptionTask.CustomException();
                            break;
                        case 4:
                            unhandledExceptionTask.ExceptionHandling();
                            break;
                        case 5:
                            globalExceptionHandler.ExceptionHandling();
                            break;
                        case 6:
                            return;
                        default:
                            Console.WriteLine("Enter a valid choice");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}