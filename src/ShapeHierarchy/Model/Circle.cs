namespace ShapeHierarchy.Model
{
    /// <summary>
    /// Circle class defines the shape circle and inherits ShapeModel class
    /// </summary>
    internal class Circle : ShapeModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// Circle method is the constructor of the Circle class
        /// </summary>
        /// <param name="color">Color is the color of the cirlce</param>
        /// <param name="radius">Radius is the radius of the cirlce</param>
        public Circle(string color, double radius)
        {
            this.Color = color;
            this.Radius = radius;
        }

        /// <summary>
        /// Gets or sets the radius of the circle
        /// </summary>
        /// <value>
        /// The radius of the circle
        /// </value>
        public double Radius { get; set; }

        /// <summary>
        /// CalculateArea method is the function that defines the area calculation of the circle
        /// </summary>
        /// <returns>Returns the area of the cirlce</returns>
        public override double CalculateArea() => Math.PI * this.Radius * this.Radius;
    }
}
