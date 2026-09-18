namespace FilesAndStreams.Logger
{
    /// <summary>
    /// FileLogger is used to log error activity in a file.
    /// </summary>
    internal class FileLogger
    {
        private static string _errorFilePath = "Error.txt";
        private static string _informationFilePath = "Information.txt";
        private static string _warningFilePath = "Warning.txt";

        private static SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);

        /// <summary>
        /// Performs logging operation in file.
        /// </summary>
        internal void PerformLogging()
        {
            Parallel.For(0, 100, index =>
            {
                Task.Run(() => this.LogErrorAsync($"{index} Error occurred"));
            });

            Parallel.For(0, 100, index =>
            {
                Task.Run(() => this.LogInformationAsync($"{index} Information occurred"));
            });

            Parallel.For(0, 100, index =>
            {
                Task.Run(() => this.LogWarningAsync($"{index} Warning occurred"));
            });
            Console.WriteLine("Logging is done in logger file\nCheck logger file for log data");
            Helper.CleanConsole();
        }

        private async Task LogErrorAsync(string errorMessage)
        {
            string logText = $"[{DateTime.Now}] : {errorMessage}\n";
            await _semaphoreSlim.WaitAsync();
            try
            {
                await File.AppendAllTextAsync(_errorFilePath, logText);
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        private async Task LogInformationAsync(string information)
        {
            string logText = $"[{DateTime.Now}] : {information}\n";
            await _semaphoreSlim.WaitAsync();
            try
            {
                await File.AppendAllTextAsync(_informationFilePath, logText);
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }

        private async Task LogWarningAsync(string warningMessage)
        {
            string logText = $"[{DateTime.Now}] : {warningMessage}\n";
            await _semaphoreSlim.WaitAsync();
            try
            {
                await File.AppendAllTextAsync(_warningFilePath, logText);
            }
            finally
            {
                _semaphoreSlim.Release();
            }
        }
    }
}
