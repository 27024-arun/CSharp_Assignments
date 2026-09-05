using System.Diagnostics;
using ValueAndReferenceTypes.Models;

namespace ValueAndReferenceTypes.Task2
{
    /// <summary>
    /// Monitors the change in stack and heap objects.
    /// </summary>
    internal class StackAndHeapTask
    {
        private static List<int[]> _memoryList = new List<int[]>();

        /// <summary>
        /// Displays the memory usage to the user.
        /// </summary>
        internal static void MemoryTask()
        {
            Console.Clear();
            Process currentProcess = Process.GetCurrentProcess();
            Console.WriteLine($@"============Memory Usage============
Memory usage before array creation
Working Set: {currentProcess.WorkingSet64 / 1024 / 1024:F2} MB");
            MemoryModifier(currentProcess);
            currentProcess.Dispose();
        }

        /// <summary>
        /// Increases the heap memory of the application.
        /// </summary>
        /// <param name="currentProcess">Active process in the application.</param>
        private static void MemoryModifier(Process currentProcess)
        {
            Console.WriteLine("Memory usage after array creation");
            while (true)
            {
                _memoryList.Add(new int[10_000_000]);
                AllocateOnStack();
                currentProcess.Refresh();
                Console.WriteLine($"Working Set: {currentProcess.WorkingSet64 / 1024 / 1024:F2} MB");
            }
        }

        /// <summary>
        /// Increases stack memory of the application.
        /// </summary>
        private static void AllocateOnStack()
        {
            int iterationLimit = 1000;
            for (int iterator = 0; iterator < iterationLimit; iterator++)
            {
                Teacher teacher = new ();
                var teacherData = teacher;
            }
        }
    }
}