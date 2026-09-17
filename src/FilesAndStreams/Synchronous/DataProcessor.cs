using System.Diagnostics;
using System.Text;

namespace FilesAndStreams.Synchronous
{
    /// <summary>
    /// Reads and processes data from a file using different types of stream.
    /// </summary>
    internal class DataProcessor
    {
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataProcessor"/> class.
        /// </summary>
        /// <param name="fileName">Path in which the file is stored.</param>
        public DataProcessor(string fileName)
        {
            this._filePath = fileName;
        }

        /// <summary>
        /// Performs function call for performing performance analysis of streams.
        /// </summary>
        internal void ProcessData()
        {
            Console.WriteLine("=============Performance Comparison=============\n");
            Helper.GenerateOneGBFile(this._filePath);
            Console.WriteLine($"Initialized processing data");
            this.ProcessFileStream();
            this.ProcessBufferedStream();
            Helper.CleanConsole();
        }

        /// <summary>
        /// Processes data in file by making characters to upper case using file stream.
        /// </summary>
        private void ProcessFileStream()
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
                    string processedData = data.ToUpper();
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"File Stream: Time taken to process 1gb text file is {stopwatch.Elapsed.TotalSeconds} seconds");
        }

        /// <summary>
        /// Processes data in file by making characters to upper case using buffered stream.
        /// </summary>
        private void ProcessBufferedStream()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            using (FileStream fileStream = new FileStream(this._filePath, FileMode.Open, FileAccess.Read))
            {
                BufferedStream bufferedStream = new BufferedStream(fileStream);
                byte[] buffer = new byte[4096];

                int bytesRead;
                while ((bytesRead = bufferedStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    string processedData = data.ToUpper();
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"Buffered Stream: Time taken to process 1gb text file is {stopwatch.Elapsed.TotalSeconds} seconds");
        }
    }
}