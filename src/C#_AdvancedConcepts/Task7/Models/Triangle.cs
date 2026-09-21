namespace Task7.Models
{
    /// <summary>
    /// Shape in triangular format.
    /// </summary>
    internal class Triangle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Triangle"/> class.
        /// </summary>
        /// <param name="color">Color of the triangle.</param>
        /// <param name="baseValue">Base length of the triangle.</param>
        /// <param name="height">Height of the triangle.</param>
        public Triangle(string color, double baseValue, double height)
        {
            this.Color = color;
            this.Base = baseValue;
            this.Height = height;
        }

        /// <summary>
        /// Gets or Sets the base length of the triangle.
        /// </summary>
        /// <value>The base length of the triangle.</value>
        public double Base { get; set; }

        /// <summary>
        /// Gets or Sets the height of the triangle.
        /// </summary>
        /// <value>The height of the triangle.</value>
        public double Height { get; set; }

        /// <inheritdoc/>
        public override double CalculateArea()
        {
            return 0.5 * this.Base * this.Height;
        }
    }
}