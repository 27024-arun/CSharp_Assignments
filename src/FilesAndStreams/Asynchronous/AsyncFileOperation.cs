using System.Diagnostics;
using System.Text;

namespace FilesAndStreams.Asynchronous
{
    internal class AsyncFileOperation
    {
        private readonly string _inputFile1 = "Sample1.txt";
        private readonly string _inputFile2 = "Sample2.txt";
        private readonly string _inputFile3 = "Sample3.txt";

        private readonly string _outputFile1 = "Output1.txt";
        private readonly string _outputFile2 = "Output2.txt";
        private readonly string _outputFile3 = "Output3.txt";

        private readonly int _chunkSize = 4096 * 4;

        internal async Task AnalyzePerformance()
        {
            Task task1 = Task.Run(async () => await GenerateOneGBFileAsync(this._inputFile1));
            Task task2 = Task.Run(async () => await GenerateOneGBFileAsync(this._inputFile2));
            Task task3 = Task.Run(async () => await GenerateOneGBFileAsync(this._inputFile3));
            await Task.WhenAll(task1, task2, task3);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Task processFirstFile = this.ProcessFileAsync(this._inputFile1, this._outputFile1);
            Task processSecondFile = this.ProcessFileAsync(this._inputFile2, this._outputFile2);
            Task processThirdFile = this.ProcessFileAsync(this._inputFile3, this._outputFile3);
            await Task.WhenAll(processFirstFile, processSecondFile, processThirdFile);
            stopwatch.Stop();

            Console.WriteLine($"Processed 3 files asynchronously, time taken {stopwatch.ElapsedMilliseconds} milliseconds");
        }

        private static async Task GenerateOneGBFileAsync(string fileName)
        {
            long targetFileSize = 1024L * 1024L * 1024L;
            string sampleData = "a quick brown fox jumped over the lazy dog";
            Console.WriteLine($"Generating 1 GB text file : {fileName}");

            using (StreamWriter writer = new StreamWriter(fileName, false))
            {
                while (writer.BaseStream.Length < targetFileSize)
                {
                    await writer.WriteLineAsync(sampleData);
                }
            }

            Console.WriteLine("Successfully created 1 GB text file\n");
        }

        private async Task ProcessFileAsync(string inputFile, string outputFile)
        {
            Console.WriteLine($"Started Processing : {inputFile}");
            byte[] buffer = new byte[1024];
            await using (FileStream readFileStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: this._chunkSize, options: FileOptions.Asynchronous))
            {
                await using (FileStream writeFileStream = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize: this._chunkSize, options: FileOptions.Asynchronous))
                {
                    int bytesRead = 0;
                    while ((bytesRead = await readFileStream.ReadAsync(buffer.AsMemory(0, buffer.Length))) > 0)
                    {
                        string chunk = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                        byte[] processedText = Encoding.UTF8.GetBytes(chunk.ToUpper());
                        await writeFileStream.WriteAsync(processedText.AsMemory());
                    }
                }
            }

            Console.WriteLine("Completed reading processing and writing the text asynchronously");
        }
    }
}