using System.Drawing;
using ShapeHierarchy.Model;
using ShapeHierarchy.Services;

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
            while (true)
            {
                Console.WriteLine("\nEnter shape type:\nPress R -> Rectangle / C -> Circle / E -> Exit: ");
                string? userChoice = Console.ReadLine()?.ToLower();

                switch (userChoice)
                {
                    case "r":
                        ShapeRectangle();
                        break;
                    case "c":
                        ShapeCircle();
                        break;
                    case "e":
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        private static void ShapeCircle()
        {
            Console.WriteLine("Enter the color of Circle: ");
            string? color = Console.ReadLine();

            Console.WriteLine("Enter radius:");
            string? radiusInput = Console.ReadLine();

            if (color == string.Empty || color == null)
            {
                Console.WriteLine("Color cannot be empty.");
            }
            else if (radiusInput == string.Empty || radiusInput == null)
            {
                Console.WriteLine("Radius cannot be empty.");
            }
            else
            {
                ShapeModel shape;
                double.TryParse(radiusInput, out double radius);
                shape = _service.CreateShape("circle", color, radius);
                string details = _service.GetShapeDetails(shape);
                Console.WriteLine(details);
            }
        }

        private static void ShapeRectangle()
        {
            Console.WriteLine("Enter the color of Rectangle: ");
            string? color = Console.ReadLine();

            Console.WriteLine("Enter width:");
            string? widthInput = Console.ReadLine();

            Console.WriteLine("Enter height:");
            string? heightInput = Console.ReadLine();
            if (color == string.Empty || color == null)
            {
                Console.WriteLine("Color should not be empty.");
            }
            else if (widthInput == string.Empty || widthInput == null)
            {
                Console.WriteLine("Width cannot be empty.");
            }
            else if (heightInput == string.Empty || heightInput == null)
            {
                Console.WriteLine("Height cannot be empty.");
            }
            else
            {
                ShapeModel shape;
                double.TryParse(widthInput, out double width);
                double.TryParse(heightInput, out double height);
                shape = _service.CreateShape("rectangle", color, width, height);
                string? details = _service.GetShapeDetails(shape);
                Console.WriteLine(details);
            }
        }
    }
}
