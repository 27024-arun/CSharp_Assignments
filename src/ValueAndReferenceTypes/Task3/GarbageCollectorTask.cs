using System.Diagnostics;
using ValueAndReferenceTypes.Models;

namespace ValueAndReferenceTypes.Task3
{
    /// <summary>
    /// Visualizes garbage collector activities.
    /// </summary>
    internal class GarbageCollectorTask
    {
        private readonly List<Student> _students = new List<Student>();

        /// <summary>
        /// Creates a process and monitors it.
        /// </summary>
        internal void MemoryTask()
        {
            using Process currentProcess = Process.GetCurrentProcess();

            Console.WriteLine("============ Memory Usage ============");
            Console.WriteLine("Before allocations:");
            double workingSetMB = currentProcess.WorkingSet64 / 1024.0 / 1024.0;
            Console.WriteLine($"Working Set: {currentProcess.WorkingSet64:N0} bytes ({workingSetMB:F2} MB)");
            this.MemoryModifier(currentProcess);
        }

        /// <summary>
        /// Creates referenced and unreferenced object for Garbage Collection and displays memory usage output.
        /// </summary>
        /// <param name="currentProcess">Current active process.</param>
        private void MemoryModifier(Process currentProcess)
        {
            for (int i = 0; i < 50_000; i++)
            {
                var tempStudent = new Student();

                if (i % 5000 == 0)
                {
                    this._students.Add(tempStudent);
                }

                if (i % 10000 == 0 && i != 0)
                {
                    Console.WriteLine($"Forcing GC at iteration {i}...");
                    GC.Collect();
                }

                currentProcess.Refresh();
                double workingSetMB = currentProcess.WorkingSet64 / 1024.0 / 1024.0;
                Console.WriteLine($"Working Set: {currentProcess.WorkingSet64:N0} bytes ({workingSetMB:F2} MB)");
            }
        }
    }
}