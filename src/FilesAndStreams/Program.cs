namespace FilesAndStreams
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DataReader reader = new DataReader("Sample.txt");
            DataProcessor dataProcessor = new DataProcessor("Sample.txt");
            DataWriter dataWriter = new DataWriter("Sample.txt");
            while (true)
            {
                string userMenu = $@"
=============File Handling=============
1. Generate 1gb data file
2. Performance of FileStream and BufferedStream
3. Performance of processed data in FileStream and BufferedStream
4. Write using MemoryStream
5. Exit
Enter Choice: ";
                Console.Write(userMenu);
                int.TryParse(Console.ReadLine(), out int userChoice);
                Console.Clear();
                switch (userChoice)
                {
                    case 1:
                        Helper.GenerateOneGBFile();
                        break;
                    case 2:
                        reader.AnalysePerformance();
                        break;
                    case 3:
                        dataProcessor.ProcessData();
                        break;
                    case 4:
                        dataWriter.WriteMemoryStream();
                        break;
                    case 5:
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