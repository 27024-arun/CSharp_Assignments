using System.Diagnostics;
using ValueAndReferenceTypes.Models;

namespace ValueAndReferenceTypes.Task2
{
    /// <summary>
    /// Monitors the change in stack and heap objects.
    /// </summary>
    internal class StackAndHeapTask
    {
        private readonly List<int[]> _memoryList = new List<int[]>();

        /// <summary>
        /// Displays the memory usage to the user.
        /// </summary>
        internal void MemoryTask()
        {
            Process currentProcess = Process.GetCurrentProcess();
            Console.WriteLine("============Memory Usage============");
            Console.WriteLine("Memory usage before array creation");
            Console.WriteLine($"Working Set: {currentProcess.WorkingSet64 / 1024 / 1024:F2} MB");
            this.MemoryModifier(currentProcess);
            currentProcess.Dispose();
        }

        /// <summary>
        /// Increases the heap memory of the application.
        /// </summary>
        /// <param name="currentProcess">Active process in the application.</param>
        private void MemoryModifier(Process currentProcess)
        {
            Console.WriteLine("Memory usage after array creation");
            while (true)
            {
                this._memoryList.Add(new int[10000000]);
                this.AllocateOnStack();
                currentProcess.Refresh();
                Console.WriteLine($"Working Set: {currentProcess.WorkingSet64 / 1024 / 1024:F2} MB");
            }
        }

        /// <summary>
        /// Increases stack memory of the application.
        /// </summary>
        private void AllocateOnStack()
        {
            for (int i = 0; i < 1000; i++)
            {
                Teacher teacher = new ();
                var teacherData = teacher;
            }
        }
    }
}