namespace Inventory_Management.Model
{
    /// <summary>
    /// InventoryModel is the Model layer of the Inventory
    /// </summary>
    public class InventoryModel
    {
        /// <summary>
        /// InventoryMenu is a enum.
        /// </summary>
        public enum InventoryMenu
        {
            /// <summary>
            /// AddProduct is a enum value assigned with value 1.
            /// </summary>
            AddProduct = 1,

            /// <summary>
            /// ViewProduct is a enum value assigned with value 2.
            /// </summary>
            ViewProducts = 2,

            /// <summary>
            /// SearchProduct is a enum value assigned with value 3.
            /// </summary>
            SearchProduct = 3,

            /// <summary>
            /// UpdateProduct is a enum value assigned with value 4.
            /// </summary>
            UpdateProduct = 4,

            /// <summary>
            /// DeleteProduct is a enum value assigned with value 5.
            /// </summary>
            DeleteProduct = 5,

            /// <summary>
            /// Exit is a enum value assigned with value 6.
            /// </summary>
            Exit = 6,
        }

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