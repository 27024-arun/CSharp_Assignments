namespace FilesAndStreams
{
    internal static class Helper
    {
        public static void GenerateOneGBFile(string fileName)
        {
            long targetFileSize = 1024L * 1024L * 1024L;
            string sampleData = "a quick brown fox jumped over the lazy dog";
            Console.WriteLine("Generating 1 GB text file...");
            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                while (writer.BaseStream.Length < targetFileSize)
                {
                    writer.WriteLine(sampleData);
                }
            }

            Console.WriteLine("Successfully created 1 GB text file\n");
        }

        public static void CleanConsole()
        {
            Console.WriteLine("\nEnter a key to return to main menu");
            Console.ReadKey();
            Console.Clear();
        }
    }
}