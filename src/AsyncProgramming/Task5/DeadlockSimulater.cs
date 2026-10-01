namespace AsyncProgramming.Task5
{
    internal class DeadlockSimulater
    {
        private readonly object _lockObject1 = new object();

        private readonly object _lockObject2 = new object();

        public void DeadlockPerformer()
        {
            string header = $@"
=====================================
            DeadLock
=====================================
[D]eadlock code output
[S]olved Deadlock code output

Enter choice: ";
            Console.Write(header);
            ConsoleKey userChoice = Console.ReadKey().Key;
            if (userChoice == ConsoleKey.D)
            {
                this.SimulateDeadLock();
            }
            else if (userChoice == ConsoleKey.S)
            {
                this.PeformWithoutDeadlock();
            }

            ConsoleHelper.CleanConsole();
        }

        private void PeformWithoutDeadlock()
        {
            var result = this.SomeAsyncOperation().Result;
            Console.WriteLine($"\n{result}");
        }

        private void SimulateDeadLock()
        {
            var result = this.SomeAsyncOperation();
            Console.WriteLine($"\n{result}");
        }

        private async Task<string> SomeAsyncOperation()
        {
            await Task.Delay(1000);
            return "Hello, World!";
        }
    }
}
