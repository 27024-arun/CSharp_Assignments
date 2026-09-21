using AdvancedConcepts;

namespace Task4
{
    /// <summary>
    /// Implements lambda expression and statement for filtering array.
    /// </summary>
    internal static class LambdaProvider
    {
        private static readonly int _arrayLength = 10;

        /// <summary>
        /// Performs array filtering using lambda expression and statement.
        /// </summary>
        public static void PerformFiltering()
        {
            Console.WriteLine($@"
===========Array Filter===========
Enter values for array");
            int[] sampleArray = new int[_arrayLength];
            for (int index = 1; index <= _arrayLength; index++)
            {
                Console.Write($"Value {index}: ");
                int.TryParse(Console.ReadLine(), out sampleArray[index - 1]);
            }

            int[] evenValuedArray = sampleArray.Where(value => value % 2 == 0).ToArray(); // Lambda Expression

            Console.Write($"\nEven values from the array: ");
            for (int index = 1; index <= evenValuedArray.Length; index++)
            {
                Console.Write($"{evenValuedArray[index - 1]} ");
            }

            Func<int[], int[]> squareArray = (int[] array) =>
            {
                int[] evenArray = array.Where(value => value % 2 == 0).ToArray();
                return evenArray.Select(value => value * value).ToArray();
            };

            int[] squaredArray = squareArray(sampleArray);

            Console.Write($"\nEven values squared from the array: ");
            for (int index = 1; index <= squaredArray.Length; index++)
            {
                Console.Write($"{squaredArray[index - 1]} ");
            }

            Helper.CleanConsole();
        }
    }
}