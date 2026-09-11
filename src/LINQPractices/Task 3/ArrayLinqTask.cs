namespace LINQPractices
{
    /// <summary>
    /// Performs Array based linq task.
    /// </summary>
    internal class ArrayLinqTask
    {
        /// <summary>
        /// Filters the Array and retrieves the second highest Number, and matches the user given target number by iterating in the array.
        /// </summary>
        public void ManipulateArray()
        {
            int[] dataArray = Helper.ArrayAdder.GetArray();

            Console.Write("The Array data is: ");
            foreach (int data in dataArray)
            {
                Console.Write($"{data} ");
            }

            int secondHigherNumber = dataArray.Distinct().OrderByDescending(data => data).Skip(1).FirstOrDefault();

            Console.WriteLine($"\nThe Second Highest Number is : {secondHigherNumber}");
            Console.WriteLine("Enter a Target Number: ");
            int.TryParse(Console.ReadLine(), out int targetNumber);

            var pairs = dataArray
                .SelectMany((value, index) =>
                    dataArray.Skip(index + 1).Where(other => value + other == targetNumber)
                    .Select(other => new { PairValue1 = value, PairValue2 = other }))
                    .ToList();
            if (pairs.Any())
            {
                foreach (var pair in pairs)
                {
                    Console.WriteLine($"{pair.PairValue1} - {pair.PairValue2}");
                }
            }
            else
            {
                Console.WriteLine($"No pairs found");
            }

            Console.WriteLine($"\nEnter any key to return to main menu");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
