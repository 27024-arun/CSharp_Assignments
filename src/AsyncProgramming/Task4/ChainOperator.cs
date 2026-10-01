using System.Text.Json;

namespace AsyncProgramming.Task4
{
    internal class ChainOperator
    {
        public async Task Operate()
        {
            string header = $@"
=====================================
    Multi-layered async/await
=====================================";
            Console.Write(header);

            int result = await this.JsonParser();
            Console.WriteLine($"Result: {result}");
        }

        private async Task<int> JsonParser()
        {
            Console.WriteLine($"Json Parser");
            string response = await this.ServiceCall();
            JsonDocument json = JsonDocument.Parse(response);

            int id = json.RootElement.GetProperty("id").GetInt32();

            return id;
        }

        private async Task<string> ServiceCall()
        {
            int result = await this.CPUBoundOperator();
            Console.WriteLine($"Result of CPU bound operation: {result}");

            string link = "https://www.google.com/";
            using HttpClient client = new HttpClient();
            string data = await client.GetStringAsync(link);

            return data;
        }

        private Task<int> CPUBoundOperator()
        {
            return Task.Run(() =>
            {
                Console.Write($"CPU bound Operation");
                int result = 0;
                for (int i = 0; i < 10; i++)
                {
                    result += i;
                }

                return result;
            });
        }
    }
}
