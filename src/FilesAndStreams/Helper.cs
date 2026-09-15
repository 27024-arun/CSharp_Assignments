namespace FilesAndStreams
{
    internal static class Helper
    {
        public static void GenerateOneGBFile()
        {
            long targetFileSize = 1024L * 1024L * 1024L;
            string sampleData = "A quick brown fox jumped over the lazy dog.";
            Console.WriteLine("Writing data into the file");
            using (StreamWriter writer = new StreamWriter("Sample.txt", false))
            {
                while (writer.BaseStream.Length < targetFileSize)
                {
                    writer.Write(sampleData);
                }
            }

            Console.WriteLine("Successfully created one GB text file");
            CleanConsole();
        }

        public static void CleanConsole()
        {
            Console.WriteLine("\nEnter a key to return to main menu");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
