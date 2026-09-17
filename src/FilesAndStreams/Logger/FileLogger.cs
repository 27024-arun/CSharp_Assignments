using System.Text;

namespace FilesAndStreams.Logger
{
    /// <summary>
    /// FileLogger is used to log error activity in a file.
    /// </summary>
    internal class FileLogger
    {
        private static string _logFilePath = "log.txt";

        /// <summary>
        /// Performs logging operation in file.
        /// </summary>
        /// <returns>Task in which execution is performed.</returns>
        internal async Task PerformLogging()
        {
            Task task1 = this.LogError($"DateTime: {DateTime.Now}  Error1\n");
            Task task2 = this.LogError($"DateTime: {DateTime.Now}  Error2\n");
            Task task3 = this.LogError($"DateTime: {DateTime.Now}  Error3\n");
            await Task.WhenAll(task1, task2, task3);
            Console.WriteLine("Error log has been noted");
            Helper.CleanConsole();
        }

        private async Task LogError(string errorMessage)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                byte[] errorBytes = Encoding.UTF8.GetBytes(errorMessage);
                memoryStream.Write(errorBytes, 0, errorBytes.Length);
                lock (_logFilePath)
                {
                    using (FileStream fileStream = new FileStream(_logFilePath, FileMode.Append))
                    {
                        memoryStream.WriteTo(fileStream);
                    }
                }
            }
        }
    }
}
