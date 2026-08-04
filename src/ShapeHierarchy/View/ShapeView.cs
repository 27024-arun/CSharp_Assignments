using ShapeHierarchy.Model;
using ShapeHierarchy.Services;

namespace ShapeHierarchy.View
{
    /// <summary>
    /// ShapeView class is used do the console based operations of the program.
    /// </summary>
    internal class ShapeView
    {
        private static readonly ShapeServices _service = new ShapeServices();

        /// <summary>
        /// ShapeCircle method is used to get inputs for the circle.
        /// </summary>
        internal static void ShapeCircle()
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
                Shape shape;
                double.TryParse(radiusInput, out double radius);
                shape = _service.CreateShape("circle", color, radius);
                string details = _service.GetShapeDetails(shape);
                Console.WriteLine(details);
            }
        }

        /// <summary>
        /// ShapeRectangle method is used to get input for the ShapeRectangle.
        /// </summary>
        internal static void ShapeRectangle()
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
                Shape shape;
                double.TryParse(widthInput, out double width);
                double.TryParse(heightInput, out double height);
                shape = _service.CreateShape("rectangle", color, width, height);
                string? details = _service.GetShapeDetails(shape);
                Console.WriteLine(details);
            }
        }
    }
}
