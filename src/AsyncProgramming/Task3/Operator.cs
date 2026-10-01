namespace AsyncProgramming.Task3
{
    /// <summary>
    /// Performs multiple calculatory operations.
    /// </summary>
    internal class Operator
    {
        private int[] _dataArray = { 1, 39, 57, 67, 92, 100, 584, 384, 28, 15, 349, 26, 28, 298, 47, 9834, 928, 4567, 39, 20 };

        private int _sum = 0;

        private int[] _sortedArray = new int[20];

        private int _minValue = 0;

        /// <summary>
        /// Creates thread and performs calculatory operations in asynchronous manner.
        /// </summary>
        public void Operate()
        {
            string header = $@"
=====================================
        Thread Concepts
=====================================";
            Console.Write(header);
            Thread sumThread = new Thread(this.Calculate);
            Thread sorterThread = new Thread(this.Sort);
            Thread minThread = new Thread(this.GetMinimum);

            sumThread.Start();
            sorterThread.Start();
            minThread.Start();

            sumThread.Join();
            sorterThread.Join();
            minThread.Join();
            this.DisplayResult();

            ConsoleHelper.CleanConsole();
        }

        private void DisplayResult()
        {
            Console.Write($@"
Results
Sum of 1 to 10: {this._sum}
Array values are: ");

            for (int i = 0; i < this._dataArray.Length; i++)
            {
                Console.Write($"{this._dataArray[i]} ");
            }

            Console.Write("\nSorted Array values: ");
            for (int i = 0; i < this._dataArray.Length; i++)
            {
                Console.Write($"{this._dataArray[i]} ");
            }

            Console.WriteLine($"\nMin Value of Array: {this._minValue}");
        }

        private void Calculate()
        {
            int sum = 0;
            for (int i = 1; i <= 10; i++)
            {
                sum += i;
            }

            this._sum = sum;
        }

        private void Sort()
        {
            this._sortedArray = this._dataArray.OrderBy(data => data).ToArray();
        }

        private void GetMinimum()
        {
            this._minValue = this._dataArray.Min();
        }
    }
}
