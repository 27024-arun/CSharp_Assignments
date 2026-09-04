namespace ValueAndReferenceTypes.Task4
{
    internal class FileWriter : IDisposable
    {
        private readonly StreamWriter _streamWriter;

        public FileWriter(string filePath)
        {
            this._streamWriter = new StreamWriter(filePath, true);
        }

        public void Write(string text)
        {
            this._streamWriter.WriteLine(text);
            this._streamWriter.Flush();
        }

        public void Dispose()
        {
            this._streamWriter.Dispose();
        }
    }
}