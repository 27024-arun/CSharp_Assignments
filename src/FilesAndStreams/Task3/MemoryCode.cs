using System.Text;

namespace FilesAndStreams.Task3
{
    class MemoryCode
    {
        public void Run()
        {
            string path = "test.txt";
            string data = "This is some test data";

            using (FileStream fileStream = new FileStream(path, FileMode.Create))
            {
                byte[] buffer = Encoding.UTF8.GetBytes(data);
                fileStream.Write(buffer, 0, buffer.Length);
            }

            using (FileStream fileStream = new FileStream(path, FileMode.Open))
            {
                byte[] buffer = new byte[1024];
                int bytesRead;

                while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    Console.WriteLine(Encoding.UTF8.GetString(buffer));
                }
            }

            Console.WriteLine("File operation completed.");
        }
    }
}