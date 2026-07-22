namespace ShapeHierarchy.Model
{
    /// <summary>
    /// ShapeModel is a abstract class with the definition of property.
    /// </summary>
    internal abstract class ShapeModel
    {
        /// <summary>
        /// Gets or sets color is a property defining the color of the shape.
        /// </summary>
        /// <value>
        /// Color of the shape
        /// </value>
        public string? Color { get; set; }

        /// <summary>
        /// CalculateArea is a abstract function for calculating area of the shape.
        /// </summary>
        /// <returns>Retturns the area of the shape selected by the user</returns>
        public abstract double CalculateArea();
    }
}
