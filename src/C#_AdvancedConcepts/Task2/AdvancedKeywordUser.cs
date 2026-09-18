using AdvancedConcepts;

namespace Task2
{
    internal class AdvancedKeywordUser
    {
        public void PerformVariableChange()
        {
            try
            {
                Console.WriteLine($"===========Keyword Usage===========\n");

                var value = 10;
                dynamic data = 20;

                // string sampleValue = (string)value; Throws compile time error
                Console.WriteLine($@"The value in the var keyword is: {value}
The value cannot be modified to another type as it is checked in compile time" + Environment.NewLine);

                Console.WriteLine($@"The value in the dynamic keyword is: {data}
Now trying to modify the data to another type" + Environment.NewLine);
                data = (string)data;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception message: {e.Message}\n");

                Console.WriteLine($@"The value can be modified to another type in compile time but it fails during runtime
Because the checks for casting happens only in runtime for dynamic keyword");
            }
            finally
            {
                Helper.CleanConsole();
            }
        }
    }
}
