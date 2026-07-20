namespace ShapeHierarchy.Model
{
    /// <summary>
    /// Rectangle is the class that has the properties of rectangle shape and inherits ShapeModel class
    /// </summary>
    internal class Rectangle : ShapeModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// Retangle method is the constructor for the Rectangle class
        /// </summary>
        /// <param name="color">Color is the color of the rectangle</param>
        /// <param name="width">Width is the width of the rectangle</param>
        /// <param name="height">Height is the height of the rectangle</param>
        public Rectangle(string color, double width, double height)
        {
            Color = color;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Gets or Sets the width of the shape
        /// </summary>
        /// <value>
        /// Width of the shape
        /// </value>
        public double Width { get; set; }

        /// <summary>
        /// Gets or Sets the height of the shape
        /// </summary>
        /// <value>
        /// Height of the shape
        /// </value>
        public double Height { get; set; }

        /// <summary>
        /// CalculateArea functions is used to calculate the area of the rectangle
        /// </summary>
        /// <returns>Returns the area of the rectangle</returns>
        public override double CalculateArea() => Width * Height;
    }
}
