namespace ValueAndReferenceTypes.Task4
{
    internal class DisposableTask
    {
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
            var thirdLineData = reader.ReadData(3);
            Console.WriteLine(thirdLineData);
            reader.Dispose();
        }
    }
}