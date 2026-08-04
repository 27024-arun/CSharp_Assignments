using ShapeHierarchy.Services;
using ShapeHierarchy.View;

namespace Assignments
{
    /// <summary>
    /// Program is the entry class(It is the view level)
    /// </summary>
    internal class Program
    {
        private static readonly ShapeServices _service = new ShapeServices();

        /// <summary>
        /// Main function is the entry function.
        /// </summary>
        public static void Main()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("\nEnter shape type:\nPress R -> Rectangle / C -> Circle / E -> Exit: ");
                    string? userChoice = Console.ReadLine()?.ToLower();

                    switch (userChoice)
                    {
                        case "r":
                            ShapeView.ShapeRectangle();
                            break;
                        case "c":
                            ShapeView.ShapeCircle();
                            break;
                        case "e":
                            return;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
