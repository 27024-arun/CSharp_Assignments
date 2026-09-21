namespace Task7.Models
{
    /// <summary>
    /// Shape with rectangular format.
    /// </summary>
    internal class Rectangle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="color">Color of the rectangle.</param>
        /// <param name="length">Length of the rectangle.</param>
        /// <param name="breadth">Breadth of the rectangle.</param>
        public Rectangle(string color, double length, double breadth)
        {
            this.Color = color;
            this.Length = length;
            this.Breadth = breadth;
        }

        /// <summary>
        /// Gets or Sets the length of the rectangle.
        /// </summary>
        /// <value>The length of the rectangle.</value>
        public double Length { get; set; }

        /// <summary>
        /// Gets or Sets the breadth of the rectangle.
        /// </summary>
        /// <value>The breadth of the rectangle.</value>
        public double Breadth { get; set; }

        /// <inheritdoc/>
        public override double CalculateArea()
        {
            return this.Length * this.Breadth;
        }
    }
}