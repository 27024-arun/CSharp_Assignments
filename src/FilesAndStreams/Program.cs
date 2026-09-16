using FilesAndStreams.Asynchronous;
using FilesAndStreams.Logger;
using FilesAndStreams.Synchronous;
using FilesAndStreams.Task3;

namespace FilesAndStreams
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            DataReader reader = new DataReader("Sample1.txt");
            DataProcessor dataProcessor = new DataProcessor("Sample1.txt");
            DataWriter dataWriter = new DataWriter("Sample1.txt");

            AsyncFileOperation operation = new AsyncFileOperation();

            MemoryCode memoryCode = new MemoryCode();
            FileLogger logger = new FileLogger();
            while (true)
            {
                string userMenu = $@"
=============File Handling=============
1. Performance of FileStream and BufferedStream
2. Performance of processed data in FileStream and BufferedStream
3. Write using MemoryStream
4. Asynchronous Performance comparison of streams
5. Memory leak corrected code
6. Logger
7. Exit

Enter Choice: ";
                Console.Write(userMenu);
                int.TryParse(Console.ReadLine(), out int userChoice);
                Console.Clear();
                switch (userChoice)
                {
                    case 1:
                        reader.AnalyzePerformance();
                        break;
                    case 2:
                        dataProcessor.ProcessData();
                        break;
                    case 3:
                        dataWriter.WriteMemoryStream();
                        break;
                    case 4:
                        //operation.AnalyzePerformance().GetAwaiter().GetResult();
                        await operation.AnalyzePerformance();
                        break;
                    case 5:
                        memoryCode.Run();
                        break;
                    case 6:
                        logger.PerformLogging();
                        break;
                    case 7:
                        Console.WriteLine($"Exiting...");
                        Thread.Sleep(1200);
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        Thread.Sleep(1200);
                        Console.Clear();
                        break;
                }
            }
        }
    }
}