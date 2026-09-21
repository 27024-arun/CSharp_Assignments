using AdvancedConcepts;
using Task7.Models;

namespace Task7
{
    /// <summary>
    /// Accesses multiple shapes and displays then by identity matching.
    /// </summary>
    internal class ShapeAccessor
    {
        private readonly List<Shape> _shapes = new List<Shape>
        {
            new Triangle("Blue", 10.5, 29.6),
            new Rectangle("Red", 30.2, 23.5),
            new Circle("White", 25.0),
        };

        /// <summary>
        /// Displays multiple types of shapes.
        /// </summary>
        public void DisplayShape()
        {
            Console.WriteLine($@"===========Shapes===========");
            foreach (var shape in this._shapes)
            {
                this.DisplayShapeDetails(shape);
            }

            Helper.CleanConsole();
        }

        private void DisplayShapeDetails(Shape shape)
        {
            switch (shape)
            {
                case Rectangle rectangle:
                    Console.WriteLine($@"Rectangle found
Color: {rectangle.Color}
Area: {rectangle.CalculateArea()}" + Environment.NewLine);
                    break;
                case Circle circle:
                    Console.WriteLine($@"Circle found
Color: {circle.Color}
Area: {circle.CalculateArea()}" + Environment.NewLine);
                    break;
                case Triangle triangle:
                    Console.WriteLine($@"Triangle found
Color: {triangle.Color}
Area: {triangle.CalculateArea()}" + Environment.NewLine);
                    break;
                default:
                    Console.WriteLine($"Invalid data found");
                    break;
            }
        }
    }
}
