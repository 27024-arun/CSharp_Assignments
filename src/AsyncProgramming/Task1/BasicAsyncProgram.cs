namespace AsyncProgramming.Task1
{
    /// <summary>
    /// Perform data retrieval from internet in asynchronous manner.
    /// </summary>
    internal class BasicAsyncProgram
    {
        private readonly HttpClient _client = new HttpClient();

        /// <summary>
        /// Displays data retrieved from internet in asynchronous manner.
        /// </summary>
        /// <returns>The task representing the asynchronous operation.</returns>
        public async Task ExecuteAsync()
        {
            string header = $@"
=====================================
        Async Data Download
=====================================";

            Console.Write(header);
            string link = "https://google.com";

            Console.WriteLine($"\nStarting asynchronous download from: {link}\n");

            try
            {
                string content = await this.DownloadContentAsync(link);

                Console.WriteLine($@"Downloaded Content
{content}");
            }
            catch (HttpRequestException e)
            {
                ConsoleHelper.WriteColored($"Error occured: {e.Message}", ConsoleColor.Red);
            }
            finally
            {
                ConsoleHelper.CleanConsole();
            }
        }

        private async Task<string> DownloadContentAsync(string url)
        {
            string result = await this._client.GetStringAsync(url);
            return result;
        }
    }
}