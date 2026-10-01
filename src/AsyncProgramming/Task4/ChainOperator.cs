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
            Console.WriteLine($"Result of json parser: {result}");

            ConsoleHelper.CleanConsole();
        }

        private async Task<int> JsonParser()
        {
            Console.WriteLine($"\nJson Parser is initialized");
            string response = await this.ServiceCall();
            JsonDocument json = JsonDocument.Parse(response);

            int id = json.RootElement.GetProperty("id").GetInt32();

            return id;
        }

        private async Task<string> ServiceCall()
        {
            int cpuBoundOperationResult = await this.CPUBoundOperator();
            Console.WriteLine($"\nResult of CPU bound operation: {cpuBoundOperationResult}");

            string link = "https://jsonplaceholder.typicode.com/todos/1";
            using HttpClient client = new HttpClient();
            string data = await client.GetStringAsync(link);

            return data;
        }

        private Task<int> CPUBoundOperator()
        {
            return Task.Run(() =>
            {
                Console.Write($"\nCPU bound Operation is started");
                int sum = 0;
                for (int i = 0; i < 10000; i++)
                {
                    sum += i;
                }

                return sum;
            });
        }
    }
}
