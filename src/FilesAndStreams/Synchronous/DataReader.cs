using System.Diagnostics;
using System.Text;

namespace FilesAndStreams.Synchronous
{
    /// <summary>
    /// Reads data from a file using different types of stream.
    /// </summary>
    internal class DataReader
    {
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataReader"/> class.
        /// </summary>
        /// <param name="filePath">Path in which the file is stored.</param>
        public DataReader(string filePath)
        {
            this._filePath = filePath;
        }

        /// <summary>
        /// Analyzes the performance of reading operation in different streams.
        /// </summary>
        internal void AnalyzePerformance()
        {
            Console.WriteLine("=============Performance Comparison=============\n");
            Helper.GenerateOneGBFile(this._filePath);
            Console.WriteLine($"Initialized Reading...");
            this.ReadFileStream();
            this.ReadBufferedStream();
            Helper.CleanConsole();
        }

        private void ReadFileStream()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            using (FileStream fileStream = new FileStream(this._filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[4096];

                int bytesRead;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"File Stream: Time taken to read 1gb text file is {stopwatch.Elapsed.TotalSeconds} seconds");
        }

        private void ReadBufferedStream()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            using (FileStream fileStream = new FileStream(this._filePath, FileMode.Open, FileAccess.Read))
            {
                BufferedStream bufferedStream = new BufferedStream(fileStream, 4096 * 4);
                byte[] buffer = new byte[4096];

                int bytesRead;
                while ((bytesRead = bufferedStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"Buffered Stream: Time taken to read 1gb text file is {stopwatch.Elapsed.TotalSeconds} seconds");
        }
    }
}