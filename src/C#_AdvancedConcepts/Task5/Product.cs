namespace Task5
{
    /// <summary>
    /// Product data.
    /// </summary>
    internal class Product
    {
        /// <summary>
        /// Gets or Sets the name of the product.
        /// </summary>
        /// <value>Name of the product.</value>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or Sets the category of the product.
        /// </summary>
        /// <value>Category of the product.</value>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Gets or Sets the price of the product.
        /// </summary>
        /// <value>Price of the product.=</value>
        public int Price { get; set; }
    }
}