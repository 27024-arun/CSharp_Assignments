using System.Diagnostics;
using System.Text;

namespace FilesAndStreams
{
    internal class DataWriter
    {
        private readonly string _filePath;

        public DataWriter(string filePath)
        {
            this._filePath = filePath;
        }

        internal void WriteMemoryStream()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();

            byte[] buffer = new byte[4096 * 16];

            using (FileStream fileStream = new FileStream(this._filePath, FileMode.Open, FileAccess.Read))
            using (MemoryStream memoryStream = new MemoryStream())
            {
                int bytesRead;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    byte[] processedBytes = Encoding.UTF8.GetBytes(data);

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

        internal string ProcessFileStream()
        {
            string processedData = string.Empty;
            byte[] buffer = new byte[64 * 1024];

            using (FileStream fileStream = new FileStream(this._filePath, FileMode.Open, FileAccess.Read))
            {
                int bytesRead;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                   string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                   processedData += data.ToUpper();
                }
            }

            return processedData;
        }
    }
}
