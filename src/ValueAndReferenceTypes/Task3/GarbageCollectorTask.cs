using System.Diagnostics;
using ValueAndReferenceTypes.Models;

namespace ValueAndReferenceTypes.Task3
{
    /// <summary>
    /// Visualizes garbage collector activities.
    /// </summary>
    internal static class GarbageCollectorTask
    {
        private static List<Student> _students = new List<Student>();

        /// <summary>
        /// Creates a process and monitors it.
        /// </summary>
        internal static void MemoryTask()
        {
            Console.Clear();
            using Process currentProcess = Process.GetCurrentProcess();

            Console.WriteLine($@"============ Memory Usage ============
Before allocations:
Working Set: {currentProcess.WorkingSet64 / 1024 / 1024:F2} MB");
            MemoryModifier(currentProcess);
        }

        /// <summary>
        /// Creates referenced and unreferenced object for Garbage Collection and displays memory usage output.
        /// </summary>
        /// <param name="currentProcess">Current active process.</param>
        private static void MemoryModifier(Process currentProcess)
        {
            int iterationLimit = 50_000;
            for (int i = 0; i < iterationLimit; i++)
            {
                var tempStudent = new Student();

                if (i % 5000 == 0)
                {
                    _students.Add(tempStudent);
                }

                if (i % 10000 == 0 && i != 0)
                {
                    Console.WriteLine($"Forcing GC at iteration {i}...");
                    GC.Collect();
                }

                currentProcess.Refresh();
                Console.WriteLine($"Working Set: {currentProcess.WorkingSet64 / 1024 / 1024:F2} MB");
            }
        }
    }
}