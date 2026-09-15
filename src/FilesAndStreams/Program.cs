namespace FilesAndStreams
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /*using (FileWriter writer = new FileWriter("Sample.txt"))
            {
                writer.WriteData("Arun");
                writer.WriteData("John");
            }

            string data;

            using FileReader reader = new FileReader("Sample.txt");
            data = reader.ReadData(0);

            Console.Write(data);*/
            DataReader reader = new DataReader();
            reader.Run();

            Console.ReadKey();
        }
    }
}