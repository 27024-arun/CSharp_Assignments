namespace MemoryOptimization
{
    /// <summary>
    /// Application entry point.
    /// </summary>
    internal class Program
    {
        private static void Main()
        {
            // MemoryEater memoryEater = new MemoryEater();
            // memoryEater.Allocate();
            using (MemoryModifier memoryModifier = new MemoryModifier())
            {
                memoryModifier.Allocate();
            }

            Console.ReadKey();
        }
    }
}