namespace ValueAndReferenceTypes.Task4
{

    internal class FileReader : IDisposable
    {
        private readonly StreamReader _streamReader;

        public FileReader(string filePath)
        {
            this._streamReader = new StreamReader(filePath, true);
        }

        public string ReadData(int lineNumber)
        {
            this._streamReader.DiscardBufferedData();
            this._streamReader.BaseStream.Seek(0, SeekOrigin.Begin);

            for (int i = 0; i < lineNumber - 1; i++)
            {
                this._streamReader.ReadLine();
            }

            return this._streamReader.ReadLine() ?? "No data found";
        }

        public void Dispose()
        {
            this._streamReader.Dispose();
        }
    }
}