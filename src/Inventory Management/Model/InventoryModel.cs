namespace Inventory_Management.Model
{
    /// <summary>
    /// InventoryModel is the Model layer of the Inventory
    /// </summary>
    internal class InventoryModel
    {
        /// <summary>
        /// Gets or sets the product ID of the product which is the unique identifier of the product.
        /// </summary>
        /// <value>
        /// Product Id of the product.
        /// </value>
        public int ProductID { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        /// <value>
        /// Name of the product.
        /// </value>
        public string? ProductName { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        /// <value>
        /// Price of the product.
        /// </value>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the product.
        /// </summary>
        /// <value>
        /// Quantity of the product.
        /// </value>
        public int Quantity { get; set; }
    }
}