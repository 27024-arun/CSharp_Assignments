namespace FilesAndStreams
{
    internal class FileWriter : IDisposable
    {
        private readonly StreamWriter _streamWriter;

        private readonly FileStream _fileStream;

        public FileWriter(string filePath)
        {
            this._fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            this._streamWriter = new StreamWriter(this._fileStream);
        }

        public void WriteData(string text)
        {
            this._streamWriter.WriteLine(text);
            this._streamWriter.Flush();
        }

        public void Dispose()
        {
            this._fileStream.Dispose();
        }
    }
}
