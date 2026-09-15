using System.Diagnostics;

namespace FilesAndStreams
{
    internal class DataReader
    {
        private readonly string _filePath;

        public DataReader(string fileName)
        {
            this._filePath = fileName;
        }

        internal void AnalysePerformance()
        {
            Console.WriteLine("=============Performance Comparison=============\nInitialized Reading...");
            this.ReadFileStream();
            this.ReadBufferedStream();
        }

        public void ReadFileStream()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            using (FileStream fileStream = new FileStream(this._filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[4096];

                int bytesRead;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string data = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"File Stream: Time taken to read 1gb text file is {stopwatch.Elapsed.TotalSeconds} seconds");
        }

        public void ReadBufferedStream()
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
                    string data = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
                }
            }

            stopwatch.Stop();
            Console.WriteLine($"Buffered Stream: Time taken to read 1gb text file is {stopwatch.Elapsed.TotalSeconds} seconds");
        }

        public void GenerateOneGBFile()
        {
            long targetFileSize = 1024L * 1024L * 1024L;
            string sampleData = "A quick brown fox jumped over the lazy dog.";
            Console.WriteLine("Writing data into the file");
            using (StreamWriter writer = new StreamWriter(this._filePath, false))
            {
                while (writer.BaseStream.Length < targetFileSize)
                {
                    writer.Write(sampleData);
                }
            }

            Console.WriteLine("Successfully created one GB text file\nEnter a key to return to main menu");
            Console.ReadKey();
            Console.Clear();
        }
    }
}