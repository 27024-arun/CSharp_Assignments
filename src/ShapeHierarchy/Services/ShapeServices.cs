using ShapeHierarchy.Model;

namespace ShapeHierarchy.Services
{
    /// <summary>
    /// ShapeServices class is used to calculate area and print details.
    /// </summary>
    internal class ShapeServices
    {
        /// <summary>
        /// CreateShape function is used create a shape given by the user.
        /// </summary>
        /// <param name="shapeType">shapeType defines what is the shape</param>
        /// <param name="color">Color is the color of the shape</param>
        /// <param name="dimension1">dimension1 is the width of the rectangle, dimension1 is radius if circle</param>
        /// <param name="dimension2">dimension2 is the height of the retancle</param>
        /// <returns>Returns the ShapeModel</returns>
        public ShapeModel CreateShape(string shapeType, string color, double dimension1, double dimension2 = 0)
        {
            if (shapeType == "rectangle")
            {
                return new Rectangle(color, dimension1, dimension2);
            }
            else
            {
                return new Circle(color, dimension1);
            }
        }

        /// <summary>
        /// GetShapeDetails method is used to get the details of the shape.
        /// </summary>
        /// <param name="shape">shape defines what is the shape</param>
        /// <returns>Returns all the details of the shape</returns>
        public string GetShapeDetails(ShapeModel shape)
        {
            return $"Shape: {shape.GetType().Name}\nColor: {shape.Color}\nArea: {shape.CalculateArea():F2}";
        }
    }
}
