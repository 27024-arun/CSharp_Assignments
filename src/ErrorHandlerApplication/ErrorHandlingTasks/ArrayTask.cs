namespace ErrorHandlerApplication.ErrorHandlingTasks
{
    internal class ArrayTask
    {
        public void Array()
        {
            try
            {
                Console.Write("Enter the length of the array: ");
                int.TryParse(Console.ReadLine(), out var arrayLength);
                int[] array = new int[arrayLength];
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write($"Enter value for index {i}: ");
                    int.TryParse(Console.ReadLine(), out array[i]);
                }

                Console.Write("Enter the index of array to get the value: ");
                int.TryParse(Console.ReadLine(), out var indexValue);
                Console.WriteLine($"The value at the index {indexValue} is {array[indexValue]}");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Array index access is performed.");
                Console.ReadLine();
            }
        }
    }
}
