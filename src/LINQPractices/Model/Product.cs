namespace LINQPractices.Model
{
    /// <summary>
    /// Defines the properties of the Products.
    /// </summary>
    internal class Product
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Product"/> class.
        /// </summary>
        /// <param name="productId">Unique identifier of the product.</param>
        /// <param name="productName">Name of the product.</param>
        /// <param name="price">Rate of the product.</param>
        /// <param name="category">Defines product category.</param>
        public Product(int productId, string productName, int price, ProductCategory category)
        {
            this.ProductId = productId;
            this.ProductName = productName;
            this.Price = price;
            this.Category = category;
        }

        /// <summary>
        /// Gets or Sets the unique identifier of the product.
        /// </summary>
        /// <value>Unique identifier of the product.</value>
        public int ProductId { get; set; }

        /// <summary>
        /// Gets or Sets the name of the product.
        /// </summary>
        /// <value>Name of the product.</value>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or Sets the price of the product.
        /// </summary>
        /// <value>Price of the product.</value>
        public int Price { get; set; }

        /// <summary>
        /// Gets or Sets the category of the product.
        /// </summary>
        /// <value>Category of the product.</value>
        public ProductCategory Category { get; set; }
    }
}
