using System.Diagnostics;
using System.Text;

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
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            long targetFileSize = 1024L * 1024L * 1024L;
            string sampleData = "a quick brown fox jumped over the lazy dog\n";
            Console.WriteLine("Generating 1 GB text file...");
            using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write, FileShare.None, bufferSize: 1024 * 1024))
            {
                while (fileStream.Length < targetFileSize)
                {
                    byte[] data = Encoding.UTF8.GetBytes(sampleData);
                    fileStream.Write(data);
                }
            }

            stopwatch.Stop();
            Console.WriteLine("Successfully created 1 GB text file\n");
            Console.WriteLine($"Time taken to generate 1gb file : {stopwatch.Elapsed.TotalMilliseconds} milliseconds");
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