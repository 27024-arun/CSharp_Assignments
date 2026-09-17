using System.Diagnostics;
using System.Text;

namespace FilesAndStreams.Synchronous
{
    /// <summary>
    /// Write data to a file using different memory stream.
    /// </summary>
    internal class DataWriter
    {
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataWriter"/> class.
        /// </summary>
        /// <param name="filePath">Path in which the file is stored.</param>
        public DataWriter(string filePath)
        {
            this._filePath = filePath;
        }

        /// <summary>
        /// Analyzes the performance of writing operation using different types of streams.
        /// </summary>
        internal void WriteMemoryStream()
        {
            Console.WriteLine($"=============Write Operation=============");
            Helper.GenerateOneGBFile(this._filePath);
            Console.WriteLine($"Initialized writing data...");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            byte[] buffer = new byte[4096 * 16];

            using (FileStream fileStream = new FileStream(this._filePath, FileMode.Open, FileAccess.Read))
            using (MemoryStream memoryStream = new MemoryStream())
            {
                int bytesRead;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    string processedData = data.ToUpper();
                    byte[] processedBytes = Encoding.UTF8.GetBytes(processedData);

                    memoryStream.Write(processedBytes, 0, processedBytes.Length);
                }

                memoryStream.Position = 0;
                using (FileStream outputStream = new FileStream("Sample2.txt", FileMode.Create, FileAccess.Write))
                {
                    memoryStream.CopyTo(outputStream);
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"Memory Stream: Time taken to write file is {stopwatch.Elapsed.TotalSeconds} seconds");
            Helper.CleanConsole();
        }
    }
}