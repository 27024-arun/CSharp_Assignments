using EmployeeHierarchy.View;

namespace Assignments
{
    /// <summary>
    /// Program is the entry level function.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main is the entry function of the program.
        /// </summary>
        public static void Main()
        {
            try
            {
                bool exit = true;
                while (exit)
                {
                    EmployeeView view = new ();
                    exit = view.ViewRun();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}