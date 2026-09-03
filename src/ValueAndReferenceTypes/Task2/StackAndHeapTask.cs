using System.Diagnostics;

namespace ValueAndReferenceTypes.Task2
{
    internal class StackAndHeapTask
    {
        private readonly List<int[]> _memoryList = new List<int[]>();

        internal void MemoryTask()
        {
            Process currentProcess = Process.GetCurrentProcess();
            Console.WriteLine("============Memory Usage============");
            Console.WriteLine("Memory usage before array creation");
            Console.WriteLine($"Working Set: {currentProcess.WorkingSet64:N0} bytes ({currentProcess.WorkingSet64 / 1024.0 / 1024.0:F2} MB)");
            this.MemoryModifier(currentProcess);
            currentProcess.Dispose();
        }

        private void MemoryModifier(Process currentProcess)
        {
            Console.WriteLine("Memory usage after array creation");
            while (true)
            {
                currentProcess.Refresh();
                this._memoryList.Add(new int[10000000]);
                var mem = currentProcess.WorkingSet64 / 1024.0 / 1024.0;
                Console.WriteLine($"Working Set: {currentProcess.WorkingSet64:N0} bytes ({mem:F2} MB)");
                Console.WriteLine();
            }
        }
    }
}
