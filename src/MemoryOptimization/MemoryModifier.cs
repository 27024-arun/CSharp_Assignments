namespace MemoryOptimization
{
    /// <summary>
    /// Makes memory not to go out of bound.
    /// </summary>
    internal class MemoryModifier : IDisposable
    {
        private readonly int _maxData;
        private List<int[]>? _memAlloc;
        private bool _isDisposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="MemoryModifier"/> class.
        /// </summary>
        /// <param name="maxData">Maximum data to be stored in the list.</param>
        public MemoryModifier(int maxData = 100)
        {
            this._maxData = maxData;
            this._memAlloc = new List<int[]>();
            this._isDisposed = false;
        }

        /// <summary>
        /// Allocates memory and adds it to a list.
        /// </summary>
        public void Allocate()
        {
            while (!this._isDisposed)
            {
                this._memAlloc.Add(new int[1000]);
                if (this._memAlloc.Count > this._maxData)
                {
                    return;
                }

                Console.WriteLine($"Current Memory Usage: {GC.GetAllocatedBytesForCurrentThread() / 1024 / 1024}Mb");
                Thread.Sleep(10);
            }
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this._memAlloc = null;
            this._isDisposed = true;
            GC.Collect();
        }
    }
}
