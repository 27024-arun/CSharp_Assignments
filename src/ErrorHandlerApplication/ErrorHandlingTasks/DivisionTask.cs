namespace ErrorHandlerApplication.ErrorHandlingTasks
{
    internal class DivisionTask
    {
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
