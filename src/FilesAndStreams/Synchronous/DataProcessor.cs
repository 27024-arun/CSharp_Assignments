using System.Diagnostics;
using System.Text;

namespace FilesAndStreams.Synchronous
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
            Console.WriteLine("=============Performance Comparison=============\n");
            Helper.GenerateOneGBFile(this._filePath);
            Console.WriteLine($"Initialized processing data");
            this.ProcessFileStream();
            this.ProcessBufferedStream();
            Helper.CleanConsole();
        }

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