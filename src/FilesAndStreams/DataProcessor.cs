using System.Diagnostics;
using System.Text;

namespace FilesAndStreams
{
    internal class DataProcessor
    {
        private readonly string _filePath;

        public DataProcessor(string fileName)
        {
            this._filePath = fileName;
        }

        internal void ProcessData()
        {
            Console.WriteLine("=============Performance Comparison=============\nInitialized Processing by make all values to uppercases...");
            this.ProcessFileStream();
            this.ProcessBufferedStream();
            Helper.CleanConsole();
        }

        internal void ProcessFileStream()
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
            Console.WriteLine($"Buffered Stream: Time taken to process 1gb text file is {stopwatch.Elapsed.TotalSeconds} seconds");
        }

        internal void ProcessBufferedStream()
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
