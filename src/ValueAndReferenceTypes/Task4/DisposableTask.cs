namespace ValueAndReferenceTypes.Task4
{
    /// <summary>
    /// Performs File data handling.
    /// </summary>
    internal static class DisposableTask
    {
        /// <summary>
        ///  Writes and Reads File Data.
        /// </summary>
        internal static void MemoryTask()
        {
            Console.Clear();
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

            Console.WriteLine($@"Data in line one: {firstLineData}
Data in line two: {secondLineData}
Data in line three: {thirdLineData}
Data in line four: {fourthLineData}
Data in line five: {fifthLineData}
Data in line six: {sixthLineData}");
            CleanConsole();
        }

        private static void CleanConsole()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}