using AdvancedConcepts;

namespace Task3
{
    /// <summary>
    /// Sorts array using anonymous method.
    /// </summary>
    internal static class ArraySorter
    {
        private static readonly int _arrayLength = 10;

        private delegate void Sort(int[] array);

        /// <summary>
        /// Sorts array values.
        /// </summary>
        public static void SortArray()
        {
            Console.WriteLine($@"
===========Sort Array===========
Enter values for array");
            int[] sampleArray = new int[_arrayLength];
            for (int index = 1; index <= _arrayLength; index++)
            {
                Console.Write($"Value {index}: ");
                int.TryParse(Console.ReadLine(), out sampleArray[index - 1]);
            }

            Sort sortArray = (int[] array) => Array.Sort(array);

            sortArray(sampleArray);

            Console.Write($"\nSorted array values: ");
            for (int i = 0; i < sampleArray.Length; i++)
            {
                Console.Write($"{sampleArray[i]} ");
            }

            Helper.CleanConsole();
        }
    }
}