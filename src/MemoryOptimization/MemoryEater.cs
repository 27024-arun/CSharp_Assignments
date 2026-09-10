namespace MemoryOptimization
{
    /// <summary>
    /// Contains logic to allocate memory
    /// </summary>
    internal class MemoryEater
    {
        private List<int[]> _memAlloc = new List<int[]>();

        /// <summary>
        /// Allocates memory and adds it to a list
        /// </summary>
        public void Allocate()
        {
            Console.WriteLine("\nMemory usage level is rising check diagnostic tool for memory check");
            while (true)
            {
                this._memAlloc.Add(new int[1000]);
                Thread.Sleep(10);
            }
        }
    }
}
