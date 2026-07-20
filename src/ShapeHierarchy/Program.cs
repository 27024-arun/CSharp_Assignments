using ShapeHierarchy.View;

namespace Assignments
{
    /// <summary>
    /// Program is the entry class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main function is the entry function
        /// </summary>
        public static void Main()
        {
            ShapeView view = new ShapeView();
            view.ViewRun();
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
