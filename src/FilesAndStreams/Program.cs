namespace FilesAndStreams
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            DataReader reader = new DataReader("Sample.txt");
            while (true)
            {
                string userMenu = $@"
=============File Handling=============
1. Generate 1gb data file
2. Performance of FileStream and BufferedStream
3. Read data using BufferedStream
4. Exit
Enter Choice: ";
                Console.Write(userMenu);
                int.TryParse(Console.ReadLine(), out int userChoice);
                Console.Clear();
                switch (userChoice)
                {
                    case 1:
                        reader.GenerateOneGBFile();
                        break;
                    case 2:
                        reader.AnalysePerformance();
                        break;
                    case 3:
                        reader.ReadFileStream();
                        break;
                    case 4:
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