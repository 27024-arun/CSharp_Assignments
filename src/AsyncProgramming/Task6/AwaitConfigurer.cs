namespace AsyncProgramming.Task6
{
    internal class AwaitConfigurer
    {
        public async Task Perform()
        {
            string header = $@"
=====================================
          Await Configure
=====================================";
            Console.Write(header);
            Console.WriteLine($"Main method - Thread ID: {Thread.CurrentThread.ManagedThreadId}");

            int squaredValue = await this.AwaiterMethod();
            Console.WriteLine($"Squared result: {squaredValue}");

            ConsoleHelper.CleanConsole();
        }

        private async Task<int> AwaiterMethod()
        {
            Console.WriteLine($"Method B - Before Method A - Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            int data = await this.AwaitConfigurer();

            Console.WriteLine($"Method B - After Method A - Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            return data * 2;
        }

        private async Task<int> AwaitConfigurer()
        {
            Console.WriteLine($"Method A - Before await  - Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(2000).ConfigureAwait(false);

            Console.WriteLine($"Method A - After await  - Thread ID: {Thread.CurrentThread.ManagedThreadId}");
            return 1;
        }
    }
}
