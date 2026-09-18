namespace Task7.Models
{
    /// <summary>
    /// Shape of the object.
    /// </summary>
    internal abstract class Shape
    {
        /// <summary>
        /// Gets or Sets the color of the circle.
        /// </summary>
        /// <value>The color of the circle.</value>
        public string Color { get; set; } = string.Empty;

        /// <summary>
        /// Calculate area of the shape.
        /// </summary>
        /// <returns>Area of the shape.</returns>
        public abstract double CalculateArea();
    }
}