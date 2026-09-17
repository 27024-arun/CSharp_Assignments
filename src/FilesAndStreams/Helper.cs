namespace FilesAndStreams
{
    /// <summary>
    /// Helps console clearing operations
    /// </summary>
    internal static class Helper
    {
        /// <summary>
        /// Generates a one gigabyte text file.
        /// </summary>
        /// <param name="filePath">Path in which the file is stored.</param>
        public static void GenerateOneGBFile(string filePath)
        {
            long targetFileSize = 1024L * 1024L * 1024L;
            string sampleData = "a quick brown fox jumped over the lazy dog";
            Console.WriteLine("Generating 1 GB text file...");
            using (StreamWriter writer = new StreamWriter(filePath, false))
            {
                while (writer.BaseStream.Length < targetFileSize)
                {
                    writer.WriteLine(sampleData);
                }
            }

            Console.WriteLine("Successfully created 1 GB text file\n");
        }

        /// <summary>
        /// Clears console for user experience.
        /// </summary>
        public static void CleanConsole()
        {
            Console.WriteLine("\nEnter a key to return to main menu");
            Console.ReadKey();
            Console.Clear();
        }
    }
}