namespace AsyncProgramming.Task7
{
    /// <summary>
    /// Performs asynchronous method exception handling.
    /// </summary>
    internal class ExceptionHandler
    {
        /// <summary>
        /// Peforms exception handling in both void and task returning methods.
        /// </summary>
        public void HandleException()
        {
            string header = $@"
=====================================
            Exception
=====================================
[T]ask Exception
[V]oid Exception

Enter Choice: ";
            Console.Write(header);
            ConsoleKey userChoice = Console.ReadKey().Key;
            if (userChoice == ConsoleKey.T)
            {
                this.PerformTaskExceptionAsync().GetAwaiter().GetResult();
            }
            else if (userChoice == ConsoleKey.V)
            {
                this.PerformVoidException();
            }

            ConsoleHelper.CleanConsole();
        }

        private void PerformVoidException()
        {
            try
            {
                this.VoidExceptionProviderAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nVoid Exception: {e.Message}");
            }
        }

        private async Task PerformTaskExceptionAsync()
        {
            try
            {
                await this.TaskExceptionProviderAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nTask Exception: {e.Message}");
            }
        }

        private async Task TaskExceptionProviderAsync()
        {
            await Task.Delay(1000);
            throw new Exception("Task method exception");
        }

        private async void VoidExceptionProviderAsync()
        {
            await Task.Delay(1000);
            throw new Exception("Void method exception");
        }
    }
}
