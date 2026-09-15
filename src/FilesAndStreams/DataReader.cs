namespace FilesAndStreams
{
    internal class DataReader
    {
        public void Run()
        {
            string filePath = "Sample.txt";

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[4096];

                int bytesRead;
                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string data = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.Write(data);
                }
            }
        }

        public void ReadUsingBuffer()
        {
            string filePath = "Sample.txt";

            using (FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                BufferedStream bufferedStream = new BufferedStream(fileStream);
                byte[] buffer = new byte[4096];

                int bytesRead;
                while ((bytesRead = bufferedStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string data = System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.Write(data);
                }
            }
        }
    }
}