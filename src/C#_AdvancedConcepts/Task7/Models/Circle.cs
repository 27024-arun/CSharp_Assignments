namespace Task7.Models
{
    /// <summary>
    /// Shape in circular form.
    /// </summary>
    internal class Circle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// </summary>
        /// <param name="color">Color of the circle.</param>
        /// <param name="radius">Radius of the circle.</param>
        public Circle(string color, double radius)
        {
            this.Color = color;
            this.Radius = radius;
        }

        /// <summary>
        /// Gets or Sets the radius of the circle.
        /// </summary>
        /// <value>The Radius of the circle.</value>
        public double Radius { get; set; }

        /// <inheritdoc/>
        public override double CalculateArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }
    }
}
