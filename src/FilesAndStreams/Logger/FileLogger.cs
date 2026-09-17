using System.Text;

namespace FilesAndStreams.Logger
{
    internal class FileLogger
    {
        private static string _logFilePath = "log.txt";

        internal async Task PerformLogging()
        {
            await Task.Run(() => this.LogError("Error1"));
            Task task1 = this.LogError("Error 1");
        }

        internal async Task LogError(string errorMessage)
        {
            await using (MemoryStream memoryStream = new MemoryStream())
            {
                byte[] errorBytes = Encoding.UTF8.GetBytes(errorMessage);
                memoryStream.Write(errorBytes, 0, errorBytes.Length);
                await using (FileStream fileStream = new FileStream(_logFilePath, FileMode.Append))
                {
                    memoryStream.WriteTo(fileStream);
                }
            }
        }
    }
}
