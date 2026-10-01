namespace AsyncProgramming.Task7
{
    internal class ExceptionHandler
    {
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
                this.PerformTaskException().GetAwaiter().GetResult();
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
                this.VoidExceptionProvider();
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nVoid Exception: {e.Message}");
            }
        }

        private async Task PerformTaskException()
        {
            try
            {
                await this.TaskExceptionProvider();
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nTask Exception: {e.Message}");
            }
        }

        private async Task TaskExceptionProvider()
        {
            await Task.Delay(1000);
            throw new Exception("Task method exception");
        }

        private async void VoidExceptionProvider()
        {
            await Task.Delay(1000);
            throw new Exception("Void method exception");
        }
    }
}
