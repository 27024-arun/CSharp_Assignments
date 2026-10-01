using System.Diagnostics;

namespace AsyncProgramming.Task2
{
    internal class TaskParallelLibrary
    {
        public void Execute()
        {
            string header = $@"
=====================================
        Async Data Download
=====================================";
            Console.Write(header);

            int[] numbers = Enumerable.Range(1, 10000).ToArray();
            int[] results = new int[numbers.Length];

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Parallel.ForEach(numbers, (number, state, index) =>
            {
                int square = number * number;
                results[index] = square;
                Console.WriteLine($"Number: {number} - Square: {square} - Thread: {Environment.CurrentManagedThreadId}");
            });
            stopwatch.Stop();

            Console.WriteLine($"\nTime taken to process: {stopwatch.ElapsedMilliseconds} ms");
            ConsoleHelper.CleanConsole();
        }
    }
}