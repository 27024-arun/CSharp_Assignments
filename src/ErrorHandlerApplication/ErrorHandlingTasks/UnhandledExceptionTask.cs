namespace ErrorHandlerApplication.ErrorHandlingTasks
{
    /// <summary>
    /// UnhandledExceptionTask class is used to handle unhandled exceptions.
    /// </summary>
    internal class UnhandledExceptionTask
    {
        /// <summary>
        /// ExceptionHandling method is used to handle unexpected exception.
        /// </summary>
        /// <exception cref="ArgumentNullException">ArgumentNullException is used to pass an unexpected exception.</exception>
        public void ExceptionHandling()
        {
            AppDomain.CurrentDomain.UnhandledException += this.CurrentDomain_UnhandledException;
            try
            {
                Console.Write("Enter the length of the array: ");
                string? length = Console.ReadLine();
                int arrayLength = this.GetCorrectValue(length);

                int[] array = new int[arrayLength];
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write($"Enter value for index {i}: ");
                    string? value = Console.ReadLine();
                    array[i] = this.GetCorrectValue(value);
                }

                Console.Write("Enter the index of array to get the value: ");
                int.TryParse(Console.ReadLine(), out var indexValue);
                Console.WriteLine($"The value at the index {indexValue} is {array[indexValue]}");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidUserInputException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Finally block is executed succesfully.");
                Console.ReadLine();
            }

            throw new ArgumentNullException();
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e.ExceptionObject is Exception ex)
            {
                Console.WriteLine($"Exception Type: {ex.GetType()}");
            }
        }

        private int GetCorrectValue(string? userValue)
        {
            if (!int.TryParse(userValue, out int number))
            {
                throw new InvalidUserInputException("Input is not a valid integer.");
            }

            if (number <= 0)
            {
                throw new InvalidUserInputException("Input cannot be a negative value.");
            }

            return number;
        }
    }
}
