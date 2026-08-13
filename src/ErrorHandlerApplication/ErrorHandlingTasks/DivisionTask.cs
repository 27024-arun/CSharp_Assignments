namespace ErrorHandlerApplication.ErrorHandlingTasks
{
    /// <summary>
    /// DivisionTask class is used to implement division task.
    /// </summary>
    internal class DivisionTask
    {
        /// <summary>
        /// Divide method is used to divide data and catches exception if the user input throws an exception.
        /// </summary>
        public void Divide()
        {
            try
            {
                Console.Write("Enter the dividend value: ");
                int dividend = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter the divisor value: ");
                int divisor = Convert.ToInt32(Console.ReadLine());
                int result = dividend / divisor;
                Console.WriteLine($"Result of {dividend} % {divisor} is {result}");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Division process is executed.");
                Console.ReadLine();
            }
        }
    }
}
