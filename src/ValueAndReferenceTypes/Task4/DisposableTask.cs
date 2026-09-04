namespace ValueAndReferenceTypes.Task4
{
    /// <summary>
    /// Performs File data handling.
    /// </summary>
    internal class DisposableTask
    {
        /// <summary>
        ///  Writes and Reads File Data.
        /// </summary>
        internal void MemoryTask()
        {
            using (FileWriter writer = new FileWriter("Sample.txt"))
            {
                writer.Write("Peter");
                writer.Write("Parker");
                writer.Write("Tobey");
                writer.Write("Andrew");
                writer.Write("Jack");
                writer.Write("Mark");
            }

            using FileReader reader = new FileReader("Sample.txt");
            var firstLineData = reader.ReadData(1);
            var secondLineData = reader.ReadData(2);
            var thirdLineData = reader.ReadData(3);
            var fourthLineData = reader.ReadData(4);
            var fifthLineData = reader.ReadData(5);
            var sixthLineData = reader.ReadData(6);

            Console.WriteLine($"Data in line one: {firstLineData}");
            Console.WriteLine($"Data in line two: {secondLineData}");
            Console.WriteLine($"Data in line three: {thirdLineData}");
            Console.WriteLine($"Data in line four: {fourthLineData}");
            Console.WriteLine($"Data in line five: {fifthLineData}");
            Console.WriteLine($"Data in line six: {sixthLineData}");
            reader.Dispose();
            this.CleanConsole();
        }

        private void CleanConsole()
        {
            Console.WriteLine("\nEnter a key to return");
            Console.ReadKey();
            Console.Clear();
        }
    }
}