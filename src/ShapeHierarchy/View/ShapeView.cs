using ShapeHierarchy.Model;
using ShapeHierarchy.Services;

namespace ShapeHierarchy.View
{
    /// <summary>
    /// ShapeView class is view level class
    /// </summary>
    internal class ShapeView
    {
        private readonly ShapeServices _service;

        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeView"/> class.
        /// ShapeView Method is the constructor for ShapeView class.
        /// </summary>
        public ShapeView()
        {
            this._service = new ShapeServices();
        }

        /// <summary>
        /// ViewRun method is used to run the console level activities of the suer
        /// </summary>
        public void ViewRun()
        {
            try
            {
                Console.WriteLine("Enter shape type:");
                Console.WriteLine("Press R -> Rectangle / C -> Circle: ");
                string? shapeType = Console.ReadLine()?.ToLower();

                Console.WriteLine("Enter color:");
                string? color = Console.ReadLine();
                ShapeModel shape;

                if (shapeType == "r")
                {
                    Console.WriteLine("Enter width:");
                    double width = double.Parse(Console.ReadLine());

                    Console.WriteLine("Enter height:");
                    double height = double.Parse(Console.ReadLine());
                    shapeType = "rectangle";
                    shape = _service.CreateShape(shapeType, color, width, height);
                }
                else if (shapeType == "c")
                {
                    Console.WriteLine("Enter radius:");
                    double radius = double.Parse(Console.ReadLine());
                    shapeType = "circle";
                    shape = _service.CreateShape(shapeType, color, radius);
                }
                else
                {
                    Console.WriteLine("Invalid shape type.");
                    return;
                }

                string? details = _service.GetShapeDetails(shape);
                Console.WriteLine(details);
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number format.");
            }
        }
    }
}
